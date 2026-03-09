using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    public class CategoryDAL
    {
        /// Retrieves all Product categories.
        public static DataTable GetAll()
        {
            DataTable dataTable = new DataTable();
            try
            {
                // The 'using' statement ensures the connection is automatically closed and disposed.
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM categories", conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Categories");
            }
            return dataTable;
        }
        /// Inserts a new category into the database.
        public static void Insert(Category c)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO categories (name, description) VALUES (@n, @d)", conn);
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.Parameters.AddWithValue("@d", c.Description);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding Category");
            }
        }
        /// Updates an existing category record.
        public static void Update(Category c)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE categories SET name=@n, description=@d WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.Parameters.AddWithValue("@d", c.Description);
                    cmd.Parameters.AddWithValue("@id", c.CategoryID);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Category");
            }
        }
        /// Deletes a category from the database.
        public static void Delete(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id); 
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting Category");
            }
        }
    }

}
