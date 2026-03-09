namespace Crud2._0
{
    partial class LowStockAlertForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvLowStock = new DataGridView();
            btnGoToReports = new Button();
            btnClose = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLowStock
            // 
            dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLowStock.Dock = DockStyle.Fill;
            dgvLowStock.Location = new Point(0, 0);
            dgvLowStock.Name = "dgvLowStock";
            dgvLowStock.Size = new Size(800, 450);
            dgvLowStock.TabIndex = 0;
            // 
            // btnGoToReports
            // 
            btnGoToReports.Location = new Point(544, 3);
            btnGoToReports.Name = "btnGoToReports";
            btnGoToReports.Size = new Size(119, 37);
            btnGoToReports.TabIndex = 1;
            btnGoToReports.Text = "Go To Reports";
            btnGoToReports.UseVisualStyleBackColor = true;
            btnGoToReports.Click += btnGoToReports_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(669, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(119, 37);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnGoToReports);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 403);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 2;
            // 
            // LowStockAlertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvLowStock);
            Name = "LowStockAlertForm";
            Text = "LowStockAlertForm";
            Load += LowStockAlertForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLowStock;
        private Button btnGoToReports;
        private Button btnClose;
        private Panel panel1;
    }
}