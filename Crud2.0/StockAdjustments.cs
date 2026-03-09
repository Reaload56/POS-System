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
    public partial class StockAdjustments : Form
    {
        public StockAdjustments()
        {
            InitializeComponent();
        }

        // Load products into ComboBox
        private void LoadProducts()
        {
            DataTable dt = StockDAL.GetAllStock();
            cmbProducts.DataSource = dt;
            cmbProducts.DisplayMember = "product_name";
            cmbProducts.ValueMember = "product_id";
        }

        // Load adjustment history
        private void LoadAdjustments()
        {
            DataTable dt = StockDAL.GetAdjustments();
            dgvAdjustments.DataSource = dt;
        }
        private void LoadAdjustments(DateTime? fromDate = null, DateTime? toDate = null)
        {
            DataTable dt = StockDAL.GetAdjustments(fromDate, toDate);
            dgvAdjustments.DataSource = dt;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducts.SelectedValue == null || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                int productId = Convert.ToInt32(cmbProducts.SelectedValue);
                int qtyChange = Convert.ToInt32(txtQuantity.Text);
                string reason = txtReason.Text.Trim();

                // Assuming you have a current logged in user ID
                int userId = MiddleManClass.GetId(); 

                Stock_Adjustment adjustment = new Stock_Adjustment
                {
                    productId = productId,
                    quantityChanged = qtyChange,
                    reason = reason,
                    userId = userId,
                    date = DateTime.Now
                };

                StockDAL.AddAdjustment(adjustment);

                MessageBox.Show("Stock adjustment saved successfully!");

                // Refresh adjustments & stock
                LoadAdjustments();
                LoadProducts();

                // Clear input
                txtQuantity.Clear();
                txtReason.Clear();
                cmbProducts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving adjustment: " + ex.Message);
            }
        }

        private void StockAdjustments_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadAdjustments();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = dtpFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null;
            DateTime? toDate = dtpTo.Checked ? dtpTo.Value.Date : (DateTime?)null;

            LoadAdjustments(fromDate, toDate);
        }
    }
}
