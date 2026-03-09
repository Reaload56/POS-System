using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Crud2._0
{
    internal class PaymentMethods
    {
        //data access layer for inserting payment methods
        public static void setPaymentMethod (string name)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection() )
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO payment_methods ( name) VALUES @name", conn);
                    cmd.Parameters.AddWithValue("@name",name);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message);
            }
        }
        //obtains all data on customer payments
        public static DataTable getAll()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM payment_methods", conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        //deletes specific payment method data
        public static void Delete(int  id)
        {
            try 
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM payment_methods WHERE method_Id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
