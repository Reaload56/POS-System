using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    
    internal static class DatabaseConnection
    {
        // Static method that returns an open MySqlConnection
        public static MySqlConnection GetConnection()
        {
            string connStr = "server=localhost;user=root;password=;database=pos";
            var conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
