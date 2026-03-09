using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Dashboard : Form
    {
        string user; // Stores the current username.
        bool role; // Stores the current user's role (true for admin, false for cashier).
        public Dashboard(bool lowStock)
        {
            InitializeComponent();

            // Hide low stock alert controls by default.
            btnLowStockAlert.Visible = false;
            pbWarning.Visible = false;
            // Show alert controls if lowStock is true.
            if (lowStock)
            {
                pbWarning.Visible = true;
                btnLowStockAlert.Visible = true;
            }
        }
        /// Sets UI control visibility/enabled state based on the user's role.
        private void SetUserControl()
        {
            role = MiddleManClass.GetRole();// Get user role from a helper class.
            if (!role)// If not an admin (role is false and disables admin-specific buttons)
            {
                btnAdjustStock.Enabled = false;
                btnCategories.Enabled = false;
                btnUsers.Enabled = false;
                btnProducts.Enabled = false;
                btnReports.Enabled = false;
                btnReceiptDesign.Enabled = false;
                btnSuppliers.Enabled = false;
            }
        }
        /// Displays the current logged-in username on the dashboard.
        public void UserName()
        {
            user = MiddleManClass.GetUser();

            if (user != null)
            {
                lblCurrentUser.Text = user;
            }

        }

        private void LoadForm(Form frm) /// Loads a specified form into the main panel of the dashboard.
        {
            // If the current form in panelMain is a POS form, save its data before switching
            if (panelMain.Controls.Count > 0 && panelMain.Controls[0] is Point_Of_Sale currentPOS)
            {
                currentPOS.SaveSaleSession();
            }

            panelMain.Controls.Clear(); // Clear existing controls in the panel.
            frm.TopLevel = false; // Set the form as not a top-level window.
            frm.FormBorderStyle = FormBorderStyle.None; // Remove border.
            frm.Dock = DockStyle.Fill; // Dock the form to fill the panel.
            panelMain.Controls.Add(frm); // Add the form to the panel.
            frm.Show(); // Display the form.

        }
        /// Redirects to the Reports form, optionally showing low stock specific reports.
        public void RedirectToReportsForm(bool showLowStock)
        {
            lblTitle.Text = "Reports";
            Reports reports = new Reports(showLowStock);
            LoadForm(reports);
        }
        /// Handles loading of the Products form.
        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Products"; // Update dashboard title.
            LoadForm(new Products()); // Load the Products form.
        }
        /// Handles loading of the Categories form.
        private void btnCategories_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Categories"; // Update dashboard title.
            LoadForm(new Categories()); // Load the Categories form.
        }

        /// Handles loading of the Stocks form.
        private void btnStock_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Stock";
            LoadForm(new Stocks());
        }
        /// Handles loading of the Customers form.
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Customers";
            LoadForm(new Customers());
        }
        /// Handles loading of the Users form.
        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Users";
            LoadForm(new Users());
        }
        /// Handles loading of the ReceiptDesign form.
        private void btnReceiptDesign_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Edit Receipt";
            LoadForm(new PrintLayOut());
        }
        /// Closes the dashboard
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();// Close the current dashboard form.
        }
        /// Handles loading of the Point_Of_Sale form.
        private void btnPOS_Click(object sender, EventArgs e)
        {
            bool lowStock = false;
            lblTitle.Text = "Point of Sale";
            LoadForm(new Point_Of_Sale(lowStock));
        }
        /// Handles loading of the LowStockAlertForm form.
        private void btnLowStockAlert_Click(object sender, EventArgs e)
        {
            LowStockAlertForm alertForm = new LowStockAlertForm();
            alertForm.Owner = this; // Set the owner to this form
            alertForm.ShowDialog();
        }
        /// Handles loading of the StockAdjustments  form.
        private void btnAdjustStock_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Adjust Stock";
            LoadForm(new StockAdjustments());
        }
        /// Handles loading of the Reports form.
        private void btnReports_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Reports";
            LoadForm(new Reports());
        }
        /// Handles loading of the CustomerPayments form.
        private void btnCustomerPayments_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Customer Payments";
            LoadForm(new CustomerPayments());
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            UserName(); // Display current username.
            SetUserControl(); // Set button permissions based on user role.
        }
        /// Handles loading of the Suppliers form.
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Suppliers";
            LoadForm(new Suppliers());
        }
        /// Handles loading of the PurchaseOrder form.
        
    }
}
