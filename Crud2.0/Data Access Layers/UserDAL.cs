using Crud2._0.Models;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Data_Access_Layers
{
    /// Data Access Layer for managing user data in the database.
    public class UserDAL
    {
        /// <summary>
        /// Retrieves all user records from the 'users' table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();

            try
            {
                using(MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", conn);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }
        /// <summary>
        /// Inserts a new user record into the 'users' table.
        /// </summary>
        /// <param name="user_"></param>
        public static void InsertUser(User_ user_)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string comand = "INSERT INTO  users (username, address, email, password_hash, role, full_name) VALUES (@User, @Address, @Email, @Password, @Role, @Full_name )";
                    MySqlCommand cmd = new MySqlCommand(comand, conn);
                    cmd.Parameters.AddWithValue("@User", user_.UserName);//replaces @user with the actual username
                    cmd.Parameters.AddWithValue("@Address", user_.Address);
                    cmd.Parameters.AddWithValue("@Email", user_.Email);
                    cmd.Parameters.AddWithValue("@Password", user_.Password);
                    cmd.Parameters.AddWithValue("@Role", user_.Role);
                    cmd.Parameters.AddWithValue("@Full_name", user_.FullName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Deletes a user record from the 'users' table after user confirmation.
        public static void DeleteUser(int UserId)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete this user? ",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                        );// message box with buttons for confirming if user is to be deleted or not
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE user_id = @UserId", conn);

                        cmd.Parameters.AddWithValue("user_id", UserId);

                    }
                    MessageBox.Show("User Deleted Successfuly");
                }
                else
                {

                    MessageBox.Show("Deletion cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Updates an existing user record in the 'users' table.
        public static void UpdateUser(User_ user)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE users SET username= @username, address= @address, email= @email, password_hash= @password, role= @role, full_name= @full_name WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@full_name", user.FullName);
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Updated Successfuly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
