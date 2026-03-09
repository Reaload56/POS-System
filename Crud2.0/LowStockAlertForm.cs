using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crud2._0.Data_Access_Layers;

namespace Crud2._0
{
    public partial class LowStockAlertForm : Form
    {
        public LowStockAlertForm()
        {
            InitializeComponent();
        }
        //method to obtain data on products with low stock
        private void LowStockAlertForm_Load(object sender, EventArgs e)
        {
            DataTable dt = ReportDAL.GetLowStockWarnings();
            dgvLowStock.DataSource = dt;
            dgvLowStock.ReadOnly = true;
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.Columns["product_id"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //closes form
        }

        private void btnGoToReports_Click(object sender, EventArgs e)
        {
            this.Close();
            ((Dashboard)this.Owner).RedirectToReportsForm(true); //transfers user to reports form showing all low stock reports
        }
    }
}
