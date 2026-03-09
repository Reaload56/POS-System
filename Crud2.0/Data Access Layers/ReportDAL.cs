using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Data_Access_Layers
{
    public class ReportDAL
    {
        /// <summary>
        /// obtains customer balances
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCustomerBalances()
        {
            string query = "SELECT customer_id, full_name, balance FROM customers;";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// Retrieves all sales or sales depending on specified dates.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static DataTable GetTransactionHistory(DateTime? fromDate, DateTime? toDate)
        {

                string query = @"
                    SELECT s.sale_id, s.invoice_number, s.sale_date, c.full_name AS customer_name,
                    u.username AS user_name, s.global_discount,
                    s.total_amount, s.payment_status, s.change_given, 
                    s.notes, s.payment_method
                    FROM sales s INNER JOIN customers c ON s.customer_id = c.customer_id 
                    INNER JOIN users u ON s.user_id = u.user_id
                    WHERE 1=1";

            var parameters = new List<MySqlParameter>();

            if (fromDate.HasValue)
            {
                query += " AND s.sale_date >= @fromDate";
                parameters.Add(new MySqlParameter("@fromDate", fromDate.Value));
            }

            if (toDate.HasValue)
            {
                query += " AND s.sale_date <= @toDate";
                parameters.Add(new MySqlParameter("@toDate", toDate.Value));
            }

            query += " ORDER BY s.sale_date DESC";

            return ExecuteQuery(query, parameters.ToArray());
        }


        /// <summary>
        /// This reports on amount of money owed to customers and the amount customers owe the business
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCreditDebtSummary()
        {
            string query = @"
                SELECT 
                    SUM(CASE WHEN balance > 0 THEN balance ELSE 0 END) AS total_debt,
                    SUM(CASE WHEN balance < 0 THEN ABS(balance) ELSE 0 END) AS total_credit
                FROM customers;";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// this retrives all the products and the level of stock each of them has
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInventoryLevels()
        {
            string query = "SELECT p.product_id , p.name, s.quantity FROM products p INNER JOIN stock s ON p.product_id = s.product_id;";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// obtains all products that need to be restocked due to low levels
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLowStockWarnings()
        {
            string query = @"SELECT p.product_id, p.name, s.quantity, 
                        s.reorder_level FROM products p INNER JOIN stock s 
                        ON p.product_id = s.product_id WHERE quantity < reorder_level;";
            
            return ExecuteQuery(query);
        }

        /// <summary>
        /// shows what the total cost of the products is and allows the user to compare it to the selling price
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInventoryValuation()
        {
            string query = @"
                SELECT 
                    SUM(s.quantity * p.cost_price) AS total_cost_value,
                    SUM(s.quantity * p.selling_price) AS total_retail_value
                FROM products p INNER JOIN stock s 
                        ON p.product_id = s.product_id;";
            return ExecuteQuery(query);
        }

        /// <summary>
        /// calculates the profits and losses the business has made within a specific time period
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static DataTable GetProfitAndLoss(DateTime? fromDate, DateTime? toDate)
        {
            string query = @"
                SELECT 
                    DATE(s.sale_date) AS sale_date,
                    SUM(s.total_amount) AS total_sales,
                    SUM(si.quantity * p.cost_price) AS total_cost,
                    (SUM(s.total_amount) - SUM(si.quantity * p.cost_price)) AS profit
                FROM sales s
                INNER JOIN sale_items si ON s.sale_id = si.sale_id
                INNER JOIN products p ON si.product_id = p.product_id
                WHERE 1=1";

            var parameters = new List<MySqlParameter>();

            if (fromDate.HasValue)
            {
                query += " AND s.sale_date >= @fromDate";
                parameters.Add(new MySqlParameter("@fromDate", fromDate.Value));  //addes a specific parameter of the date from where to start the search to the query
            }

            if (toDate.HasValue)
            {
                query += " AND s.sale_date <= @toDate";
                parameters.Add(new MySqlParameter("@toDate", toDate.Value)); //addes a specific parameter of the date from where to end the search to the query
            }

            query += " GROUP BY DATE(s.sale_date) ORDER BY s.sale_date";

            return ExecuteQuery(query, parameters.ToArray());
        }
        /// <summary>
        /// Obtains a summary of all sales that have been performed within a specific range
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static DataTable GetSalesSummary(DateTime? fromDate, DateTime? toDate)
        {
            string query = @"
                SELECT 
                    COUNT(*) AS total_transactions,
                    SUM(total_amount) AS total_sales
                FROM sales
                WHERE 1=1";

            var parameters = new System.Collections.Generic.List<MySqlParameter>();

            if (fromDate.HasValue)
            {
                query += " AND sale_date >= @fromDate";
                parameters.Add(new MySqlParameter("@fromDate", fromDate.Value));
            }

            if (toDate.HasValue)
            {
                query += " AND sale_date <= @toDate";
                parameters.Add(new MySqlParameter("@toDate", toDate.Value));
            }

            return ExecuteQuery(query, parameters.ToArray());
        }
        /// <summary>
        /// Retrieves all low stock products from the database.
        /// </summary>
        /// <returns></returns>
        public static bool HasLowStock()
        {
            string query = @"SELECT COUNT(*) 
                             FROM products p 
                             INNER JOIN stock s ON p.product_id = s.product_id 
                             WHERE s.quantity < s.reorder_level;";

            DataTable resultTable = ExecuteQuery(query);
            if (resultTable.Rows.Count > 0)
            {
                int count = Convert.ToInt32(resultTable.Rows[0][0]);
                return count > 0;
            }
            return false;
        }
        /// <summary>
        /// since all methods use datatables one method has been created to perform database operations
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ... " + ex.Message);
            }
            return dt;
        }
    }

}

