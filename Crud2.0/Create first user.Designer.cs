namespace Crud2._0
{
    partial class Create_first_user
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
            btnCreateUser = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(134, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(173, 23);
            txtEmail.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(134, 179);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(173, 23);
            txtAddress.TabIndex = 10;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(134, 121);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(173, 23);
            txtFullName.TabIndex = 11;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(134, 92);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(173, 23);
            txtConfirmPassword.TabIndex = 12;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(134, 63);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(173, 23);
            txtPassword.TabIndex = 13;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(134, 34);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(173, 23);
            txtUserName.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 153);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 182);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 4;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 124);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Full Name";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(12, 95);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(104, 15);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 66);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 37);
            lblName.Name = "lblName";
            lblName.Size = new Size(65, 15);
            lblName.TabIndex = 8;
            lblName.Text = "User Name";
            // 
            // btnCreateUser
            // 
            btnCreateUser.BackColor = Color.Gray;
            btnCreateUser.FlatStyle = FlatStyle.Flat;
            btnCreateUser.Location = new Point(12, 208);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(295, 46);
            btnCreateUser.TabIndex = 15;
            btnCreateUser.Text = "Create User";
            btnCreateUser.UseVisualStyleBackColor = false;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(92, -4);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 8;
            label2.Text = "Create a user";
            // 
            // Create_first_user
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 264);
            Controls.Add(btnCreateUser);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtFullName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(label2);
            Controls.Add(lblName);
            MaximizeBox = false;
            MaximumSize = new Size(332, 303);
            MinimumSize = new Size(332, 303);
            Name = "Create_first_user";
            Text = "Create_first_user";
            Load += Create_first_user_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtAddress;
        private TextBox txtFullName;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label lblConfirmPassword;
        private Label lblPassword;
        private Label lblName;
        private Button btnCreateUser;
        private Label label2;
    }
}