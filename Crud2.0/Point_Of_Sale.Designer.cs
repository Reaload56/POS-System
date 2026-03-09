namespace Crud2._0
{
    partial class Point_Of_Sale
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
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            btnSearch = new Button();
            dgvCart = new DataGridView();
            btnAddToCart = new Button();
            lblQty = new Label();
            btnClearCart = new Button();
            btnCheckOut = new Button();
            numUdQuantity = new NumericUpDown();
            btnRemove = new Button();
            txtNotes = new TextBox();
            lblNotes = new Label();
            cbPaymentMethods = new ComboBox();
            lblPaymentMethod = new Label();
            lblTax = new Label();
            lblDiscount = new Label();
            lblTotal = new Label();
            lblChange = new Label();
            txtTax = new TextBox();
            txtDiscount = new TextBox();
            txtTotal = new TextBox();
            txtChange = new TextBox();
            lblBalance = new Label();
            label8 = new Label();
            lblCash = new Label();
            txtBalance = new TextBox();
            txtSubPrice = new TextBox();
            txtCash = new TextBox();
            lblCustomer = new Label();
            lblGlobalDiscount = new Label();
            cbCustomers = new ComboBox();
            txtGlobalDiscount = new TextBox();
            panel2 = new Panel();
            btnReload = new Button();
            panel3 = new Panel();
            btnNewCustomer = new Button();
            panel4 = new Panel();
            btnViewCart = new Button();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUdQuantity).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(212, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(282, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.BackgroundColor = SystemColors.Window;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(3, 3);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(898, 638);
            dgvProducts.TabIndex = 3;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
            dgvProducts.SelectionChanged += dgvProducts_SelectedChanged;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(500, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 27);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = SystemColors.Window;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(907, 3);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(33, 638);
            dgvCart.TabIndex = 7;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.Gray;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(410, 3);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(93, 42);
            btnAddToCart.TabIndex = 12;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lblQty
            // 
            lblQty.BackColor = SystemColors.Window;
            lblQty.Location = new Point(232, 6);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(37, 20);
            lblQty.TabIndex = 10;
            lblQty.Text = "Qty";
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.Gray;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 11.25F);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(632, 5);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(101, 38);
            btnClearCart.TabIndex = 12;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.Gray;
            btnCheckOut.Dock = DockStyle.Bottom;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(0, 640);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(327, 52);
            btnCheckOut.TabIndex = 12;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // numUdQuantity
            // 
            numUdQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numUdQuantity.Location = new Point(275, 6);
            numUdQuantity.Name = "numUdQuantity";
            numUdQuantity.Size = new Size(117, 29);
            numUdQuantity.TabIndex = 19;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Gray;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 11.25F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(518, 6);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(92, 36);
            btnRemove.TabIndex = 12;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemoveFromCart_Click;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotes.Location = new Point(6, 455);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(317, 138);
            txtNotes.TabIndex = 2;
            // 
            // lblNotes
            // 
            lblNotes.BackColor = SystemColors.Window;
            lblNotes.Location = new Point(22, 432);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(94, 20);
            lblNotes.TabIndex = 0;
            lblNotes.Text = "Notes";
            // 
            // cbPaymentMethods
            // 
            cbPaymentMethods.FormattingEnabled = true;
            cbPaymentMethods.Items.AddRange(new object[] { "Cash", "CreditCard" });
            cbPaymentMethods.Location = new Point(23, 385);
            cbPaymentMethods.Name = "cbPaymentMethods";
            cbPaymentMethods.Size = new Size(285, 23);
            cbPaymentMethods.TabIndex = 16;
            cbPaymentMethods.SelectedIndexChanged += cbPaymentMethods_SelectedIndexChanged;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.BackColor = SystemColors.Window;
            lblPaymentMethod.Location = new Point(23, 362);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(107, 20);
            lblPaymentMethod.TabIndex = 0;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // lblTax
            // 
            lblTax.BackColor = SystemColors.Window;
            lblTax.Location = new Point(23, 209);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(94, 20);
            lblTax.TabIndex = 0;
            lblTax.Text = "Tax";
            // 
            // lblDiscount
            // 
            lblDiscount.BackColor = SystemColors.Window;
            lblDiscount.Location = new Point(23, 241);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(94, 20);
            lblDiscount.TabIndex = 0;
            lblDiscount.Text = "Discount";
            // 
            // lblTotal
            // 
            lblTotal.BackColor = SystemColors.Window;
            lblTotal.Location = new Point(23, 270);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total";
            // 
            // lblChange
            // 
            lblChange.BackColor = SystemColors.Window;
            lblChange.Location = new Point(24, 305);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(94, 20);
            lblChange.TabIndex = 0;
            lblChange.Text = "Change";
            // 
            // txtTax
            // 
            txtTax.Location = new Point(127, 209);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(191, 23);
            txtTax.TabIndex = 2;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(127, 241);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.ReadOnly = true;
            txtDiscount.Size = new Size(191, 23);
            txtDiscount.TabIndex = 2;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(127, 270);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(191, 27);
            txtTotal.TabIndex = 2;
            // 
            // txtChange
            // 
            txtChange.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChange.Location = new Point(128, 305);
            txtChange.Name = "txtChange";
            txtChange.ReadOnly = true;
            txtChange.Size = new Size(191, 27);
            txtChange.TabIndex = 2;
            // 
            // lblBalance
            // 
            lblBalance.BackColor = SystemColors.Window;
            lblBalance.Location = new Point(23, 178);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(94, 20);
            lblBalance.TabIndex = 0;
            lblBalance.Text = "Balance";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.Window;
            label8.Location = new Point(23, 149);
            label8.Name = "label8";
            label8.Size = new Size(94, 20);
            label8.TabIndex = 0;
            label8.Text = "Sub Price";
            // 
            // lblCash
            // 
            lblCash.BackColor = SystemColors.Window;
            lblCash.Location = new Point(22, 118);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(94, 20);
            lblCash.TabIndex = 0;
            lblCash.Text = "Cash";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(127, 178);
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(191, 23);
            txtBalance.TabIndex = 2;
            // 
            // txtSubPrice
            // 
            txtSubPrice.Location = new Point(127, 149);
            txtSubPrice.Name = "txtSubPrice";
            txtSubPrice.ReadOnly = true;
            txtSubPrice.Size = new Size(191, 23);
            txtSubPrice.TabIndex = 2;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(126, 118);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(191, 23);
            txtCash.TabIndex = 2;
            txtCash.TextChanged += txtCash_TextChanged;
            // 
            // lblCustomer
            // 
            lblCustomer.BackColor = SystemColors.Window;
            lblCustomer.Location = new Point(23, 54);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(94, 20);
            lblCustomer.TabIndex = 11;
            lblCustomer.Text = "Customer";
            // 
            // lblGlobalDiscount
            // 
            lblGlobalDiscount.BackColor = SystemColors.Window;
            lblGlobalDiscount.Location = new Point(5, 13);
            lblGlobalDiscount.Name = "lblGlobalDiscount";
            lblGlobalDiscount.Size = new Size(116, 23);
            lblGlobalDiscount.TabIndex = 11;
            lblGlobalDiscount.Text = "Global Discount (%)";
            // 
            // cbCustomers
            // 
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new Point(127, 54);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new Size(191, 23);
            cbCustomers.TabIndex = 16;
            cbCustomers.SelectedIndexChanged += cbCustomers_SelectedIndexChanged;
            // 
            // txtGlobalDiscount
            // 
            txtGlobalDiscount.Location = new Point(127, 13);
            txtGlobalDiscount.Name = "txtGlobalDiscount";
            txtGlobalDiscount.ReadOnly = true;
            txtGlobalDiscount.Size = new Size(191, 23);
            txtGlobalDiscount.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnReload);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1273, 32);
            panel2.TabIndex = 22;
            // 
            // btnReload
            // 
            btnReload.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnReload.ImageAlign = ContentAlignment.MiddleLeft;
            btnReload.Location = new Point(606, 2);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(75, 27);
            btnReload.TabIndex = 1;
            btnReload.Text = "Reload";
            btnReload.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(btnNewCustomer);
            panel3.Controls.Add(lblNotes);
            panel3.Controls.Add(btnCheckOut);
            panel3.Controls.Add(txtNotes);
            panel3.Controls.Add(txtSubPrice);
            panel3.Controls.Add(txtGlobalDiscount);
            panel3.Controls.Add(lblTax);
            panel3.Controls.Add(lblDiscount);
            panel3.Controls.Add(cbPaymentMethods);
            panel3.Controls.Add(lblTotal);
            panel3.Controls.Add(cbCustomers);
            panel3.Controls.Add(lblPaymentMethod);
            panel3.Controls.Add(lblChange);
            panel3.Controls.Add(lblBalance);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(lblCash);
            panel3.Controls.Add(txtTax);
            panel3.Controls.Add(txtDiscount);
            panel3.Controls.Add(txtTotal);
            panel3.Controls.Add(txtChange);
            panel3.Controls.Add(txtBalance);
            panel3.Controls.Add(lblGlobalDiscount);
            panel3.Controls.Add(txtCash);
            panel3.Controls.Add(lblCustomer);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(946, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(327, 692);
            panel3.TabIndex = 23;
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.BackColor = Color.Gray;
            btnNewCustomer.FlatStyle = FlatStyle.Flat;
            btnNewCustomer.ForeColor = Color.SkyBlue;
            btnNewCustomer.Location = new Point(24, 83);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(291, 28);
            btnNewCustomer.TabIndex = 21;
            btnNewCustomer.Text = "Add New Customer";
            btnNewCustomer.UseVisualStyleBackColor = false;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblQty);
            panel4.Controls.Add(btnViewCart);
            panel4.Controls.Add(btnAddToCart);
            panel4.Controls.Add(numUdQuantity);
            panel4.Controls.Add(btnRemove);
            panel4.Controls.Add(btnClearCart);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 679);
            panel4.Name = "panel4";
            panel4.Size = new Size(946, 45);
            panel4.TabIndex = 24;
            // 
            // btnViewCart
            // 
            btnViewCart.BackColor = Color.Gray;
            btnViewCart.FlatStyle = FlatStyle.Flat;
            btnViewCart.ForeColor = Color.White;
            btnViewCart.Location = new Point(739, 4);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(84, 42);
            btnViewCart.TabIndex = 12;
            btnViewCart.Text = "View Cart";
            btnViewCart.UseVisualStyleBackColor = false;
            btnViewCart.Click += btnViewCart_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(dgvProducts);
            panel5.Controls.Add(dgvCart);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 32);
            panel5.Name = "panel5";
            panel5.Size = new Size(946, 647);
            panel5.TabIndex = 24;
            // 
            // Point_Of_Sale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 724);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Point_Of_Sale";
            Text = "Point_Of_Sale";
            WindowState = FormWindowState.Maximized;
            Load += Point_Of_Sale_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUdQuantity).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private Button btnSearch;
        private DataGridView dgvCart;
        private Button btnAddToCart;
        private Label lblQty;
        private Button btnClearCart;
        private Button btnCheckOut;
        private NumericUpDown numUdQuantity;
        private Button btnRemove;
        private TextBox txtNotes;
        private Label lblNotes;
        private ComboBox cbPaymentMethods;
        private Label lblPaymentMethod;
        private Label lblTax;
        private Label lblDiscount;
        private Label lblTotal;
        private Label lblChange;
        private TextBox txtTax;
        private TextBox txtDiscount;
        private TextBox txtTotal;
        private TextBox txtChange;
        private Label lblBalance;
        private Label label8;
        private Label lblCash;
        private TextBox txtBalance;
        private TextBox txtSubPrice;
        private TextBox txtCash;
        private Label lblCustomer;
        private Label lblGlobalDiscount;
        private ComboBox cbCustomers;
        private TextBox txtGlobalDiscount;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button btnViewCart;
        private Button btnNewCustomer;
        private Button btnReload;
    }
}