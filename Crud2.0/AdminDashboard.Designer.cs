namespace Crud2._0
{
    partial class Dashboard
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
            pnlSideBar = new Panel();
            pnlControls = new TableLayoutPanel();
            btnCategories = new Button();
            btnReceiptDesign = new Button();
            btnReports = new Button();
            btnPOS = new Button();
            btnStock = new Button();
            btnUsers = new Button();
            btnProducts = new Button();
            btnAdjustStock = new Button();
            btnSuppliers = new Button();
            btnCustomerPayments = new Button();
            btnCustomers = new Button();
            panel1 = new Panel();
            pbWarning = new PictureBox();
            btnLowStockAlert = new Button();
            lblCurrentUser = new Label();
            btnLogOut = new Button();
            lblTitle = new Label();
            panel3 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            panelMain = new Panel();
            pnlSideBar.SuspendLayout();
            pnlControls.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbWarning).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.BackColor = Color.Gray;
            pnlSideBar.Controls.Add(pnlControls);
            pnlSideBar.Controls.Add(panel1);
            pnlSideBar.Dock = DockStyle.Left;
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(216, 574);
            pnlSideBar.TabIndex = 0;
            // 
            // pnlControls
            // 
            pnlControls.ColumnCount = 1;
            pnlControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlControls.Controls.Add(btnCategories, 0, 5);
            pnlControls.Controls.Add(btnReceiptDesign, 0, 10);
            pnlControls.Controls.Add(btnReports, 0, 6);
            pnlControls.Controls.Add(btnPOS, 0, 0);
            pnlControls.Controls.Add(btnStock, 0, 2);
            pnlControls.Controls.Add(btnUsers, 0, 9);
            pnlControls.Controls.Add(btnProducts, 0, 1);
            pnlControls.Controls.Add(btnAdjustStock, 0, 3);
            pnlControls.Controls.Add(btnSuppliers, 0, 4);
            pnlControls.Controls.Add(btnCustomerPayments, 0, 8);
            pnlControls.Controls.Add(btnCustomers, 0, 7);
            pnlControls.Dock = DockStyle.Fill;
            pnlControls.Location = new Point(0, 89);
            pnlControls.Name = "pnlControls";
            pnlControls.RowCount = 11;
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333333F));
            pnlControls.Size = new Size(216, 485);
            pnlControls.TabIndex = 3;
            // 
            // btnCategories
            // 
            btnCategories.Dock = DockStyle.Fill;
            btnCategories.Font = new Font("Segoe UI", 15.75F);
            btnCategories.ImageAlign = ContentAlignment.MiddleRight;
            btnCategories.Location = new Point(3, 223);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(210, 38);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Categories";
            btnCategories.TextAlign = ContentAlignment.MiddleLeft;
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnReceiptDesign
            // 
            btnReceiptDesign.Dock = DockStyle.Fill;
            btnReceiptDesign.Font = new Font("Segoe UI", 15.75F);
            btnReceiptDesign.ImageAlign = ContentAlignment.MiddleRight;
            btnReceiptDesign.Location = new Point(3, 443);
            btnReceiptDesign.Name = "btnReceiptDesign";
            btnReceiptDesign.Size = new Size(210, 39);
            btnReceiptDesign.TabIndex = 1;
            btnReceiptDesign.Text = "Receipt Design";
            btnReceiptDesign.TextAlign = ContentAlignment.MiddleLeft;
            btnReceiptDesign.UseVisualStyleBackColor = true;
            btnReceiptDesign.Click += btnReceiptDesign_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Fill;
            btnReports.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.ImageAlign = ContentAlignment.MiddleRight;
            btnReports.Location = new Point(3, 267);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(210, 38);
            btnReports.TabIndex = 1;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnPOS
            // 
            btnPOS.Dock = DockStyle.Fill;
            btnPOS.Font = new Font("Segoe UI", 15.75F);
            btnPOS.ImageAlign = ContentAlignment.MiddleRight;
            btnPOS.Location = new Point(3, 3);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(210, 38);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnStock
            // 
            btnStock.Dock = DockStyle.Fill;
            btnStock.Font = new Font("Segoe UI", 15.75F);
            btnStock.ImageAlign = ContentAlignment.MiddleRight;
            btnStock.Location = new Point(3, 91);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(210, 38);
            btnStock.TabIndex = 1;
            btnStock.Text = "Stock";
            btnStock.TextAlign = ContentAlignment.MiddleLeft;
            btnStock.UseVisualStyleBackColor = true;
            btnStock.Click += btnStock_Click;
            // 
            // btnUsers
            // 
            btnUsers.Dock = DockStyle.Fill;
            btnUsers.Font = new Font("Segoe UI", 15.75F);
            btnUsers.ImageAlign = ContentAlignment.MiddleRight;
            btnUsers.Location = new Point(3, 399);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(210, 38);
            btnUsers.TabIndex = 1;
            btnUsers.Text = "Users";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnProducts
            // 
            btnProducts.Dock = DockStyle.Fill;
            btnProducts.Font = new Font("Segoe UI", 15.75F);
            btnProducts.ImageAlign = ContentAlignment.MiddleRight;
            btnProducts.Location = new Point(3, 47);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(210, 38);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnAdjustStock
            // 
            btnAdjustStock.Dock = DockStyle.Fill;
            btnAdjustStock.Font = new Font("Segoe UI", 15.75F);
            btnAdjustStock.ImageAlign = ContentAlignment.MiddleRight;
            btnAdjustStock.Location = new Point(3, 135);
            btnAdjustStock.Name = "btnAdjustStock";
            btnAdjustStock.Size = new Size(210, 38);
            btnAdjustStock.TabIndex = 1;
            btnAdjustStock.Text = "Adjust Stock";
            btnAdjustStock.TextAlign = ContentAlignment.MiddleLeft;
            btnAdjustStock.UseVisualStyleBackColor = true;
            btnAdjustStock.Click += btnAdjustStock_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Dock = DockStyle.Fill;
            btnSuppliers.Font = new Font("Segoe UI", 15.75F);
            btnSuppliers.ImageAlign = ContentAlignment.MiddleRight;
            btnSuppliers.Location = new Point(3, 179);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(210, 38);
            btnSuppliers.TabIndex = 2;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.TextAlign = ContentAlignment.MiddleLeft;
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnCustomerPayments
            // 
            btnCustomerPayments.Dock = DockStyle.Fill;
            btnCustomerPayments.Font = new Font("Segoe UI", 15.75F);
            btnCustomerPayments.ImageAlign = ContentAlignment.MiddleRight;
            btnCustomerPayments.Location = new Point(3, 355);
            btnCustomerPayments.Name = "btnCustomerPayments";
            btnCustomerPayments.Size = new Size(210, 38);
            btnCustomerPayments.TabIndex = 1;
            btnCustomerPayments.Text = "Customer Payments";
            btnCustomerPayments.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomerPayments.UseVisualStyleBackColor = true;
            btnCustomerPayments.Click += btnCustomerPayments_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.Dock = DockStyle.Fill;
            btnCustomers.Font = new Font("Segoe UI", 15.75F);
            btnCustomers.ImageAlign = ContentAlignment.MiddleRight;
            btnCustomers.Location = new Point(3, 311);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(210, 38);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "Customers";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(pbWarning);
            panel1.Controls.Add(btnLowStockAlert);
            panel1.Controls.Add(lblCurrentUser);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(216, 89);
            panel1.TabIndex = 2;
            // 
            // pbWarning
            // 
            pbWarning.Image = Properties.Resources.Warning_svg;
            pbWarning.Location = new Point(96, 47);
            pbWarning.Name = "pbWarning";
            pbWarning.Size = new Size(50, 36);
            pbWarning.SizeMode = PictureBoxSizeMode.Zoom;
            pbWarning.TabIndex = 2;
            pbWarning.TabStop = false;
            pbWarning.Visible = false;
            pbWarning.Click += btnLowStockAlert_Click;
            // 
            // btnLowStockAlert
            // 
            btnLowStockAlert.Location = new Point(3, 47);
            btnLowStockAlert.Name = "btnLowStockAlert";
            btnLowStockAlert.Size = new Size(97, 36);
            btnLowStockAlert.TabIndex = 1;
            btnLowStockAlert.Text = "Low Stock Alert";
            btnLowStockAlert.TextAlign = ContentAlignment.MiddleLeft;
            btnLowStockAlert.UseVisualStyleBackColor = true;
            btnLowStockAlert.Click += btnLowStockAlert_Click;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentUser.Location = new Point(0, -3);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(89, 47);
            lblCurrentUser.TabIndex = 1;
            lblCurrentUser.Text = "User";
            // 
            // btnLogOut
            // 
            btnLogOut.Dock = DockStyle.Right;
            btnLogOut.Location = new Point(786, 0);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(156, 44);
            btnLogOut.TabIndex = 1;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 40);
            lblTitle.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(btnLogOut);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(lblTitle);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(216, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(942, 44);
            panel3.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(492, 12);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.Control;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(216, 44);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(942, 530);
            panelMain.TabIndex = 3;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 574);
            Controls.Add(panelMain);
            Controls.Add(panel3);
            Controls.Add(pnlSideBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += AdminDashboard_Load;
            pnlSideBar.ResumeLayout(false);
            pnlControls.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbWarning).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSideBar;
        private Label lblCurrentUser;
        private Button btnPOS;
        private Button btnLogOut;
        private Button btnReceiptDesign;
        private Button btnUsers;
        private Button btnCustomers;
        private Button btnStock;
        private Button btnCategories;
        private Button btnProducts;
        private Button btnReports;
        private Label lblTitle;
        private Button btnLowStockAlert;
        private Button btnAdjustStock;
        private Button btnCustomerPayments;
        private Panel panel1;
        private Panel panel3;
        private DateTimePicker dateTimePicker1;
        private Panel panelMain;
        private Button btnSuppliers;
        private TableLayoutPanel pnlControls;
        private PictureBox pbWarning;
    }
}