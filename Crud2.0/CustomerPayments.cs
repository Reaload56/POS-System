using Crud2._0.Data_Access_Layers;
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
    public partial class CustomerPayments : Form
    {
        public CustomerPayments()
        {
            InitializeComponent();
        }
        private int customerId;
        private decimal balance;
        decimal amount;
        string method;
        string reference;
        string notes;
        //loads all payments that have been done by customers
        private void LoadPayments()
        {
            dgvPayments.DataSource = CustomerPaymentsDAL.GetPayments(customerId);
            dgvPayments.Columns["payment_id"].Visible = false;
        }
        //obtains a list of all customers
        private void LoadCustomers()
        {
            cbCustomers.DataSource = CustomerDAL.GetAll();
            cbCustomers.DisplayMember = "full_name";  
            cbCustomers.ValueMember = "customer_id"; 
            cbCustomers.SelectedIndex = -1; 
        }
        private void AdjustBalance(decimal bal)
        {
            if (bal > 0)
            {

            }
            CustomerPaymentsDAL.AddPayment(customerId, amount, method, reference, notes);
        }

        //click event for saving payment details
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (cbCustomers.SelectedValue == null) //checks if no customer is selected 
            {
                MessageBox.Show("Please select a customer.");
                return;// if no customer is selected the data isn't saved
            }
            //sets payement data to variables
            int customerId = Convert.ToInt32(cbCustomers.SelectedValue);
            amount = nudAmount.Value;
            method = cbPaymentMethod.SelectedItem.ToString();
            reference = txtReference.Text.Trim();
            notes = txtNotes.Text.Trim();

            if (amount <= 0)
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            AdjustBalance(amount);

            MessageBox.Show("Payment recorded successfully.");

            // shows the new customer balance 
            decimal balance = CustomerDAL.GetBalance(customerId);
            txtBalance.Text = balance.ToString("C");
            dgvPayments.DataSource = CustomerPaymentsDAL.GetPayments(customerId); //reloads the data grid view

            // Resets input values
            nudAmount.Value = 0;
            txtReference.Clear();
            txtNotes.Clear();
        }
        
        private void CustomerPayments_Load(object sender, EventArgs e)
        {
            LoadPayments();
            LoadCustomers();

            cbPaymentMethod.Items.AddRange(new string[] { "Cash", "Card", "Bank Transfer" });
            cbPaymentMethod.SelectedIndex = 0;
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomers.SelectedValue != null && cbCustomers.SelectedValue is int)// checks if there valid selection of customer
            {
                int customerId = (int)cbCustomers.SelectedValue; // sets the new customer's id
                balance = CustomerDAL.GetBalance(customerId); //sets the new customer's balance
                txtBalance.Text = balance.ToString("0.00");//displays the new customer's balance onto a textbox
            }

        }
    }
}
