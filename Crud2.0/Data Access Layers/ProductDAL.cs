using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    public class ProductDAL
    {

        /// Data Access Layer for handling operations on Products table.
        public static DataTable GetAll() 
        {
            DataTable dataTable = new DataTable();
            try
            {
                
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"SELECT p.product_id, p.name AS product_name ,
                                                        p.barcode, c.name AS category_name ,c.category_id, p.description,
                                                        p.cost_price, p.selling_price, p.tax_rate, p.discount,
                                                        p.is_service, p.supplier_id, s.name AS supplier_name 
                                                        FROM products p JOIN categories c on 
                                                        p.category_id = c.category_id LEFT JOIN suppliers s 
                                                        on p.supplier_id = s.supplier_id", conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable;
        }

        /// Retrieves all products from the database for the Point of Sale form.
        public static DataTable LoadProducts()
        {
            DataTable productTable = new DataTable();
            try
            { 
                
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"SELECT p.product_id, p.name, p.barcode, s.quantity, p.selling_price,
                                                p.tax_rate, p.discount FROM stock s INNER JOIN products p ON s.product_id = p.product_id", conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(productTable);
                    }
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
            return productTable;
        }
        /// <summary>
        /// Inserts a new product into the database.
        /// </summary>
        /// <param name="p"></param>
        public static void Insert(Product p)
        {
            try
            {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO products(name, barcode, category_id , description, cost_price, selling_price, tax_rate, discount, is_service, supplier_id) VALUES (@name,@bar,@cate,@descr,@costp,@sellp,@tax,@discount,@isSer,@supp)", conn);
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@bar", p.Barcode);
                    cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                    cmd.Parameters.AddWithValue("@descr", p.Description);
                    cmd.Parameters.AddWithValue("@costp", p.CostPrice);
                    cmd.Parameters.AddWithValue("@sellp", p.SellingPrice);
                    cmd.Parameters.AddWithValue("@tax", p.TaxRate);
                    cmd.Parameters.AddWithValue("@discount", p.Discount);
                    cmd.Parameters.AddWithValue("@isSer", p.IsService);
                    cmd.Parameters.AddWithValue("@supp", p.SupplierID);
                    cmd.ExecuteNonQuery();
                    long newProductId = cmd.LastInsertedId;

                    MySqlCommand cmd2 = new MySqlCommand(
                        "INSERT INTO stock (product_id, quantity, reorder_level, total_bought) " +
                        "VALUES (@product_id, @quantity, @reorder_level, @total_bought)", conn);

                    cmd2.Parameters.AddWithValue("@product_id", newProductId);
                    cmd2.Parameters.AddWithValue("@quantity", 0);
                    cmd2.Parameters.AddWithValue("@reorder_level", 5);
                    cmd2.Parameters.AddWithValue("@total_bought", 0);
                    cmd2.ExecuteNonQuery();
                }
                MessageBox.Show("Product added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="p"></param>
        public static void Update(Product p)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE products SET name=@name, barcode=@bar, category_id=@cate, description=@descr, cost_price=@costp, selling_price=@sellp, tax_rate=@tax, discount=@discount, is_service=@isSer, supplier_id=@supp WHERE product_id=@id ", conn);
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@bar", p.Barcode);
                    cmd.Parameters.AddWithValue("@cate", p.CategoryID);
                    cmd.Parameters.AddWithValue("@descr", p.Description);
                    cmd.Parameters.AddWithValue("@costp", p.CostPrice);
                    cmd.Parameters.AddWithValue("@sellp", p.SellingPrice);
                    cmd.Parameters.AddWithValue("@tax", p.TaxRate);
                    cmd.Parameters.AddWithValue("@discount", p.Discount);
                    cmd.Parameters.AddWithValue("@isSer", p.IsService);
                    cmd.Parameters.AddWithValue("@id", p.ProductID);
                    cmd.Parameters.AddWithValue("@supp", p.SupplierID);
                    cmd.ExecuteNonQuery();
                
                }
                MessageBox.Show("Product updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Deletes a specific product from the database.
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmdStock = new MySqlCommand("DELETE FROM stock WHERE product_id=@id", conn);
                    cmdStock.Parameters.AddWithValue("@id", id);
                    cmdStock.ExecuteNonQuery();

                    MySqlCommand cmdProduct = new MySqlCommand("DELETE FROM products WHERE product_id=@id", conn);
                    cmdProduct.Parameters.AddWithValue("@id", id);
                    cmdProduct.ExecuteNonQuery();

                }
                MessageBox.Show("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Retrieves a specific product by the product name
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static DataTable Find (string product)
        {
            DataTable dt = new DataTable();
            try 
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(@"SELECT p.product_id, p.name, p.barcode, s.quantity, p.selling_price,
                      p.tax_rate, p.discount 
                      FROM products p
                      INNER JOIN stock s ON p.product_id = s.product_id
                      WHERE p.product_id LIKE @product OR p.name LIKE @product 
                                 OR p.barcode = @exactproduct                
                        ", conn);
                    cmd.Parameters.AddWithValue("@exactproduct", product);
                    cmd.Parameters.AddWithValue("@product", $"%{product}%");
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        /// Gets the unit price of a product by its ID.
        /// The ID of the product The unit price as a decimal. Returns 0 if not found
        public static decimal GetPrice(int productId)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT unit_price FROM products WHERE product_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }
    }
}
