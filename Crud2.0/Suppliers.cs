using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Crud2._0
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }
        Supplier supplier = new Supplier();
        private void LoadSuppliers()
        {
            dgvSuppliers.DataSource = SupplierDAL.GetAll();
        }
        //method for changing supplier object data
        private void SetSupplier()
        {
            int id = 0;

            if (dgvSuppliers.CurrentRow != null && !dgvSuppliers.CurrentRow.IsNewRow)
            {
                id = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells["supplier_id"].Value);
            }
            
            supplier = new Supplier
            {
                SupplierId = id,
                Name = txtName.Text,
                Contact = txtContact.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            dgvSuppliers.DataSource = SupplierDAL.GetAll();//obtains all suppliers from table
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Supplier name is required.");
                return;
            }
            //adds new data of supplier to the supplier object
            supplier = new Supplier
            {
                Name = txtName.Text,
                Contact = txtContact.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };

            SupplierDAL.Insert(supplier);
            LoadSuppliers();
        }
        
        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow == null)
            {
                MessageBox.Show("Please select a supplier to delete.");
                return;//exits if no supplier is selected
            }
            //deletes selected supplier from database
            int id = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells["supplier_id"].Value);
            SupplierDAL.Delete(id);
            LoadSuppliers();
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow == null)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;//exits if no supplier to update is selected
            }

            SetSupplier();
            SupplierDAL.Update(supplier);
            LoadSuppliers();
        }

        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow == null || dgvSuppliers.CurrentRow.IsNewRow)
                return;//exits if no supplier is selected

            //the following changes the textbox data to the data within the selected supplier
            txtName.Text = dgvSuppliers.CurrentRow.Cells["name"].Value?.ToString();
            txtContact.Text = dgvSuppliers.CurrentRow.Cells["contact"].Value?.ToString();
            txtEmail.Text = dgvSuppliers.CurrentRow.Cells["email"].Value?.ToString();
            txtAddress.Text = dgvSuppliers.CurrentRow.Cells["address"].Value?.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears textbox data and resets selected supplier
            txtName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            dgvSuppliers.ClearSelection();
        }
    }
}
