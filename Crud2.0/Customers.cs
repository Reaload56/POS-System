using Crud2._0.Models;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        int selectedCustomerId = 0;

        private void Customers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            HideControls();
        }

        private void HideControls()
        {
            //to limit what the cashier can do to the users table
            bool role = MiddleManClass.GetRole();

            if (role)
            {
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
        }
        //loads all customers
        public void LoadCustomers()
        {
            dgvCustomers.DataSource = CustomerDAL.GetAll();
            dgvCustomers.Columns["customer_id"].Visible = false;
        }

        public void ClearForm()
        {
            //resets the textboxes 
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            selectedCustomerId = 0;

        }
        //adds new customer to database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerType = "Walk In Customer";
            //sets values into a customer object
            Customer c = new Customer
            {
                FullName = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                CustomerType = customerType,
            };
            //saves the new customer details
            CustomerDAL.Insert(c);
            MessageBox.Show("Customer added successfully.");
            ClearForm();
            LoadCustomers();
        }
        //click event for updating customer data
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0) return; //exits if no customer is selected
            string customerType = "Walk In Customer";
            Customer c = new Customer
            {
                //sets customer data
                CustomerId = selectedCustomerId,
                FullName = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                CustomerType = customerType
            };
           
            CustomerDAL.Update(c);//updates customer(c) data
            MessageBox.Show("Customer updated.");
            ClearForm();
            LoadCustomers();

        }
        //a delete event to remove a specific customer
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == 0) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo); //asks user to confirm if they really want to delete a customer 
            if (confirm == DialogResult.Yes)
            {
                CustomerDAL.Delete(selectedCustomerId);
                MessageBox.Show("Customer deleted.");
                ClearForm();
                LoadCustomers();
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();//clears data set on textboxes
        }
        //sets customer data on specific customer data
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && !dgvCustomers.CurrentRow.IsNewRow)
            {
                DataGridViewRow row = dgvCustomers.CurrentRow;

                selectedCustomerId = Convert.ToInt32(row.Cells["customer_id"].Value);

                txtName.Text = row.Cells["full_name"].Value?.ToString();
                txtPhone.Text = row.Cells["phone"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                txtAddress.Text = row.Cells["address"].Value?.ToString();
            }
            else
            {
                ClearForm();
            }
        }
    }
}
