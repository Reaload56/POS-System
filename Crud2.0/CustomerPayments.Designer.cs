namespace Crud2._0
{
    partial class CustomerPayments
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
            lblCustomerName = new Label();
            lblCurrentBalance = new Label();
            txtBalance = new TextBox();
            nudAmount = new NumericUpDown();
            lblAmount = new Label();
            cbPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            lblReference = new Label();
            txtReference = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnAddPayment = new Button();
            panel1 = new Panel();
            cbCustomers = new ComboBox();
            dgvPayments = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(3, 11);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(94, 15);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Customer Name";
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Location = new Point(3, 52);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(91, 15);
            lblCurrentBalance.TabIndex = 0;
            lblCurrentBalance.Text = "Current Balance";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(121, 52);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(170, 23);
            txtBalance.TabIndex = 1;
            // 
            // nudAmount
            // 
            nudAmount.Location = new Point(120, 110);
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(170, 23);
            nudAmount.TabIndex = 2;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(2, 118);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(51, 15);
            lblAmount.TabIndex = 0;
            lblAmount.Text = "Amount";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.FormattingEnabled = true;
            cbPaymentMethod.Location = new Point(120, 139);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(170, 23);
            cbPaymentMethod.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(3, 142);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(99, 15);
            lblPaymentMethod.TabIndex = 0;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Location = new Point(3, 173);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(59, 15);
            lblReference.TabIndex = 0;
            lblReference.Text = "Reference";
            // 
            // txtReference
            // 
            txtReference.Location = new Point(120, 170);
            txtReference.Name = "txtReference";
            txtReference.Size = new Size(170, 23);
            txtReference.TabIndex = 1;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(2, 199);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(38, 15);
            lblNotes.TabIndex = 0;
            lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(61, 199);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(228, 150);
            txtNotes.TabIndex = 1;
            // 
            // btnAddPayment
            // 
            btnAddPayment.BackColor = Color.Gray;
            btnAddPayment.Dock = DockStyle.Bottom;
            btnAddPayment.FlatStyle = FlatStyle.Flat;
            btnAddPayment.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddPayment.ForeColor = Color.White;
            btnAddPayment.Location = new Point(0, 399);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(302, 51);
            btnAddPayment.TabIndex = 4;
            btnAddPayment.Text = "Add Payment";
            btnAddPayment.UseVisualStyleBackColor = false;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCustomerName);
            panel1.Controls.Add(btnAddPayment);
            panel1.Controls.Add(lblReference);
            panel1.Controls.Add(cbCustomers);
            panel1.Controls.Add(cbPaymentMethod);
            panel1.Controls.Add(lblNotes);
            panel1.Controls.Add(nudAmount);
            panel1.Controls.Add(lblCurrentBalance);
            panel1.Controls.Add(txtNotes);
            panel1.Controls.Add(lblAmount);
            panel1.Controls.Add(txtReference);
            panel1.Controls.Add(lblPaymentMethod);
            panel1.Controls.Add(txtBalance);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(498, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 450);
            panel1.TabIndex = 5;
            // 
            // cbCustomers
            // 
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new Point(121, 12);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new Size(170, 23);
            cbCustomers.TabIndex = 3;
            cbCustomers.SelectedIndexChanged += cbCustomers_SelectedIndexChanged;
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(0, 0);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.Size = new Size(498, 450);
            dgvPayments.TabIndex = 6;
            // 
            // CustomerPayments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPayments);
            Controls.Add(panel1);
            Name = "CustomerPayments";
            Text = "CustomerPayments";
            Load += CustomerPayments_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCustomerName;
        private Label lblCurrentBalance;
        private TextBox txtBalance;
        private NumericUpDown nudAmount;
        private Label lblAmount;
        private ComboBox cbPaymentMethod;
        private Label lblPaymentMethod;
        private Label lblReference;
        private TextBox txtReference;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnAddPayment;
        private Panel panel1;
        private DataGridView dgvPayments;
        private ComboBox cbCustomers;
    }
}