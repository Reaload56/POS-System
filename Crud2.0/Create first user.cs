using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud2._0
{
    //form for creating if user at the first run of the application 
    public partial class Create_first_user : Form
    {

        public Create_first_user()
        {
            InitializeComponent();
        }
        /// click event for saving user data
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            Authenticate authenticate = new Authenticate();
            User_ user = new User_();
            string role = "Admin";
            //verifies if user has entered anything
            if (txtUserName.Text.Length < 1)
            {
                MessageBox.Show("UserName can not be empty");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text) //checks if passwords entered are the same
            {
                MessageBox.Show("Passwords do not match");
            }

            else if (txtPassword.Text == txtConfirmPassword.Text)
            {
                // sets new user data to user object 
                string hashedPass = authenticate.Hash(txtPassword.Text);
                user.Password = hashedPass;
                user.UserName = txtUserName.Text;
                user.Address = txtAddress.Text;
                user.Email = txtEmail.Text;
                user.FullName = txtFullName.Text;
                user.Role = role;
                //inserts new user to the database
                UserDAL.InsertUser(user);

                txtEmail.Text = "";
                txtAddress.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                MessageBox.Show("User Added Successfully");
                this.Close();
            }

        }

        private void Create_first_user_Load(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';//insures that noone close by can view the password by setting text characters to '*'
            txtPassword.PasswordChar = '*';
        }
    }
}
