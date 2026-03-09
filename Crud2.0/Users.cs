using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using MySql.Data.MySqlClient;
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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        bool LogAsAdmin = false;
        User_ SelectedUser = new User_();
        //method to load all customers to data grid view
        public void LoadUsers()
        {
            DataTable users = new DataTable();
            users = UserDAL.GetAll();

            dgvUsers.DataSource = users;
            dgvUsers.Columns["user_id"].Visible = false;
        }
        //click event to add a new user to data base
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Authenticate authenticate = new Authenticate();
            User_ user = new User_();

            string role = "Cashier";//default role is cashier
            bool exist = authenticate.ConfirmUser(txtUserName.Text);
            if (LogAsAdmin)
            {
                role = "Admin";
            }
            else { role = "Cashier"; }

            if (exist)
            {
                MessageBox.Show("User Exists");
            }
            else
            {
                if (txtPassword.Text == txtConfirmPassword.Text)//ensures passwords entered match
                {
                    //loads new data on to user object
                    string hashedPass = authenticate.Hash(txtPassword.Text);
                    user.Password = hashedPass;
                    user.UserName = txtUserName.Text;
                    user.Address = txtAddress.Text;
                    user.Email = txtEmail.Text;
                    user.FullName = txtFullName.Text;
                    user.Role = role;

                    UserDAL.InsertUser(user);//inserts new user to database
                    //clears all textboxes
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    MessageBox.Show("User Added Successfully");
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Passwords Do Not Match");
                }

            }
            this.Close();
        }
        //click event to change the user role to admin
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            btnCashier.BackColor = Color.Transparent;
            SelectedUser.Role = "Admin";
            btnAdmin.BackColor = Color.White;
        }
        //click event to change the user role to cashier
        private void btnCashier_Click(object sender, EventArgs e)
        {
            btnCashier.BackColor = Color.White;
            SelectedUser.Role = "Cashier";
            btnAdmin.BackColor = Color.Transparent;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadUsers();//loads customers at startuo
            txtPassword.UseSystemPasswordChar = true;//hides password characters
            txtConfirmPassword.UseSystemPasswordChar = true;//hides confirmation password characters
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            Authenticate authenticate = new Authenticate();

            //sets new data from textboxes to specified areas
            if (!string.IsNullOrEmpty(txtUserName.Text)) { SelectedUser.UserName = txtUserName.Text; }
            if (!string.IsNullOrEmpty(txtAddress.Text)) { SelectedUser.Address = txtAddress.Text; }
            if (!string.IsNullOrEmpty(txtEmail.Text)) { SelectedUser.Email = txtEmail.Text; }
            if (string.IsNullOrEmpty(txtFullName.Text)) { SelectedUser.FullName = txtFullName.Text; }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (txtConfirmPassword.Text == txtPassword.Text)
                {
                    string hashedPass = authenticate.Hash(txtPassword.Text);
                    SelectedUser.Password = hashedPass;
                }
            }

            UserDAL.UpdateUser(SelectedUser);//updates selected user in database
            //resets all textboxes
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtUserName.Text = String.Empty;
            LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            UserDAL.DeleteUser(SelectedUser.UserId);//deletes selected user based on id
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
            txtUserName.Text = String.Empty;
            LoadUsers();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.Index >= 0 && !dgvUsers.CurrentRow.IsNewRow)//checks if selected row is not null
            {
                //sets selected user id to user object
                SelectedUser.UserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);
                SelectedUser.Address = dgvUsers.CurrentRow.Cells["address"].Value?.ToString();
                SelectedUser.Email = dgvUsers.CurrentRow.Cells["email"].Value?.ToString();
                SelectedUser.UserName = dgvUsers.CurrentRow.Cells["username"].Value?.ToString();
                SelectedUser.FullName = dgvUsers.CurrentRow.Cells["full_name"].Value?.ToString();
                SelectedUser.Password = dgvUsers.CurrentRow.Cells["password_hash"].Value?.ToString();
                SelectedUser.Role = dgvUsers.CurrentRow.Cells["role"].Value.ToString();
                
                //sets selected user data to textboxes and buttons
                txtAddress.Text = dgvUsers.CurrentRow.Cells["address"].Value?.ToString();
                txtEmail.Text = dgvUsers.CurrentRow.Cells["email"].Value?.ToString();
                txtUserName.Text = dgvUsers.CurrentRow.Cells["username"].Value?.ToString();
                txtFullName.Text = dgvUsers.CurrentRow.Cells["full_name"].Value?.ToString();
                if (SelectedUser.Role == "Cashier") { btnCashier_Click(sender, e); }
                else if (SelectedUser.Role == "Admin") { btnAdmin_Click(sender,e); }
            }
        }
    }
}
