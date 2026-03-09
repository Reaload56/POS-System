namespace Crud2._0
{
    partial class Suppliers
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
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            lblContact = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtAddress = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            txtContact = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnClear = new Button();
            btnAddSupplier = new Button();
            btnUpdateSupplier = new Button();
            btnDeleteSupplier = new Button();
            dgvSuppliers = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(587, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 450);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblContact);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(txtContact);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(318, 281);
            panel2.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Name";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(3, 38);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(49, 15);
            lblContact.TabIndex = 8;
            lblContact.Text = "Contact";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(125, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(173, 23);
            txtEmail.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 99);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 4;
            label4.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(125, 96);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(173, 23);
            txtAddress.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 70);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(125, 8);
            txtName.Name = "txtName";
            txtName.Size = new Size(173, 23);
            txtName.TabIndex = 11;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(125, 38);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(173, 23);
            txtContact.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnClear, 0, 3);
            tableLayoutPanel1.Controls.Add(btnAddSupplier, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDeleteSupplier, 0, 2);
            tableLayoutPanel1.Controls.Add(btnUpdateSupplier, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 284);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(318, 166);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(3, 126);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(312, 35);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.BackColor = Color.Gray;
            btnAddSupplier.FlatStyle = FlatStyle.Flat;
            btnAddSupplier.Font = new Font("Segoe UI", 14.25F);
            btnAddSupplier.ForeColor = Color.White;
            btnAddSupplier.Location = new Point(3, 3);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(312, 35);
            btnAddSupplier.TabIndex = 17;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = false;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.BackColor = Color.Gray;
            btnUpdateSupplier.FlatStyle = FlatStyle.Flat;
            btnUpdateSupplier.Font = new Font("Segoe UI", 14.25F);
            btnUpdateSupplier.ForeColor = Color.White;
            btnUpdateSupplier.Location = new Point(3, 44);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(312, 35);
            btnUpdateSupplier.TabIndex = 16;
            btnUpdateSupplier.Text = "Update";
            btnUpdateSupplier.UseVisualStyleBackColor = false;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.BackColor = Color.Gray;
            btnDeleteSupplier.FlatStyle = FlatStyle.Flat;
            btnDeleteSupplier.Font = new Font("Segoe UI", 14.25F);
            btnDeleteSupplier.ForeColor = Color.White;
            btnDeleteSupplier.Location = new Point(3, 85);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(312, 35);
            btnDeleteSupplier.TabIndex = 15;
            btnDeleteSupplier.Text = "Delete";
            btnDeleteSupplier.UseVisualStyleBackColor = false;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Dock = DockStyle.Fill;
            dgvSuppliers.Location = new Point(0, 0);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(587, 450);
            dgvSuppliers.TabIndex = 1;
            dgvSuppliers.SelectionChanged += dgvSuppliers_SelectionChanged;
            // 
            // Suppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 450);
            Controls.Add(dgvSuppliers);
            Controls.Add(panel1);
            Name = "Suppliers";
            Text = "Suppliers";
            Load += Suppliers_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvSuppliers;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private TextBox txtName;
        private TextBox txtContact;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label lblContact;
        private Button btnDeleteSupplier;
        private Button btnUpdateSupplier;
        private Button btnAddSupplier;
        private Button btnClear;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
    }
}