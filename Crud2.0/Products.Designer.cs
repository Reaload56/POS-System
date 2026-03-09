namespace Crud2._0
{
    partial class Products
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
            txtDescription = new TextBox();
            txtName = new TextBox();
            btnUpdate = new Button();
            btnClear = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            lblProductName = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbkIsService = new CheckBox();
            cbCategory = new ComboBox();
            txtBarcode = new TextBox();
            label6 = new Label();
            txtCostPrice = new TextBox();
            txtTaxRate = new TextBox();
            txtSellingPrice = new TextBox();
            label7 = new Label();
            txtDiscount = new TextBox();
            label5 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            cbSuppliers = new ComboBox();
            label8 = new Label();
            dgvProducts = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(6, 156);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(245, 23);
            txtDescription.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(3, 21);
            txtName.Name = "txtName";
            txtName.Size = new Size(245, 23);
            txtName.TabIndex = 8;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Gray;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 14.25F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(3, 43);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(248, 34);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(3, 123);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(248, 37);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Gray;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 14.25F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(248, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14.25F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(3, 83);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(248, 34);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(6, 3);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 10;
            lblProductName.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 50);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 10;
            label1.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 94);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 10;
            label2.Text = "Barcode";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 138);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 10;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 182);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 10;
            label4.Text = "Cost Price";
            // 
            // cbkIsService
            // 
            cbkIsService.BackColor = SystemColors.Window;
            cbkIsService.Location = new Point(9, 361);
            cbkIsService.Name = "cbkIsService";
            cbkIsService.Size = new Size(239, 24);
            cbkIsService.TabIndex = 11;
            cbkIsService.Text = "Is Service";
            cbkIsService.UseVisualStyleBackColor = false;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(6, 68);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(242, 23);
            cbCategory.TabIndex = 12;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(6, 112);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(245, 23);
            txtBarcode.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 270);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 10;
            label6.Text = "Tax Rate";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Location = new Point(6, 200);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new Size(245, 23);
            txtCostPrice.TabIndex = 7;
            // 
            // txtTaxRate
            // 
            txtTaxRate.Location = new Point(6, 288);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(245, 23);
            txtTaxRate.TabIndex = 7;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(6, 244);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(245, 23);
            txtSellingPrice.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 226);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 10;
            label7.Text = "Selling Price";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(6, 332);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(245, 23);
            txtDiscount.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 314);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 10;
            label5.Text = "Discount";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(lblProductName);
            panel1.Controls.Add(cbSuppliers);
            panel1.Controls.Add(cbCategory);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(cbkIsService);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtCostPrice);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtSellingPrice);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtTaxRate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtBarcode);
            panel1.Controls.Add(txtDiscount);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(610, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(254, 651);
            panel1.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnUpdate, 0, 1);
            tableLayoutPanel1.Controls.Add(btnDelete, 0, 2);
            tableLayoutPanel1.Controls.Add(btnClear, 0, 3);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 488);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(254, 163);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // cbSuppliers
            // 
            cbSuppliers.FormattingEnabled = true;
            cbSuppliers.Location = new Point(3, 406);
            cbSuppliers.Name = "cbSuppliers";
            cbSuppliers.Size = new Size(242, 23);
            cbSuppliers.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 388);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 10;
            label8.Text = "Supplier";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 0);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(610, 651);
            dgvProducts.TabIndex = 14;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 651);
            Controls.Add(dgvProducts);
            Controls.Add(panel1);
            Name = "Products";
            Text = "Products";
            Load += Products_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDescription;
        private TextBox txtName;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnAdd;
        private Button btnDelete;
        private Label lblProductName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox cbkIsService;
        private ComboBox cbCategory;
        private TextBox txtBarcode;
        private Label label6;
        private TextBox txtCostPrice;
        private TextBox txtTaxRate;
        private TextBox txtSellingPrice;
        private Label label7;
        private TextBox txtDiscount;
        private Label label5;
        private Panel panel1;
        private DataGridView dgvProducts;
        private ComboBox cbSuppliers;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel1;
    }
}