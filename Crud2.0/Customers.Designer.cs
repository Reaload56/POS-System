namespace Crud2._0
{
    partial class Customers
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
            txtName = new TextBox();
            btnAdd = new Button();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblName = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblAddress = new Label();
            panel1 = new Panel();
            dgvCustomers = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(3, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(264, 23);
            txtName.TabIndex = 0;
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
            btnAdd.Size = new Size(264, 34);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(3, 66);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(264, 23);
            txtPhone.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(3, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(264, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(3, 154);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(264, 23);
            txtAddress.TabIndex = 0;
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
            btnUpdate.Size = new Size(264, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14.25F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(3, 123);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(264, 34);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(3, 83);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(264, 34);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(3, 4);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(3, 48);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 15);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(3, 92);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(3, 136);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(lblAddress);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblPhone);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtAddress);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(719, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 504);
            panel1.TabIndex = 5;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 0);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(719, 504);
            dgvCustomers.TabIndex = 6;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(btnUpdate, 0, 1);
            tableLayoutPanel1.Controls.Add(btnClear, 0, 2);
            tableLayoutPanel1.Controls.Add(btnDelete, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.ForeColor = Color.White;
            tableLayoutPanel1.Location = new Point(0, 344);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(270, 160);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 504);
            Controls.Add(dgvCustomers);
            Controls.Add(panel1);
            Name = "Customers";
            Text = "Customers";
            Load += Customers_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button btnAdd;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private TextBox txtDate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label lblName;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblAddress;
        private Panel panel1;
        private DataGridView dgvCustomers;
        private TableLayoutPanel tableLayoutPanel1;
    }
}