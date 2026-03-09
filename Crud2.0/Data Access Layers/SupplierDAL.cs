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
    public class SupplierDAL
    {
        /// Data Access Layer for handling CRUD operations on Suppliers table.
        /// Provides methods to retrieve, insert, update, and delete suppliers in the database.
        public static DataTable GetAll()
        {
            /// Retrieves all suppliers from the database.
            /// returns a DataTable containing all supplier records.
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM suppliers";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                // Fill DataTable with results
                da.Fill(dt);
            }
            return dt;
        }

        /// Inserts a new supplier into the database.
        public static void Insert(Supplier supplier)// Supplier object containing details to be inserted
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO suppliers (name, contact, email, address) VALUES (@name, @contact, @email, @address)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", supplier.Name);
                cmd.Parameters.AddWithValue("@contact", supplier.Contact);
                cmd.Parameters.AddWithValue("@email", supplier.Email);
                cmd.Parameters.AddWithValue("@address", supplier.Address);
                cmd.ExecuteNonQuery();
            }
        }

        /// Updates an existing supplier record.
        public static void Update(Supplier supplier)//Supplier object containing updated details (must include SupplierId)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE suppliers SET name=@name, contact=@contact, email=@email, address=@address WHERE supplier_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@name", supplier.Name);
                cmd.Parameters.AddWithValue("@contact", supplier.Contact);
                cmd.Parameters.AddWithValue("@email", supplier.Email);
                cmd.Parameters.AddWithValue("@address", supplier.Address);
                cmd.ExecuteNonQuery();
            }
        }
        // Deletes a supplier from the database.
        public static void Delete(int id)// SupplierId of the supplier to be deleted.
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM suppliers WHERE supplier_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
