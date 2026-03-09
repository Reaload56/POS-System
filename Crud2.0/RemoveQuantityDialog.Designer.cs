namespace Crud2._0
{
    partial class RemoveQuantityDialog
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
            nudQuantity = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudQuantity.Location = new Point(214, 92);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(168, 33);
            nudQuantity.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(79, 164);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(145, 40);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(237, 164);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 40);
            label1.Name = "label1";
            label1.Size = new Size(254, 30);
            label1.TabIndex = 2;
            label1.Text = "Select Quantity to remove";
            // 
            // RemoveQuantityDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 230);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(nudQuantity);
            Name = "RemoveQuantityDialog";
            Text = "RemoveQuantityDialog";
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudQuantity;
        private Button btnOk;
        private Button btnCancel;
        private Label label1;
    }
}