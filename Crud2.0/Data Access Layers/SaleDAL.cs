using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Data_Access_Layers
{
    /// <summary>
    /// This class handles retrieving sales records and inserting new sales atomically 
    /// </summary>
    internal class SaleDAL
    {
        /// <summary>
        /// Retrieves all records from the main 'sales' table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM sales",conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                  
            }
            return dt;
        }

        /// <summary>
        /// Inserts a new complete sale record, including all line items, and deducts stock quantities.
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="saleItem"></param>
        /// <returns></returns>
        public static int InsertSale(Sale sale, List<Sale_Item> saleItem)
        {
            int saleId = -1;

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Start the transaction to ensure that if any step (sale, item, or stock update) fails, 
                // all changes are reversed.
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert the main sale header record.
                    string query = @"INSERT INTO sales (sale_date, customer_id, user_id, global_discount, total_amount,
                                    change_given, net_amount, amount_paid, payment_status, invoice_number, 
                                    notes, payment_method) VALUES (@date, @customer_id, @user_id,
                                    @global_discount,@total, @change, @net_amount, @amount_paid, @payment_status
                                    , @invoice_number, @notes, @payment_method);
                                     SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                    // Bind parameters to the main sale object properties.
                    cmd.Parameters.AddWithValue("@date", sale.Date);
                    cmd.Parameters.AddWithValue("@customer_id", sale.CustomerID);
                    cmd.Parameters.AddWithValue("@user_id", sale.UserID);
                    cmd.Parameters.AddWithValue("@global_discount",sale.GlobalDiscount);
                    cmd.Parameters.AddWithValue("@total", sale.TotalAmount);
                    cmd.Parameters.AddWithValue("@change", sale.Change);
                    cmd.Parameters.AddWithValue("@net_amount", sale.NetAmount);
                    cmd.Parameters.AddWithValue("@amount_paid", sale.AmountPaid);
                    cmd.Parameters.AddWithValue("@payment_status", sale.PaymentStatus);
                    cmd.Parameters.AddWithValue("@invoice_number", sale.InvoiceNumber);
                    cmd.Parameters.AddWithValue("@notes", sale.Notes);
                    cmd.Parameters.AddWithValue("@payment_method", sale.PaymentMethod);

                    // ExecuteScalar retrieves the single value from the second query: the Sale ID.
                    saleId = Convert.ToInt32(cmd.ExecuteScalar());

                    // 2. Iterate through all items in the sale.
                    foreach (Sale_Item item in saleItem)
                    {
                        // Insert the sale item detail into the 'sale_items' table.
                        string detailQuery = @"INSERT INTO sale_items(sale_id, product_id,
                                        quantity, unit_price, discount, tax, total) VALUES 
                                        (@saleId, @productId, @quantity, @unitPrice, @discount, @tax, @total);";
                        MySqlCommand detailCmd = new MySqlCommand(detailQuery, conn, transaction);
                        // Use the Sale ID retrieved in step 1 to link the item.
                        detailCmd.Parameters.AddWithValue("@saleId", saleId);
                        detailCmd.Parameters.AddWithValue("@productId", item.ProductId);
                        detailCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        detailCmd.Parameters.AddWithValue("@unitPrice", item.UnitPrice);
                        detailCmd.Parameters.AddWithValue("@discount", item.Discount);
                        detailCmd.Parameters.AddWithValue("@tax", item.Tax);
                        detailCmd.Parameters.AddWithValue("@total", item.Total);
                        detailCmd.ExecuteNonQuery();

                        // Deduct stock
                        string stockQuery = @"UPDATE stock SET quantity = quantity - @qty 
                                              WHERE product_id = @product_id;";
                        MySqlCommand stockCmd = new MySqlCommand(stockQuery, conn, transaction);
                        stockCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        stockCmd.Parameters.AddWithValue("@product_id", item.ProductId);
                        stockCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return saleId;
                }
                catch (Exception ex)
                {
                    // If any error occurs (e.g., failed insert, stock deduction error), roll back all changes.
                    transaction.Rollback();
                    MessageBox.Show("Error during sale insert: " + ex.Message);
                }
                  
            }

            return -1;
        }
    }

}



    
