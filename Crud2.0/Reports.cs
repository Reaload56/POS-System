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
    //form for loading all reports
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            lblReportTitle.Text = "Select a report to view";
        }
        private bool showLowStockOnLoad = false;
        public Reports(bool showLowStock) : this()
        {
            this.showLowStockOnLoad = showLowStock;
        }

        public DataTable salesReport = new DataTable();

        private void LoadReport(DataTable dt)
        {
            dgvReports.DataSource = dt;
        }

        private void btnCustomerBalance_Click(object sender, EventArgs e) //loads customer balance
        {
            LoadReport(ReportDAL.GetCustomerBalances());
            lblReportTitle.Text = "Customer Balance Report";//changes the lable name so user knows what they are viewing
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            //Loads all transaction history
            lblReportTitle.Text = "Transaction History";
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (dtpFrom.Checked)  //sets from date data if  user selected a From date
                fromDate = dtpFrom.Value;

            if (dtpTo.Checked)    //sets to date data  if user selected a To date
                toDate = dtpTo.Value;

            DataTable dt = ReportDAL.GetTransactionHistory(fromDate, toDate);
            dgvReports.DataSource = dt;
        }

        private void btnCreditDebtSummary_Click(object sender, EventArgs e)//loads summary of all customer balances
        {
            LoadReport(ReportDAL.GetCreditDebtSummary());
            lblReportTitle.Text = "Credit / Debt Summary";
        }

        private void btnInventoryLevels_Click(object sender, EventArgs e)//shows inventory levels
        {
            LoadReport(ReportDAL.GetInventoryLevels());
            lblReportTitle.Text = "Inventory Levels";
        }

        private void btnLowStock_Click(object sender, EventArgs e)//click event ti show all stock that need restocking
        {
            LoadReport(ReportDAL.GetLowStockWarnings());
            lblReportTitle.Text = "Low Stock Warnings";
        }

        private void btnInventoryValuation_Click(object sender, EventArgs e)
        {
            LoadReport(ReportDAL.GetInventoryValuation());
            lblReportTitle.Text = "Inventory Valuation";
        }
        //click event to show all profits and losses based on specified date
        private void btnProfitAndLoss_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;
            lblReportTitle.Text = "Profit & Loss";

            if (dtpFrom.Checked)  
                fromDate = dtpFrom.Value;

            if (dtpTo.Checked)    
                toDate = dtpTo.Value;

            DataTable dt = ReportDAL.GetProfitAndLoss(fromDate, toDate);
            dgvReports.DataSource = dt;
        }
        //loads a summary of all sales within a given range
        private void btnSalesSummary_Click(object sender, EventArgs e)
        {
            lblReportTitle.Text = "Sales Summary";
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (dtpFrom.Checked)  
                fromDate = dtpFrom.Value;

            if (dtpTo.Checked)    
                toDate = dtpTo.Value;

            DataTable dt = ReportDAL.GetSalesSummary(fromDate, toDate);
            dgvReports.DataSource = dt;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadReport(ReportDAL.GetCustomerBalances());
            lblReportTitle.Text = "Customer Balance Report";
            if (showLowStockOnLoad)
            {
                LoadReport(ReportDAL.GetLowStockWarnings());
                lblReportTitle.Text = "Low Stock Warnings";
            }
            else
            {
                // Existing default behavior
                LoadReport(ReportDAL.GetCustomerBalances());
                lblReportTitle.Text = "Customer Balance Report";
            }
        }
    }
}
