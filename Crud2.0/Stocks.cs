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
    public partial class Stocks : Form
    {
        bool role; 
        public Stocks()
        {
            InitializeComponent();
        }
        int selectedProductId;
        //loads all stock and sets it to data grid view
        private void LoadStock(string search = "")
        {
            dgvStock.DataSource = StockDAL.GetAllStock(search);
            dgvStock.Columns["product_id"].Visible = false;
        }
        //click event to apend stock to a product
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please Select a Product");
                return;
            }

            int qtyToAdd = Convert.ToInt32(nudQuantity.Value);//sets quantity thats being added

            if (qtyToAdd <= 0)
            {
                MessageBox.Show("You can only add positive quantities here. Use Stock Adjustments for reductions.");
                return;
            }
            Stock stock = new Stock
            {
                ProductID = selectedProductId,
                Quantity = qtyToAdd,
                ReorderLevel = Convert.ToInt32(nudReOrderLevel.Value),
                TotalProductsBought = qtyToAdd
            };
            StockDAL.AddStock(stock);
            LoadStock();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStock(txtSearch.Text.Trim());//searches for a specified product
        }
        //clears values from textbox and selected product
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            selectedProductId = 0;
        }
        
        private void Stocks_Load(object sender, EventArgs e)
        {
            LoadStock();
            role = MiddleManClass.GetRole();
            if(!role)//disables some controls for cashier
            {
                btnAddStock.Enabled = false;
                btnChangeReOrderLevel.Enabled = false;
            }
        }

        private void btnEnsureStock_Click(object sender, EventArgs e)
        {
            StockDAL.EnsureStock();//this reloads all stocks and makes sure that all products have a stock record
            LoadStock();
        }
        
        private void btnChangeReOrderLevel_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please Select a Product");
                return;//exits if no product is selected
            }

            Stock stock = new Stock
            {
                ProductID = selectedProductId,
                ReorderLevel = Convert.ToInt32(nudReOrderLevel.Value)
            };
            StockDAL.ChangeReOrderLevel(stock);
            MessageBox.Show("Stock added.");
            LoadStock();
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            //changes product Id based on the product selected in the datagridview
            if (dgvStock.CurrentRow != null && dgvStock.CurrentRow.Index >= 0 && !dgvStock.CurrentRow.IsNewRow)
            {
                selectedProductId = Convert.ToInt32(dgvStock.CurrentRow.Cells["product_id"].Value);
            }
        }
    }
}
