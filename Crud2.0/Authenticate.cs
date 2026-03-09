using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    /// Handles user authentication, including password hashing, verification,
    /// and checking user roles and existence in the database.
    internal class Authenticate
    {       
        bool LogAsAdmin = false;
        public string Hash(string Password)
        {
            byte[] salt = new byte[32]; // Initialize byte array for salt.
            salt = Insalt(salt); // Generate random salt.
            byte[] HashedPassword = GeneratePassword(Password, salt); // Hash password with the generated salt.
            string StoragePassword = Convert.ToBase64String(HashedPassword) + ":" + Convert.ToBase64String(salt); // Combine hashed password and salt for storage.
            return StoragePassword;
        }
        /// Generates a random salt for security.
        public byte[] Insalt(byte[] salt)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create(); // Creates a strong random number generator.
            rng.GetBytes(salt); // Fills the salt array with random bytes.
            return salt;
        }
        /// Generates a hashed password using PBKDF2 with the given password and salt.
        public byte[] GeneratePassword(string Password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 1000); // Use PBKDF2 with 1000 iterations for hashing.
            return pbkdf2.GetBytes(20); // Get 20 bytes for the hashed password.
        }
        /// Verifies a plain-text password against a stored hashed password and salt.
        public bool VerifyPassword(string Password, string StoredPassword)
        {
            string[] parts = StoredPassword.Split(":");// Split the stored string into hashed password and salt parts.
            byte[] StoredP = Convert.FromBase64String(parts[0]);// Convert stored hashed password from Base64.
            byte[] salt = Convert.FromBase64String(parts[1]);

            byte[] GivenPassword = GeneratePassword(Password, salt);

            return SlowEquals(StoredP, GivenPassword);
        }
        /// Performs a "slow equals" comparison of two byte arrays to reduce timing attacks.
        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
        /// Checks if a user with the given username exists in the 'users' table.
        public bool ConfirmUser(string name)
        {
            bool exists;
            string table = "";

            if (LogAsAdmin) { table = "login  "; }
            else { table = "login"; }

            string comand = "SELECT COUNT(*) FROM users WHERE BINARY username = @User";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(comand, conn);
                cmd.Parameters.AddWithValue("@User", name);
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                exists = userCount > 0;
                //conn.Close();
            }

            return exists;
        }
        /// Checks the role of a user with the given username.
        public bool CheckRole(string name)
        {
            string role = "";
            bool IsAdmin = false;
            using (MySqlConnection conn  = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string comm = "SELECT role FROM users WHERE username = @username";// SQL to fetch the user's role.
                MySqlCommand sqlCommand = new MySqlCommand(comm, conn);
                sqlCommand.Parameters.AddWithValue("@username", name);// Execute query and get a data reader.
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    role = reader["role"].ToString();
                }
            }
            if (role == "Admin")
            {
                IsAdmin = true;
            }
            else if (role == "Cashier") 
            { IsAdmin = false; }

            // Implicitly, if role is neither "Admin" nor "Cashier", IsAdmin remains false.
            return IsAdmin;
        }
    }
}