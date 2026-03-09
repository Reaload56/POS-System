namespace Crud2._0
{
    partial class CheckOut
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
            btnCancelSale = new Button();
            pnlDebt = new Panel();
            dateTimePicker1 = new DateTimePicker();
            btnSaveDebt = new Button();
            label3 = new Label();
            dgvCart = new DataGridView();
            btnCheckOut = new Button();
            btnSaveCredit = new Button();
            pnlCredit = new Panel();
            txtGlobalDiscount = new TextBox();
            cbCustomers = new ComboBox();
            lblGlobalDiscount = new Label();
            lblCustomer = new Label();
            txtBalance = new TextBox();
            txtChange = new TextBox();
            txtTotal = new TextBox();
            txtDiscount = new TextBox();
            txtTax = new TextBox();
            lblCash = new Label();
            label8 = new Label();
            lblCredit = new Label();
            lblChange = new Label();
            lblTotal = new Label();
            lblDiscount = new Label();
            lblTax = new Label();
            txtSubPrice = new TextBox();
            label2 = new Label();
            txtAvailableChange = new TextBox();
            printDoc = new System.Drawing.Printing.PrintDocument();
            txtCash = new TextBox();
            pnlDebt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlCredit.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelSale
            // 
            btnCancelSale.Location = new Point(516, 361);
            btnCancelSale.Name = "btnCancelSale";
            btnCancelSale.Size = new Size(74, 50);
            btnCancelSale.TabIndex = 0;
            btnCancelSale.Text = "Cancel Sale";
            btnCancelSale.UseVisualStyleBackColor = true;
            btnCancelSale.Click += btnCancelSale_Click;
            // 
            // pnlDebt
            // 
            pnlDebt.Controls.Add(dateTimePicker1);
            pnlDebt.Controls.Add(btnSaveDebt);
            pnlDebt.Controls.Add(label3);
            pnlDebt.Location = new Point(596, 361);
            pnlDebt.Name = "pnlDebt";
            pnlDebt.Size = new Size(272, 56);
            pnlDebt.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(85, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(187, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // btnSaveDebt
            // 
            btnSaveDebt.Location = new Point(187, 3);
            btnSaveDebt.Name = "btnSaveDebt";
            btnSaveDebt.Size = new Size(85, 24);
            btnSaveDebt.TabIndex = 0;
            btnSaveDebt.Text = "Save Debt";
            btnSaveDebt.UseVisualStyleBackColor = true;
            btnSaveDebt.Click += btnSaveDebt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 36);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 1;
            label3.Text = "Payback Date";
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Left;
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(510, 449);
            dgvCart.TabIndex = 3;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(175, 3);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(85, 39);
            btnCheckOut.TabIndex = 0;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnSaveCredit
            // 
            btnSaveCredit.Location = new Point(84, 3);
            btnSaveCredit.Name = "btnSaveCredit";
            btnSaveCredit.Size = new Size(85, 39);
            btnSaveCredit.TabIndex = 0;
            btnSaveCredit.Text = "Save Credit";
            btnSaveCredit.UseVisualStyleBackColor = true;
            btnSaveCredit.Click += btnSaveCredit_Click;
            // 
            // pnlCredit
            // 
            pnlCredit.Controls.Add(btnSaveCredit);
            pnlCredit.Controls.Add(btnCheckOut);
            pnlCredit.Location = new Point(596, 361);
            pnlCredit.Name = "pnlCredit";
            pnlCredit.Size = new Size(280, 47);
            pnlCredit.TabIndex = 2;
            // 
            // txtGlobalDiscount
            // 
            txtGlobalDiscount.Location = new Point(673, 9);
            txtGlobalDiscount.Name = "txtGlobalDiscount";
            txtGlobalDiscount.ReadOnly = true;
            txtGlobalDiscount.Size = new Size(196, 23);
            txtGlobalDiscount.TabIndex = 37;
            // 
            // cbCustomers
            // 
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new Point(672, 37);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new Size(194, 23);
            cbCustomers.TabIndex = 36;
            cbCustomers.SelectedIndexChanged += cbCustomers_SelectedIndexChanged;
            // 
            // lblGlobalDiscount
            // 
            lblGlobalDiscount.BackColor = SystemColors.Window;
            lblGlobalDiscount.Location = new Point(516, 9);
            lblGlobalDiscount.Name = "lblGlobalDiscount";
            lblGlobalDiscount.Size = new Size(114, 23);
            lblGlobalDiscount.TabIndex = 35;
            lblGlobalDiscount.Text = "Global Discount (%)";
            // 
            // lblCustomer
            // 
            lblCustomer.BackColor = SystemColors.Window;
            lblCustomer.Location = new Point(515, 40);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(94, 27);
            lblCustomer.TabIndex = 34;
            lblCustomer.Text = "Customer";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(673, 128);
            txtBalance.Name = "txtBalance";
            txtBalance.ReadOnly = true;
            txtBalance.Size = new Size(194, 23);
            txtBalance.TabIndex = 31;
            // 
            // txtChange
            // 
            txtChange.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChange.Location = new Point(674, 255);
            txtChange.Name = "txtChange";
            txtChange.ReadOnly = true;
            txtChange.Size = new Size(194, 27);
            txtChange.TabIndex = 30;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(673, 220);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(194, 27);
            txtTotal.TabIndex = 33;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(673, 189);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.ReadOnly = true;
            txtDiscount.Size = new Size(194, 23);
            txtDiscount.TabIndex = 29;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(673, 159);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(194, 23);
            txtTax.TabIndex = 28;
            // 
            // lblCash
            // 
            lblCash.BackColor = SystemColors.Window;
            lblCash.Location = new Point(515, 71);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(94, 27);
            lblCash.TabIndex = 26;
            lblCash.Text = "Cash";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.Window;
            label8.Location = new Point(516, 102);
            label8.Name = "label8";
            label8.Size = new Size(94, 27);
            label8.TabIndex = 25;
            label8.Text = "Sub Price";
            // 
            // lblCredit
            // 
            lblCredit.BackColor = SystemColors.Window;
            lblCredit.Location = new Point(516, 131);
            lblCredit.Name = "lblCredit";
            lblCredit.Size = new Size(94, 27);
            lblCredit.TabIndex = 24;
            lblCredit.Text = "Balance";
            // 
            // lblChange
            // 
            lblChange.BackColor = SystemColors.Window;
            lblChange.Location = new Point(517, 258);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(94, 27);
            lblChange.TabIndex = 23;
            lblChange.Text = "Change";
            // 
            // lblTotal
            // 
            lblTotal.BackColor = SystemColors.Window;
            lblTotal.Location = new Point(516, 223);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 27);
            lblTotal.TabIndex = 22;
            lblTotal.Text = "Total";
            // 
            // lblDiscount
            // 
            lblDiscount.BackColor = SystemColors.Window;
            lblDiscount.Location = new Point(516, 194);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(94, 27);
            lblDiscount.TabIndex = 27;
            lblDiscount.Text = "Discount";
            // 
            // lblTax
            // 
            lblTax.BackColor = SystemColors.Window;
            lblTax.Location = new Point(516, 162);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(94, 27);
            lblTax.TabIndex = 21;
            lblTax.Text = "Tax";
            // 
            // txtSubPrice
            // 
            txtSubPrice.Location = new Point(673, 99);
            txtSubPrice.Name = "txtSubPrice";
            txtSubPrice.ReadOnly = true;
            txtSubPrice.Size = new Size(194, 23);
            txtSubPrice.TabIndex = 38;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Window;
            label2.Location = new Point(517, 297);
            label2.Name = "label2";
            label2.Size = new Size(111, 27);
            label2.TabIndex = 23;
            label2.Text = "Available Change";
            // 
            // txtAvailableChange
            // 
            txtAvailableChange.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAvailableChange.Location = new Point(674, 294);
            txtAvailableChange.Name = "txtAvailableChange";
            txtAvailableChange.Size = new Size(194, 27);
            txtAvailableChange.TabIndex = 30;
            // 
            // printDoc
            // 
            printDoc.PrintPage += printDoc_PrintPage;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(672, 68);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(194, 23);
            txtCash.TabIndex = 32;
            txtCash.TextChanged += txtCash_TextChanged;
            // 
            // CheckOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 449);
            Controls.Add(txtSubPrice);
            Controls.Add(btnCancelSale);
            Controls.Add(txtGlobalDiscount);
            Controls.Add(cbCustomers);
            Controls.Add(lblGlobalDiscount);
            Controls.Add(lblCustomer);
            Controls.Add(txtCash);
            Controls.Add(txtBalance);
            Controls.Add(txtAvailableChange);
            Controls.Add(txtChange);
            Controls.Add(txtTotal);
            Controls.Add(txtDiscount);
            Controls.Add(txtTax);
            Controls.Add(lblCash);
            Controls.Add(label8);
            Controls.Add(lblCredit);
            Controls.Add(label2);
            Controls.Add(lblChange);
            Controls.Add(lblTotal);
            Controls.Add(lblDiscount);
            Controls.Add(lblTax);
            Controls.Add(dgvCart);
            Controls.Add(pnlCredit);
            Controls.Add(pnlDebt);
            Name = "CheckOut";
            Text = "CheckOut";
            Load += CheckOut_Load;
            pnlDebt.ResumeLayout(false);
            pnlDebt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlCredit.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelSale;
        private Panel pnlDebt;
        private DataGridView dgvCart;
        private Button btnSaveDebt;
        private Button btnCheckOut;
        private Button btnSaveCredit;
        private Panel pnlCredit;
        private TextBox txtGlobalDiscount;
        private ComboBox cbCustomers;
        private Label lblGlobalDiscount;
        private Label lblCustomer;
        private TextBox txtBalance;
        private TextBox txtChange;
        private TextBox txtTotal;
        private TextBox txtDiscount;
        private TextBox txtTax;
        private Label lblCash;
        private Label label8;
        private Label lblCredit;
        private Label lblChange;
        private Label lblTotal;
        private Label lblDiscount;
        private Label lblTax;
        private TextBox txtSubPrice;
        private Label label2;
        private TextBox txtAvailableChange;
        private System.Drawing.Printing.PrintDocument printDoc;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox txtCash;
    }
}