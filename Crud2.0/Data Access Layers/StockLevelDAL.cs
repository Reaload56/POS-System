using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{

    internal class StockLevelDAL
    {
        public static void CheckStock()
        {
            try
            {
                List<Stock> stocks = new List<Stock>();
                List<Product> OutOfStockproducts = new List<Product>();

                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM stock", conn);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Stock stock = new Stock();
                        stock.ProductID = Convert.ToInt32(reader[""]);
                        stock.ProductName = reader[""].ToString();
                        stock.Quantity = Convert.ToInt32(reader[""]);
                        stock.ReorderLevel = Convert.ToInt32(reader[""]);
                        stocks.Add(stock);
                    }
                    conn.Close();
                }

                foreach (Stock stockItem in stocks)
                {
                    Product product = new Product();
                    if (stockItem.Quantity <= stockItem.ReorderLevel)
                    {
                        using (MySqlConnection conn = DatabaseConnection.GetConnection())
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT * products WHERE product_id = @product_id", conn);
                            cmd.Parameters.AddWithValue("@product_id", stockItem.ProductID);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            while(reader.Read())
                            {
                                product.ProductID = Convert.ToInt32(reader["product_id"]);
                                product.Name = reader["name"].ToString();

                            }
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
