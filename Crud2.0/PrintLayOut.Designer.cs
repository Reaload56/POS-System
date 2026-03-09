namespace Crud2._0
{
    partial class PrintLayOut
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
            label1 = new Label();
            txtLogoPath = new TextBox();
            panel1 = new Panel();
            chkTotal = new CheckBox();
            chkQuantity = new CheckBox();
            chkPrice = new CheckBox();
            chkItemName = new CheckBox();
            chkBarcode = new CheckBox();
            label2 = new Label();
            txtFooterMessage = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtHeader = new TextBox();
            btnChangeLayOut = new Button();
            btnPreviewReceipt = new Button();
            printDoc = new System.Drawing.Printing.PrintDocument();
            txtStoreName = new TextBox();
            label5 = new Label();
            chkDiscount = new CheckBox();
            chkTax = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Logo Path";
            // 
            // txtLogoPath
            // 
            txtLogoPath.Location = new Point(71, 9);
            txtLogoPath.Name = "txtLogoPath";
            txtLogoPath.Size = new Size(220, 23);
            txtLogoPath.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(chkTax);
            panel1.Controls.Add(chkDiscount);
            panel1.Controls.Add(chkTotal);
            panel1.Controls.Add(chkQuantity);
            panel1.Controls.Add(chkPrice);
            panel1.Controls.Add(chkItemName);
            panel1.Controls.Add(chkBarcode);
            panel1.Location = new Point(71, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 227);
            panel1.TabIndex = 2;
            // 
            // chkTotal
            // 
            chkTotal.AutoSize = true;
            chkTotal.Location = new Point(22, 109);
            chkTotal.Name = "chkTotal";
            chkTotal.Size = new Size(51, 19);
            chkTotal.TabIndex = 1;
            chkTotal.Text = "Total";
            chkTotal.UseVisualStyleBackColor = true;
            // 
            // chkQuantity
            // 
            chkQuantity.AutoSize = true;
            chkQuantity.Location = new Point(22, 84);
            chkQuantity.Name = "chkQuantity";
            chkQuantity.Size = new Size(72, 19);
            chkQuantity.TabIndex = 1;
            chkQuantity.Text = "Quantity";
            chkQuantity.UseVisualStyleBackColor = true;
            // 
            // chkPrice
            // 
            chkPrice.AutoSize = true;
            chkPrice.Location = new Point(22, 59);
            chkPrice.Name = "chkPrice";
            chkPrice.Size = new Size(97, 19);
            chkPrice.TabIndex = 1;
            chkPrice.Text = "Product Price";
            chkPrice.UseVisualStyleBackColor = true;
            // 
            // chkItemName
            // 
            chkItemName.AutoSize = true;
            chkItemName.Location = new Point(22, 9);
            chkItemName.Name = "chkItemName";
            chkItemName.Size = new Size(103, 19);
            chkItemName.TabIndex = 1;
            chkItemName.Text = "Product Name";
            chkItemName.UseVisualStyleBackColor = true;
            // 
            // chkBarcode
            // 
            chkBarcode.AutoSize = true;
            chkBarcode.Location = new Point(22, 34);
            chkBarcode.Name = "chkBarcode";
            chkBarcode.Size = new Size(69, 19);
            chkBarcode.TabIndex = 1;
            chkBarcode.Text = "Barcode";
            chkBarcode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 201);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 0;
            label2.Text = "Show";
            // 
            // txtFooterMessage
            // 
            txtFooterMessage.Location = new Point(71, 434);
            txtFooterMessage.Multiline = true;
            txtFooterMessage.Name = "txtFooterMessage";
            txtFooterMessage.Size = new Size(220, 142);
            txtFooterMessage.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 434);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 0;
            label3.Text = "Footer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 102);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 0;
            label4.Text = "Header";
            // 
            // txtHeader
            // 
            txtHeader.Location = new Point(71, 102);
            txtHeader.Multiline = true;
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(220, 92);
            txtHeader.TabIndex = 1;
            // 
            // btnChangeLayOut
            // 
            btnChangeLayOut.Location = new Point(4, 584);
            btnChangeLayOut.Name = "btnChangeLayOut";
            btnChangeLayOut.Size = new Size(140, 28);
            btnChangeLayOut.TabIndex = 3;
            btnChangeLayOut.Text = "Change Lay out";
            btnChangeLayOut.UseVisualStyleBackColor = true;
            btnChangeLayOut.Click += btnChangeLayOut_Click;
            // 
            // btnPreviewReceipt
            // 
            btnPreviewReceipt.Location = new Point(151, 584);
            btnPreviewReceipt.Name = "btnPreviewReceipt";
            btnPreviewReceipt.Size = new Size(140, 28);
            btnPreviewReceipt.TabIndex = 3;
            btnPreviewReceipt.Text = "Preview Receipt";
            btnPreviewReceipt.UseVisualStyleBackColor = true;
            btnPreviewReceipt.Click += btnPreviewReceipt_Click;
            // 
            // printDoc
            // 
            printDoc.PrintPage += printDoc_PrintPage;
            // 
            // txtStoreName
            // 
            txtStoreName.Location = new Point(71, 38);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(220, 23);
            txtStoreName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 41);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 0;
            label5.Text = "Store Name";
            // 
            // chkDiscount
            // 
            chkDiscount.AutoSize = true;
            chkDiscount.Location = new Point(22, 134);
            chkDiscount.Name = "chkDiscount";
            chkDiscount.Size = new Size(73, 19);
            chkDiscount.TabIndex = 1;
            chkDiscount.Text = "Discount";
            chkDiscount.UseVisualStyleBackColor = true;
            // 
            // chkTax
            // 
            chkTax.AutoSize = true;
            chkTax.Location = new Point(22, 159);
            chkTax.Name = "chkTax";
            chkTax.Size = new Size(43, 19);
            chkTax.TabIndex = 1;
            chkTax.Text = "Tax";
            chkTax.UseVisualStyleBackColor = true;
            // 
            // PrintLayOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 624);
            Controls.Add(btnPreviewReceipt);
            Controls.Add(btnChangeLayOut);
            Controls.Add(panel1);
            Controls.Add(txtFooterMessage);
            Controls.Add(txtHeader);
            Controls.Add(txtStoreName);
            Controls.Add(txtLogoPath);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "PrintLayOut";
            Text = "PrintLayOut";
            Load += PrintLayOut_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLogoPath;
        private Panel panel1;
        private CheckBox chkTotal;
        private CheckBox chkQuantity;
        private CheckBox chkPrice;
        private CheckBox chkItemName;
        private CheckBox chkBarcode;
        private Label label2;
        private TextBox txtFooterMessage;
        private Label label3;
        private Label label4;
        private TextBox txtHeader;
        private Button btnChangeLayOut;
        private Button btnPreviewReceipt;
        private System.Drawing.Printing.PrintDocument printDoc;
        private TextBox txtStoreName;
        private Label label5;
        private CheckBox chkTax;
        private CheckBox chkDiscount;
    }
}