using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using MySql.Data.MySqlClient;
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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        public void LoadProducts() //loads product data to datagridview
        {
            dgvProducts.DataSource = ProductDAL.GetAll();
            dgvProducts.Columns["category_id"].Visible = false;
        }
        public void loadCartegories()//sets product categories to combobox
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT category_id, name FROM categories", conn);
                var reader = cmd.ExecuteReader();

                var dt = new DataTable();
                dt.Load(reader);

                cbCategory.DisplayMember = "name";//this is what the combobox shows
                cbCategory.ValueMember = "category_id";//this is the value that is saved
                cbCategory.DataSource = dt;
            }
        }
        private void LoadSuppliers()//loads all suppliers to set specific product to a supplier
        {
            DataTable dt = SupplierDAL.GetAll();
            cbSuppliers.DataSource = dt;
            cbSuppliers.DisplayMember = "name";
            cbSuppliers.ValueMember = "supplier_id";
        }

        //clears textbox
        public void ClearForm()
        {
            txtName.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            cbkIsService.Checked = false;
            cbCategory.SelectedIndex = -1;
            txtTaxRate.Text = string.Empty;
        }
        //inserts new product to table
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product
                {
                    Name = txtName.Text.Trim(),
                    Barcode = txtBarcode.Text.Trim(),
                    CategoryID = Convert.ToInt32(cbCategory.SelectedValue),
                    Description = txtDescription.Text.Trim(),
                    CostPrice = Convert.ToDecimal(txtCostPrice.Text),
                    SellingPrice = Convert.ToDecimal(txtSellingPrice.Text),
                    TaxRate = Convert.ToDecimal(txtTaxRate.Text),
                    Discount = Convert.ToDecimal(txtDiscount.Text),
                    IsService = cbkIsService.Checked,
                    SupplierID = Convert.ToInt32(cbSuppliers.SelectedValue)

                };

                ProductDAL.Insert(p);  // inserts product ONLY

                MessageBox.Show("Product added successfully.");
                LoadProducts(); // refresh the product list
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)//updates an existing products values
        {
            if (dgvProducts.CurrentRow != null)
            {

                try
                {
                    Product p = new Product
                    {
                        ProductID = Convert.ToInt32(dgvProducts.CurrentRow.Cells["product_id"].Value),
                        Name = txtName.Text.Trim(),
                        Barcode = txtBarcode.Text.Trim(),
                        CategoryID = Convert.ToInt32(cbCategory.SelectedValue),
                        Description = txtDescription.Text.Trim(),
                        CostPrice = Convert.ToDecimal(txtCostPrice.Text),
                        SellingPrice = Convert.ToDecimal(txtSellingPrice.Text),
                        TaxRate = Convert.ToDecimal(txtTaxRate.Text),
                        Discount = Convert.ToDecimal(txtDiscount.Text),
                        IsService = cbkIsService.Checked,
                        SupplierID = Convert.ToInt32(cbSuppliers.SelectedValue)
                    };

                    ProductDAL.Update(p);
                    LoadProducts();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select a product to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)//deletes a specific product by their id
        {
            if (dgvProducts.CurrentRow != null)
            {
                int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["product_id"].Value);

                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);//confirmation message to ensure the user really wants to delete a product
                if (confirm == DialogResult.Yes)
                {
                    ProductDAL.Delete(productId);
                    LoadProducts();
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Select a product to delete.");
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            //loads all comboboxes and datagrid views when the form loads
            loadCartegories();
            LoadProducts();
            LoadSuppliers();
        }

        private void btnClear_Click(object sender, EventArgs e) //click event to clear values in text boxes
        {
            txtBarcode.Text = String.Empty;
            txtCostPrice.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtDiscount.Text = String.Empty;
            txtName.Text = String.Empty;
            txtSellingPrice.Text = String.Empty;
            txtTaxRate.Text = String.Empty;
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Index >= 0 && !dgvProducts.CurrentRow.IsNewRow)//checks that the selected row is not null
            {
                txtName.Text = dgvProducts.CurrentRow.Cells["product_name"].Value?.ToString();
                txtBarcode.Text = dgvProducts.CurrentRow.Cells["barcode"].Value?.ToString();
                txtDescription.Text = dgvProducts.CurrentRow.Cells["description"].Value?.ToString();
                txtCostPrice.Text = dgvProducts.CurrentRow.Cells["cost_price"].Value?.ToString();
                txtSellingPrice.Text = dgvProducts.CurrentRow.Cells["selling_price"].Value?.ToString();
                txtTaxRate.Text = dgvProducts.CurrentRow.Cells["tax_rate"].Value?.ToString();

                if (dgvProducts.CurrentRow.Cells["discount"].Value != DBNull.Value)
                {
                    txtDiscount.Text = dgvProducts.CurrentRow.Cells["discount"].Value?.ToString();
                }
                else
                {
                    txtDiscount.Text = string.Empty;
                }

                if (dgvProducts.CurrentRow.Cells["category_id"].Value != null && dgvProducts.CurrentRow.Cells["category_id"].Value != DBNull.Value)
                {
                    int categoryId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["category_id"].Value);
                    cbCategory.SelectedValue = categoryId;
                }
                else
                {
                    cbCategory.SelectedIndex = -1;
                }

                if (dgvProducts.CurrentRow.Cells["is_service"].Value != DBNull.Value)
                {
                    int isService = Convert.ToInt32(dgvProducts.CurrentRow.Cells["is_service"].Value);
                    cbkIsService.Checked = (isService > 0);
                }
                else
                {
                    cbkIsService.Checked = false; 
                }

                if (dgvProducts.CurrentRow.Cells["supplier_id"].Value != null && dgvProducts.CurrentRow.Cells["supplier_id"].Value != DBNull.Value)
                {
                    int supplierId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["supplier_id"].Value);
                    cbSuppliers.SelectedValue = supplierId;
                }
                else
                {
                    cbSuppliers.SelectedIndex = -1; 
                }
            }
        }
    }
}
