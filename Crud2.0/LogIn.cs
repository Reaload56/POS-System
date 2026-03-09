using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crud2._0.Data_Access_Layers;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;


namespace Crud2._0
{
    public partial class LogIn : Form
    {
        Authenticate authenticate = new Authenticate();
        private bool isDragging = false;
        private Point lastCursorPosition;

        public LogIn()
        {
            InitializeComponent();

        }
        //method to check if there are any users in the users table
        private int checkusers()
        {
            int rows;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM users", conn))
                {
                    object rowCount = command.ExecuteScalar();
                    rows = Convert.ToInt32(rowCount);
                }
            }

            return rows;
        }
        //Login click event
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            int UserId = -1;
            string Password = txtPassword.Text;
            string StoredPassword = "";
            bool exist = false;
            bool is_Admin = false;

            if (Password == string.Empty) //checks if password has been entered
            {
                MessageBox.Show("Please enter your password");
                return;//exits if no password has been entered
            }
            if (txtName.Text == string.Empty)//checks if username has been entered
            {
                MessageBox.Show("Please enter your User name");
                return;//exits if no username has been entered
            }

            using (var connect = DatabaseConnection.GetConnection())
            {
                string User = txtName.Text;
                User = User.Trim();
                try
                {
                    exist = authenticate.ConfirmUser(User);//confirms if username entered exists in the database
                    if (exist)
                    {
                        is_Admin = authenticate.CheckRole(User);
                        connect.Open();
                        if (connect.State == System.Data.ConnectionState.Open)
                        {
                            string comand = "Select password_hash, user_id FROM users Where BINARY username =@Username";//query for obtainig specific user data
                            MySqlCommand command = new MySqlCommand(comand, connect);
                            command.Parameters.AddWithValue("@Username", User);

                            MySqlDataReader ree = command.ExecuteReader();
                            if (ree.Read())
                            {
                                StoredPassword = ree["password_hash"].ToString();//retrieves specific user's password hash
                                UserId = Convert.ToInt32(ree["user_id"]);//retrieves user's user id
                            }
                        }
                        else
                        {
                            MessageBox.Show("Connection Fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User With That Name Does Not Exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connect.Close();
                }
                if (exist)
                {
                    bool pass = authenticate.VerifyPassword(Password, StoredPassword);

                    if (pass)
                    {
                        bool lowStock = ReportDAL.HasLowStock();
                        if (is_Admin)
                        {
                            connect.Close();
                            MiddleManClass.SetUser(User, UserId, is_Admin);//sets user data into global helper
                            Dashboard Dashboard = new Dashboard(lowStock);
                            Dashboard.ShowDialog();//logs in Admin user into dashboard
                        }
                        else
                        {
                            connect.Close();
                            MiddleManClass.SetUser(User, UserId, is_Admin);//sets user data into global helper
                            Dashboard Dashboard = new Dashboard(lowStock);
                            Dashboard.ShowDialog();//logs in Cashier user into dashboard
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
            }
        }


        private void LogIn_Load(object sender, EventArgs e)
        {
            DatabaseChecker.InitializeDatabase();
            int rows = checkusers();
            if (rows <= 0)
            {
                Create_first_user create_First = new Create_first_user();
                create_First.ShowDialog();
            }
            txtPassword.UseSystemPasswordChar = true; //To hide user password
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // This will allow the user to signin after pressing enter
                btnLogIn_Click(sender, e);
                e.SuppressKeyPress = true; // Prevents the 'ding' sound
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Only drag with the left mouse button
            {
                isDragging = true;
                lastCursorPosition = new Point(e.X, e.Y); // Store the mouse position relative to the form
            }
        }

        private void LogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point(
                    this.Location.X + (e.X - lastCursorPosition.X),//subtracts the mouses current position with the form positon to calculate the new position
                    this.Location.Y + (e.Y - lastCursorPosition.Y)
                );//this.location is the location of the form 

            }
        }

        private void LogIn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false; // Stop dragging when the left mouse button is released
            }
        }
    }
}
