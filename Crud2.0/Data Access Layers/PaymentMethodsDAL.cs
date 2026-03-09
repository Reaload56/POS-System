using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Data_Access_Layers
{
    public class PaymentMethodsDAL
    {
        /// Retrieves all payment methods from database.
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT payment_method_id, name FROM payment_methods", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
