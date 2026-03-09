namespace Crud2._0
{
    partial class Categories
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
            btnDelete = new Button();
            txtName = new TextBox();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            lblName = new Label();
            lblDescription = new Label();
            panel1 = new Panel();
            dgvCategories = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Gray;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14.25F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(3, 81);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(223, 33);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(2, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(224, 23);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(2, 98);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(224, 23);
            txtDescription.TabIndex = 1;
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
            btnAdd.Size = new Size(223, 33);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(3, 120);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(223, 34);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Gray;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 14.25F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(3, 42);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(223, 33);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(3, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(3, 80);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(lblDescription);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(txtName);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(515, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 367);
            panel1.TabIndex = 4;
            // 
            // dgvCategories
            // 
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Location = new Point(0, 0);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.Size = new Size(515, 367);
            dgvCategories.TabIndex = 5;
            dgvCategories.SelectionChanged += dgvCategories_SelectedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnUpdate, 0, 1);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDelete, 0, 2);
            tableLayoutPanel1.Controls.Add(btnClear, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 210);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(229, 157);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 367);
            Controls.Add(dgvCategories);
            Controls.Add(panel1);
            Name = "Categories";
            Text = "Categories";
            Load += Categories_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnClear;
        private Button btnUpdate;
        private Label lblName;
        private Label lblDescription;
        private Panel panel1;
        private DataGridView dgvCategories;
        private TableLayoutPanel tableLayoutPanel1;
    }
}