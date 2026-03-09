namespace Crud2._0
{
    partial class Stocks
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
            btnAddStock = new Button();
            label2 = new Label();
            btnClear = new Button();
            label4 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel1 = new Panel();
            nudReOrderLevel = new NumericUpDown();
            nudQuantity = new NumericUpDown();
            btnEnsureStock = new Button();
            btnChangeReOrderLevel = new Button();
            label1 = new Label();
            panel2 = new Panel();
            dgvStock = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudReOrderLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddStock
            // 
            btnAddStock.BackColor = Color.Gray;
            btnAddStock.Dock = DockStyle.Fill;
            btnAddStock.Font = new Font("Segoe UI", 14.25F);
            btnAddStock.Location = new Point(3, 45);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(312, 36);
            btnAddStock.TabIndex = 0;
            btnAddStock.Text = "Add Stock";
            btnAddStock.UseVisualStyleBackColor = false;
            btnAddStock.Click += btnAddStock_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 8);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Quantity";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.Dock = DockStyle.Fill;
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.Location = new Point(3, 129);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(312, 39);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 1;
            label4.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(71, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(106, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(398, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(73, 24);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(nudReOrderLevel);
            panel1.Controls.Add(nudQuantity);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(516, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 450);
            panel1.TabIndex = 4;
            // 
            // nudReOrderLevel
            // 
            nudReOrderLevel.Location = new Point(130, 37);
            nudReOrderLevel.Name = "nudReOrderLevel";
            nudReOrderLevel.Size = new Size(185, 23);
            nudReOrderLevel.TabIndex = 5;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(130, 6);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(185, 23);
            nudQuantity.TabIndex = 5;
            // 
            // btnEnsureStock
            // 
            btnEnsureStock.BackColor = Color.Gray;
            btnEnsureStock.Dock = DockStyle.Fill;
            btnEnsureStock.Font = new Font("Segoe UI", 14.25F);
            btnEnsureStock.Location = new Point(3, 3);
            btnEnsureStock.Name = "btnEnsureStock";
            btnEnsureStock.Size = new Size(312, 36);
            btnEnsureStock.TabIndex = 4;
            btnEnsureStock.Text = "Ensure Stock";
            btnEnsureStock.UseVisualStyleBackColor = false;
            btnEnsureStock.Click += btnEnsureStock_Click;
            // 
            // btnChangeReOrderLevel
            // 
            btnChangeReOrderLevel.BackColor = Color.Gray;
            btnChangeReOrderLevel.Dock = DockStyle.Fill;
            btnChangeReOrderLevel.Font = new Font("Segoe UI", 14.25F);
            btnChangeReOrderLevel.Location = new Point(3, 87);
            btnChangeReOrderLevel.Name = "btnChangeReOrderLevel";
            btnChangeReOrderLevel.Size = new Size(312, 36);
            btnChangeReOrderLevel.TabIndex = 4;
            btnChangeReOrderLevel.Text = "Change ReOrder Level";
            btnChangeReOrderLevel.UseVisualStyleBackColor = false;
            btnChangeReOrderLevel.Click += btnChangeReOrderLevel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 39);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "ReOrder Level";
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(516, 39);
            panel2.TabIndex = 5;
            // 
            // dgvStock
            // 
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Dock = DockStyle.Fill;
            dgvStock.Location = new Point(0, 39);
            dgvStock.Name = "dgvStock";
            dgvStock.Size = new Size(516, 411);
            dgvStock.TabIndex = 6;
            dgvStock.SelectionChanged += dgvStock_SelectionChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnClear, 0, 3);
            tableLayoutPanel1.Controls.Add(btnChangeReOrderLevel, 0, 2);
            tableLayoutPanel1.Controls.Add(btnAddStock, 0, 1);
            tableLayoutPanel1.Controls.Add(btnEnsureStock, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 279);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(318, 171);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // Stocks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 450);
            Controls.Add(dgvStock);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Stocks";
            Text = "Stocks";
            Load += Stocks_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudReOrderLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddStock;
        private Label label2;
        private Button btnClear;
        private Label label4;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvStock;
        private Button btnChangeReOrderLevel;
        private Label label1;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudReOrderLevel;
        private Button btnEnsureStock;
        private TableLayoutPanel tableLayoutPanel1;
    }
}