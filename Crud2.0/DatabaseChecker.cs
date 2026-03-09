using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Crud2._0
{
    //Class for making sure database, tables and default values exist in the database
    public class DatabaseChecker
    {
        private readonly string _databaseName = "pos";
        private static string _xamppPath;

        //checks if (DBMS)Data Base Management System software is installed
        public static void DatabaseManager()
        {
            // Detects XAMPP folder 
            if (Directory.Exists(@"C:\xampp"))
                _xamppPath = @"C:\xampp";
            else if (Directory.Exists(@"D:\xampp"))
                _xamppPath = @"D:\xampp";
            else
                _xamppPath = null;
        }
         
        public static bool InitializeDatabase()
        {
            DatabaseManager();
            if (_xamppPath == null)
            {
                MessageBox.Show("XAMPP not found. Please install it to use this system.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//if DBMS doesn't exist it prompts user to download the software
                Process.Start("https://www.apachefriends.org/download.html");
                return false;
            }

            //attempts to connect to the database
            bool isConnected = false;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    isConnected = true;
                }
                catch
                {
                    MessageBox.Show("Could not connect. Attempting to start Apache/MySQL...",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if connection fails
                    StartServers();//it starts xampp servers "Apache and MySql"
                    System.Threading.Thread.Sleep(5000);//slows program down to give servers time to start

                    try
                    {
                        conn.Open();
                        isConnected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to connect: {ex.Message}",
                            "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            if (isConnected)
                CheckAndCreateTables();

            return true;
        }
        //method to start mysql servers 
        private static void StartServers()
        {
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = _xamppPath,
                UseShellExecute = false, // Must be false to set WindowStyle
                CreateNoWindow = true    // This is the key line
            };

            if (File.Exists(Path.Combine(_xamppPath, "apache_start.bat")))
            {
                startInfo.FileName = Path.Combine(_xamppPath, "apache_start.bat");
                Process.Start(startInfo); // starts apache server using file location
            }

            if (File.Exists(Path.Combine(_xamppPath, "mysql_start.bat")))
            {
                startInfo.FileName = Path.Combine(_xamppPath, "mysql_start.bat");
                Process.Start(startInfo);// starts mysql server using file location
            }
        }
        //method to check if tables required by application exist
        public static void CheckAndCreateTables()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    string[] tableScripts =
                    {
                        @"CREATE TABLE IF NOT EXISTS categories (
                            category_id INT AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(100) NOT NULL,
                            description VARCHAR(255)
                        );",//checks if categories table exists in database

                        @"CREATE TABLE IF NOT EXISTS suppliers (
                            supplier_id INT AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(100) NOT NULL,
                            contact VARCHAR(50),
                            email VARCHAR(100),
                            address VARCHAR(255),
                            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        );",//checks if suppliers table exists in database

                        @"CREATE TABLE IF NOT EXISTS products (
                            product_id INT AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(150) NOT NULL,
                            barcode VARCHAR(50) UNIQUE,
                            category_id INT,
                            description VARCHAR(255),
                            cost_price DECIMAL(10,2),
                            selling_price DECIMAL(10,2),
                            tax_rate DECIMAL(5,2) DEFAULT 0.00,
                            discount DECIMAL(5,2) DEFAULT 0.00,
                            is_service BOOLEAN DEFAULT FALSE,
                            supplier_id INT NULL,
                            FOREIGN KEY (category_id) REFERENCES categories(category_id),
                            FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id)
                        );",//checks if products table exists in database

                        @"CREATE TABLE IF NOT EXISTS stock (
                            stock_id INT AUTO_INCREMENT PRIMARY KEY,
                            product_id INT,
                            quantity INT NOT NULL DEFAULT 0,
                            reorder_level INT DEFAULT 5,
                            total_bought INT DEFAULT 0,
                            FOREIGN KEY (product_id) REFERENCES products(product_id)
                        );",//checks if stock table exists in database

                        @"CREATE TABLE IF NOT EXISTS customers (
                        customer_id INT AUTO_INCREMENT PRIMARY KEY,
                        full_name VARCHAR(150) NOT NULL,
                        customerType VARCHAR(50) NOT NULL,
                        phone VARCHAR(50),
                        email VARCHAR(100),
                        address VARCHAR(255),
                        balance DECIMAL(10,2) DEFAULT 0.00,
                        paid_back_date DATE,
                        UNIQUE (full_name, customerType) -- prevent duplicates
                        );",//checks if customers table exists in database

                        @"INSERT IGNORE INTO customers 
                         (full_name, phone, email, address, balance, pay_back_date, customerType)
                         VALUES ('Default Customer', '', '', '', 0, NULL, 'Default Customer')
                         ;",//checks if default customer exist

                        @"CREATE TABLE IF NOT EXISTS users (
                            user_id INT AUTO_INCREMENT PRIMARY KEY,
                            username VARCHAR(100),
                            address VARCHAR(80),
                            email VARCHAR(50),
                            password_hash VARCHAR(256),
                            role VARCHAR(50),
                            full_name VARCHAR(150)
                        );",//checks if users table exists in database

                        @"CREATE TABLE IF NOT EXISTS sales (
                            sale_id INT AUTO_INCREMENT PRIMARY KEY,
                            sale_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            customer_id INT,
                            user_id INT,
                            global_discount DECIMAL(10,2) DEFAULT 0.00,
                            total_amount DECIMAL(10,2),
                            net_amount DECIMAL(10,2),
                            amount_paid DECIMAL(10,2),
                            payment_status VARCHAR(50) DEFAULT 'Paid',
                            change_given DECIMAL(10,2) DEFAULT 0.00,
                            invoice_number VARCHAR(80),
                            notes TEXT,
                            payment_method_id INT ,
                            FOREIGN KEY (payment_method_id) REFERENCES payment_methods(payment_method_id),
                            FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
                            FOREIGN KEY (user_id) REFERENCES users(user_id)
                        );",//checks if sales table exists in database

                        @"CREATE TABLE IF NOT EXISTS sale_items (
                            sale_item_id INT AUTO_INCREMENT PRIMARY KEY,
                            sale_id INT,
                            product_id INT,
                            quantity INT,
                            unit_price DECIMAL(10,2),
                            discount DECIMAL(10,2) DEFAULT 0.00,
                            tax DECIMAL(10,2) DEFAULT 0.00,
                            total DECIMAL(10,2),
                            FOREIGN KEY (sale_id) REFERENCES sales(sale_id),
                            FOREIGN KEY (product_id) REFERENCES products(product_id)
                        );",//checks if sale_items table exists in database

                        @"CREATE TABLE IF NOT EXISTS customer_payments (
                            payment_id INT AUTO_INCREMENT PRIMARY KEY,
                            customer_id INT,
                            payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            amount DECIMAL(10,2),
                            payment_type ENUM('Credit', 'Debt') NOT NULL,
                            notes TEXT,
                            FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
                        );",//checks if customer_payments table exists in database

                        @"CREATE TABLE IF NOT EXISTS receipt_config (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            store_name VARCHAR(100) DEFAULT 'MyShop',
                            header VARCHAR(100) DEFAULT 'RECEIPT',
                            logo_path VARCHAR(255),
                            show_item_name TINYINT(1) DEFAULT 1,
                            show_price TINYINT(1) DEFAULT 1,
                            show_quantity TINYINT(1) DEFAULT 1,
                            show_total TINYINT(1) DEFAULT 1,
                            show_discount TINYINT(1) DEFAULT 1,
                            show_tax TINYINT(1) DEFAULT 1,
                            show_barcode TINYINT(1) DEFAULT 0,
                            footer_message VARCHAR(255) DEFAULT 'Thank you for shopping with us'
                        );

                        ",//checks if receipt_config table exists in database

                        @"CREATE TABLE IF NOT EXISTS payment_methods (
                        payment_method_id INT AUTO_INCREMENT PRIMARY KEY,
                        name VARCHAR(100) NOT NULL,
                        description VARCHAR(255)
                        );",//checks if payment_methods table exists in database

                        @"INSERT IGNORE INTO payment_methods (name, description) VALUES
                        ('Cash', 'Default payment method'),
                        ('Card', 'Debit/Credit card');",//checks if default values for payment_methods exist

                        @"CREATE TABLE IF NOT EXISTS stock_adjustments (
                            adjustment_id INT AUTO_INCREMENT PRIMARY KEY,
                            product_id INT,
                            quantity_changed INT,
                            reason VARCHAR (100),
                            date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            user_id INT,
                            FOREIGN KEY (product_id) REFERENCES products(product_id),
                            FOREIGN KEY (user_id) REFERENCES users(user_id)
                        );",//checks if stock_adjustments table exists in database
                    };

                    foreach (string script in tableScripts)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(script, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating tables: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
