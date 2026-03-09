namespace Crud2._0
{
    partial class LogIn
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
            txtPassword = new TextBox();
            txtName = new TextBox();
            lblPassword = new Label();
            lblName = new Label();
            btnLogIn = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblClose = new Label();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 78);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(197, 23);
            txtPassword.TabIndex = 5;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(196, 23);
            txtName.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 78);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.Gray;
            btnLogIn.Dock = DockStyle.Bottom;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(0, 298);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(296, 45);
            btnLogIn.TabIndex = 7;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(lblName);
            panel2.Controls.Add(lblPassword);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(txtPassword);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 175);
            panel2.Name = "panel2";
            panel2.Size = new Size(296, 123);
            panel2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 143);
            panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Login;
            pictureBox1.Location = new Point(63, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblClose
            // 
            lblClose.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(262, -3);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(34, 36);
            lblClose.TabIndex = 2;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(102, -7);
            label1.Name = "label1";
            label1.Size = new Size(84, 37);
            label1.TabIndex = 3;
            label1.Text = "LogIn";
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(296, 343);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(lblClose);
            Controls.Add(panel2);
            Controls.Add(btnLogIn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LogIn";
            Text = "Log In";
            Load += LogIn_Load;
            MouseDown += LogIn_MouseDown;
            MouseMove += LogIn_MouseMove;
            MouseUp += LogIn_MouseUp;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtName;
        private Label lblPassword;
        private Label lblName;
        private Button btnLogIn;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblClose;
        private Label label1;
    }
}