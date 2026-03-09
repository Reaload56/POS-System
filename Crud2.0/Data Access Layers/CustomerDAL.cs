using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Crud2._0
{
    /// Data Access Layer for handling CRUD operations on Customers table.
    /// Provides methods to retrieve, insert, update, delete, and manage customer balances.
    public class CustomerDAL
    {
        
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM customers";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding Customer " + ex.Message);
            }
            return dt;
        }
        public static void EnsureDefaultCustomer()
        {
            // Check if Default Customer exists
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    
                    string checkSql = "SELECT COUNT(*) FROM customers WHERE customer_type = 'Default Customer'";//query to select default user if they exist
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        // Insert default customer
                        string query = @"INSERT INTO customers 
                                    (full_name, phone, email, address, credit, pay_back_date, customer_type)
                                    VALUES ('Default Customer', '', '', '', 0, NULL, 'Default Customer')";
                        MySqlCommand insertCmd = new MySqlCommand(query, conn);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring default customer: " + ex.Message);
            }
        }
        /// <summary>
        /// Inserts a new customer into the database.
        /// </summary>
        /// <param name="c"></param>
        public static void Insert(Customer c)
        {
            try 
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO customers (full_name, customerType, phone, email, address, balance, pay_back_date)
                    VALUES (@name, @customerType, @phone, @email, @address, @balance, @pay_back_date)";//query to insert customer

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", c.FullName);
                    cmd.Parameters.AddWithValue("@phone", c.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@address", c.Address);
                    cmd.Parameters.AddWithValue("@balance", c.Balance);
                    cmd.Parameters.AddWithValue("customerType", c.CustomerType);
                    if (c.PayBackDate == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@pay_back_date", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@pay_back_date", c.PayBackDate);
                    cmd.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Adding Customer "+ex.Message);
            }

        }
        /// <summary>
        /// Updates an existing customer record.
        /// </summary>
        /// <param name="c"></param>
        public static void Update(Customer c)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE customers SET 
                                full_name = @name,
                                customerType = @customerType,
                                phone = @phone,
                                email = @email,
                                address = @address
                                WHERE customer_id = @id";//quety to update customer

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", c.FullName);
                    cmd.Parameters.AddWithValue("@phone", c.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@address", c.Address);
                    cmd.Parameters.AddWithValue("customerType", c.CustomerType);
                    if (c.PayBackDate == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@pay_back_date", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@pay_back_date", c.PayBackDate);

                    cmd.Parameters.AddWithValue("@id", c.CustomerId);

                    cmd.ExecuteNonQuery();//command to execute query is performed

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Customer " + ex.Message);
            }
            
        }
        /// <summary>
        /// Updates the balance of a specific customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="cred"></param>
        public static void UpdateCustomerbalance(int customerId, decimal cred)
        {
            decimal balance = cred;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE customers SET balance = @balance WHERE customer_id = @id", conn);
                    command.Parameters.AddWithValue("@balance", balance);
                    command.Parameters.AddWithValue("@id", customerId);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Customer Balance " + ex.Message);
            }

        }
        /// <summary>
        /// Deletes a customer from the database based on customer id.
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM customers WHERE customer_id = @id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting Customer " + ex.Message);
            }
        }
        /// <summary>
        /// Retrieves the information on what type of customer of a specific customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static string GetCustomerType(int customerId)
        {
            string type = "";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT customertype FROM customers WHERE customer_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        type = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding Customer " + ex.Message);
            }
            return type;
        }

        /// <summary>
        /// Retrieves the balance of a specific customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static decimal GetBalance(int customerId)
        {
            decimal balance = 0;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string sql = "SELECT balance FROM customers WHERE customer_id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    balance = Convert.ToDecimal(result);
            }
            return balance;
        }

    }
}
