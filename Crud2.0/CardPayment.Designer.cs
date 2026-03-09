namespace Crud2._0
{
    partial class CardPayment
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
            dgvCart = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            cbCustomers = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTransactionReference = new Label();
            txtTransactionReference = new TextBox();
            txtTotal = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(800, 450);
            dgvCart.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbCustomers);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTotal);
            panel1.Controls.Add(lblTransactionReference);
            panel1.Controls.Add(txtTransactionReference);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(552, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 450);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 118);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 4;
            label1.Text = "Customer";
            // 
            // cbCustomers
            // 
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new Point(3, 136);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new Size(233, 23);
            cbCustomers.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 388);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(248, 31);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Bottom;
            btnCancel.Location = new Point(0, 419);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(248, 31);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTransactionReference
            // 
            lblTransactionReference.AutoSize = true;
            lblTransactionReference.Location = new Point(3, 59);
            lblTransactionReference.Name = "lblTransactionReference";
            lblTransactionReference.Size = new Size(122, 15);
            lblTransactionReference.TabIndex = 1;
            lblTransactionReference.Text = "Transaction Reference";
            // 
            // txtTransactionReference
            // 
            txtTransactionReference.Location = new Point(3, 77);
            txtTransactionReference.Name = "txtTransactionReference";
            txtTransactionReference.Size = new Size(233, 23);
            txtTransactionReference.TabIndex = 0;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(3, 27);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(233, 23);
            txtTotal.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Cost";
            // 
            // CardPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dgvCart);
            Name = "CardPayment";
            Text = "CardPayment";
            Load += CardPayment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCart;
        private Panel panel1;
        private Label lblTransactionReference;
        private TextBox txtTransactionReference;
        private Button btnCancel;
        private Button btnSave;
        private ComboBox cbCustomers;
        private Label label1;
        private Label label2;
        private TextBox txtTotal;
    }
}