using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    internal class StockDAL
    {
        /// Retrieves all stock records, including product name and barcode, with optional search.
        public static DataTable GetAllStock(string search = "")
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // SQL to join stock with products for comprehensive view, filtered by search
                string sql = @"SELECT 
                                s.product_id,
                                p.name AS product_name, p.barcode,
                                s.quantity, s.reorder_level, s.total_bought
                               FROM stock s
                               JOIN products p ON s.product_id = p.product_id
                               WHERE p.name LIKE @search OR p.barcode LIKE @search";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", $"%{search}%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //conn.Close();
            }
            return dt;
        }
        /// Ensures all products have an associated stock record.
        /// Creates default stock entries for any missing products.
        public static void EnsureStock()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Find products missing from stock
                    string query = @"
                SELECT p.product_id 
                FROM products p
                LEFT JOIN stock s ON p.product_id = s.product_id
                WHERE s.product_id IS NULL;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<int> missingProductIds = new List<int>();

                        while (reader.Read())
                        {
                            missingProductIds.Add(reader.GetInt32("product_id"));
                        }
                        reader.Close();

                        // Insert default stock rows for missing products
                        foreach (int productId in missingProductIds)
                        {
                            string insertQuery = @"
                        INSERT INTO stock (product_id, quantity, reorder_level, total_bought)
                        VALUES (@product_id, 0, 5, 0);";

                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@product_id", productId);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        if (missingProductIds.Count > 0)
                        {
                            MessageBox.Show($"{missingProductIds.Count} stock records created for products without stock.",
                                            "Stock Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ensuring stock records: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Adds a specified quantity to an existing product's stock and updates total products bought.
        public static void AddStock(Stock stock)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE stock SET quantity = quantity + @qty, total_bought = total_bought + @total_bought WHERE product_id = @pid";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@qty", stock.Quantity);
                    cmd.Parameters.AddWithValue("@total_bought", stock.TotalProductsBought);
                    cmd.Parameters.AddWithValue("@pid", stock.ProductID);
                    cmd.ExecuteNonQuery();
                    //conn.Close();
                }

                MessageBox.Show("Stock added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not Add stock " + ex.Message);
            }
        }
        /// Changes the reorder level for a specific product.
        public static void ChangeReOrderLevel(Stock stock)
        {
            try 
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                            {
                                conn.Open();
                                string sql = "UPDATE stock SET reorder_level=@reorder_level WHERE product_id = @pid";
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@reorder_level", stock.ReorderLevel);
                                cmd.Parameters.AddWithValue("@pid", stock.ProductID);
                                cmd.ExecuteNonQuery();
                            }

                 MessageBox.Show("Reorder level updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not change ReOrder level "+ ex.Message);
            }
        }
        /// Sets the exact quantity of stock for a given product ID.
        public static void SetQuantity(int productId, int qty)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE stock SET quantity = @qty WHERE product_id = @pid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@pid", productId);
                cmd.ExecuteNonQuery();
                //conn.Close();
            }
        }
        public static bool DeductStock(DataTable cartTable)
        {
            bool isSuccess = true;

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    foreach (DataRow row in cartTable.Rows)
                    {
                        int productId = Convert.ToInt32(row["ProductID"]);
                        int qtySold = Convert.ToInt32(row["Quantity"]);

                        // SQL to deduct stock, with a crucial WHERE clause to prevent negative stock.
                        // The update only happens if 'quantity' is greater than or equal to 'qtySold'.
                        string sql = "UPDATE stock SET quantity = quantity - @qtySold WHERE product_id = @productId AND quantity >= @qtySold";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@qtySold", qtySold);
                            cmd.Parameters.AddWithValue("@productId", productId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            // If no row is updated, it means there is not enough stock
                            if (rowsAffected == 0)
                            {
                                throw new Exception($"Insufficient stock for Product ID: {productId}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deducting stock: " + ex.Message);
                    isSuccess = false;
                }
            }

            return isSuccess;
        }
        /// Records a stock adjustment (e.g., spoilage, inventory correction) and updates actual stock.
        public static void AddAdjustment(Stock_Adjustment stock_Adjust)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                int productId = stock_Adjust.productId;
                int qtyChange = stock_Adjust.quantityChanged;
                string reason = stock_Adjust.reason;
                int userId = stock_Adjust.userId;

                //Insert a record into the 'stock_adjustments' log table.
                string insertSql = "INSERT INTO stock_adjustments (product_id, quantity_changed, reason, date, user_id) VALUES (@pid, @qty, @reason, @date, @userId)";
                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@qty", qtyChange);
                    cmd.Parameters.AddWithValue("@date", stock_Adjust.date);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }

                //  Update the actual stock quantity in the 'stock' table.
                string updateSql = "UPDATE stock SET quantity = quantity - @qty WHERE product_id = @pid";
                using (MySqlCommand cmd = new MySqlCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("@qty", qtyChange);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// Retrieves the history of stock adjustments, optionally filtered by date range.
        public static DataTable GetAdjustments(DateTime? fromDate = null, DateTime? toDate = null)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT a.adjustment_id, p.name AS product_name, a.quantity_changed, a.reason, a.date, u.username
                               FROM stock_adjustments a
                               JOIN products p ON a.product_id = p.product_id
                               JOIN users u ON a.user_id = u.user_id
                               WHERE 1=1";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (fromDate.HasValue)
                {
                    sql += " AND a.date >= @fromDate";
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    sql += " AND a.date <= @toDate";
                    cmd.Parameters.AddWithValue("@toDate", toDate.Value);
                }

                sql += " ORDER BY a.date DESC";
                cmd.CommandText = sql;

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        /// Retrieves the current stock quantity for a specific product.
        public static int GetStockQuantity(int Productid)
        {
            int stockQuantity = 0;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM stock WHERE product_id = @product_id", conn);
                    cmd.Parameters.AddWithValue("@product_id", Productid);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        stockQuantity = Convert.ToInt32(reader["quantity"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stockQuantity;
        }

    }
}
