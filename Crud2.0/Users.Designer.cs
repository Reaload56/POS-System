namespace Crud2._0
{
    partial class Users
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
            panel2 = new Panel();
            panel1 = new Panel();
            btnAdmin = new Button();
            btnCashier = new Button();
            lblRole = new Label();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtFullName = new TextBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblConfirmPassword = new Label();
            lblPassword = new Label();
            lblName = new Label();
            btnDeleteUser = new Button();
            txtUpdateUser = new Button();
            btnAddUser = new Button();
            dgvUsers = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(txtFullName);
            panel2.Controls.Add(txtConfirmPassword);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblConfirmPassword);
            panel2.Controls.Add(lblPassword);
            panel2.Controls.Add(lblName);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(562, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(302, 450);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdmin);
            panel1.Controls.Add(btnCashier);
            panel1.Controls.Add(lblRole);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 42);
            panel1.TabIndex = 3;
            // 
            // btnAdmin
            // 
            btnAdmin.Font = new Font("Segoe UI Emoji", 12F);
            btnAdmin.Location = new Point(52, 6);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(122, 33);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnCashier
            // 
            btnCashier.Font = new Font("Segoe UI Emoji", 12F);
            btnCashier.Location = new Point(180, 6);
            btnCashier.Name = "btnCashier";
            btnCashier.Size = new Size(122, 33);
            btnCashier.TabIndex = 0;
            btnCashier.Text = "Cashier";
            btnCashier.UseVisualStyleBackColor = true;
            btnCashier.Click += btnCashier_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(8, 12);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 1;
            lblRole.Text = "Role";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(126, 120);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(173, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(126, 149);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(173, 23);
            txtAddress.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(126, 91);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(173, 23);
            txtFullName.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(126, 62);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(173, 23);
            txtConfirmPassword.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(126, 33);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(173, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(126, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(173, 23);
            txtUserName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 123);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 152);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 1;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 94);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 1;
            label3.Text = "Full Name";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(4, 65);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(104, 15);
            lblConfirmPassword.TabIndex = 1;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(4, 36);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(4, 7);
            lblName.Name = "lblName";
            lblName.Size = new Size(65, 15);
            lblName.TabIndex = 1;
            lblName.Text = "User Name";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.Gray;
            btnDeleteUser.Dock = DockStyle.Fill;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 14.25F);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(3, 147);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(296, 43);
            btnDeleteUser.TabIndex = 0;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // txtUpdateUser
            // 
            txtUpdateUser.BackColor = Color.Gray;
            txtUpdateUser.Dock = DockStyle.Fill;
            txtUpdateUser.FlatStyle = FlatStyle.Flat;
            txtUpdateUser.Font = new Font("Segoe UI", 14.25F);
            txtUpdateUser.ForeColor = Color.White;
            txtUpdateUser.Location = new Point(3, 99);
            txtUpdateUser.Name = "txtUpdateUser";
            txtUpdateUser.Size = new Size(296, 42);
            txtUpdateUser.TabIndex = 0;
            txtUpdateUser.Text = "Update User";
            txtUpdateUser.UseVisualStyleBackColor = false;
            txtUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.Gray;
            btnAddUser.Dock = DockStyle.Fill;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 14.25F);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(3, 51);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(296, 42);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(562, 450);
            dgvUsers.TabIndex = 3;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(txtUpdateUser, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDeleteUser, 0, 3);
            tableLayoutPanel1.Controls.Add(btnAddUser, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 257);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(302, 193);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 450);
            Controls.Add(dgvUsers);
            Controls.Add(panel2);
            Name = "Users";
            Text = "Users";
            Load += Users_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private TextBox txtUserName;
        private Label lblName;
        private Button btnAddUser;
        private Button btnAdmin;
        private Button btnCashier;
        private TextBox txtAddress;
        private TextBox txtFullName;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private Label label4;
        private Label label3;
        private Label lblConfirmPassword;
        private Label lblPassword;
        private TextBox txtEmail;
        private Label label1;
        private Label lblRole;
        private Button txtUpdateUser;
        private Button btnDeleteUser;
        private Panel panel1;
        private DataGridView dgvUsers;
        private TableLayoutPanel tableLayoutPanel1;
    }
}