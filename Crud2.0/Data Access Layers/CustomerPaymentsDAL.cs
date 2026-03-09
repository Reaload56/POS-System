using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Data_Access_Layers
{
    public class CustomerPaymentsDAL
    {
        /// <summary>
        /// saves customer payment details when customer pays back money owed 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="amount"></param>
        /// <param name="method"></param>
        /// <param name="referenceNo"></param>
        /// <param name="notes"></param>
        public static void AddPayment(int customerId, decimal amount, string method, string referenceNo, string notes = "")
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert payment record
                        string insertSql = @"INSERT INTO customer_payments 
                                            (customer_id, amount, payment_method, reference_no, notes) 
                                            VALUES (@cid, @amount, @method, @ref, @notes)";
                        using (MySqlCommand cmd = new MySqlCommand(insertSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@method", method);
                            cmd.Parameters.AddWithValue("@ref", referenceNo);
                            cmd.Parameters.AddWithValue("@notes", notes);
                            cmd.ExecuteNonQuery();
                        }

                        //  Update customer's balance (reduce balance)
                        string updateSql = "UPDATE customers SET balance = balance - @amount WHERE customer_id = @cid";
                        using (MySqlCommand cmd = new MySqlCommand(updateSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error adding payment: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Get all payments for a specific customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static DataTable GetPayments(int customerId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT payment_id, amount, payment_date, payment_method, reference_no, notes
                               FROM customer_payments
                               WHERE customer_id = @cid
                               ORDER BY payment_date DESC";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", customerId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
