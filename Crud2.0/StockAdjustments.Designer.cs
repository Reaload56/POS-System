namespace Crud2._0
{
    partial class StockAdjustments
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
            btnSave = new Button();
            txtQuantity = new TextBox();
            txtReason = new TextBox();
            cmbProducts = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            btnFilter = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            dgvAdjustments = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Gray;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14.25F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 331);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(293, 42);
            btnSave.TabIndex = 1;
            btnSave.Text = "Subtract Stock";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(112, 39);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(178, 23);
            txtQuantity.TabIndex = 2;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(111, 10);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(178, 23);
            txtReason.TabIndex = 2;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(111, 70);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(179, 23);
            cmbProducts.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 76);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 4;
            label1.Text = "Select Product";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 47);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 4;
            label2.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 13);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Reason";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(232, 8);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(189, 23);
            dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(3, 8);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(189, 23);
            dtpFrom.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.Gray;
            btnFilter.Dock = DockStyle.Bottom;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 14.25F);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(0, 373);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(293, 42);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpFrom);
            panel1.Controls.Add(dtpTo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbProducts);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnFilter);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtQuantity);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtReason);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(507, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(293, 415);
            panel2.TabIndex = 0;
            // 
            // dgvAdjustments
            // 
            dgvAdjustments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdjustments.Dock = DockStyle.Fill;
            dgvAdjustments.Location = new Point(0, 35);
            dgvAdjustments.Name = "dgvAdjustments";
            dgvAdjustments.Size = new Size(507, 415);
            dgvAdjustments.TabIndex = 1;
            // 
            // StockAdjustments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAdjustments);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockAdjustments";
            Text = "StockAdjustments";
            Load += StockAdjustments_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjustments).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSave;
        private TextBox txtQuantity;
        private TextBox txtReason;
        private ComboBox cmbProducts;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Button btnFilter;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvAdjustments;
    }
}