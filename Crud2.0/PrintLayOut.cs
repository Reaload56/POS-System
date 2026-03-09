using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Crud2._0
{
    public partial class PrintLayOut : Form
    {
        public PrintLayOut()
        {
            InitializeComponent();
        }
        string storeName = "MyShop";
        bool showBarCode = false;
        bool showItemName = true;
        bool showPrice = true;
        bool showQty = true;
        bool showTotal = true;
        bool showTax = true;
        bool showDiscount = true;
        string footerMessage = "Thank you for shopping with us";
        string header = "RECEIPT";
        string logoPath;
        Image logo;
        decimal txtTotal = 0;
        decimal txtCash = 15;
        DataTable cartTable = new DataTable();

        private void SetupCartTable()
        {
            if (cartTable.Columns.Count == 0)
            {
                cartTable.Columns.Add("ProductId", typeof(int));
                cartTable.Columns.Add("Product_Name", typeof(string));
                cartTable.Columns.Add("Quantity", typeof(int));
                cartTable.Columns.Add("selling_price", typeof(decimal));
                cartTable.Columns.Add("Tax Rate", typeof(decimal));
                cartTable.Columns.Add("Discount", typeof(decimal));
                cartTable.Columns.Add("BarCode", typeof(string));
            }
        }

        public void AddToCart(Product product, int qty)
        {
            // Find existing row by ProductId instead of name
            DataRow existingRow = cartTable.AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt32(r["ProductId"]) == product.ProductID);


            if (existingRow != null)
            {
                existingRow["Quantity"] = Convert.ToInt32(existingRow["Quantity"]) + qty;
            }
            else
            {
                DataRow newRow = cartTable.NewRow();
                newRow["ProductId"] = product.ProductID;   // Assuming Product model has Id
                newRow["Product_Name"] = product.Name;
                newRow["BarCode"] = product.Barcode;
                newRow["selling_price"] = product.SellingPrice;
                newRow["Tax Rate"] = product.TaxRate;
                newRow["Discount"] = product.Discount;
                newRow["Quantity"] = qty;
                cartTable.Rows.Add(newRow);
            }

            decimal tax = 0, discount = 0, discountedPrice = 0, total = 0;
            decimal discountRate = product.Discount;
            decimal costPrice = product.SellingPrice;
            decimal taxRate = product.TaxRate;

            discount = (costPrice * qty) * (discountRate / 100);
            tax = (costPrice * qty) * (taxRate / 100);

            total += (costPrice * qty) - discount + tax;

            // Update total
            txtTotal += total;
        }

        public void LoadReceiptConfig()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM receipt_config WHERE id=1", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            showBarCode = Convert.ToBoolean(reader["show_barcode"]);
                            storeName = reader["store_name"].ToString();
                            logoPath = reader["logo_path"].ToString();
                            showItemName = Convert.ToBoolean(reader["show_item_name"]);
                            showPrice = Convert.ToBoolean(reader["show_price"]);
                            showQty = Convert.ToBoolean(reader["show_quantity"]);
                            showTotal = Convert.ToBoolean(reader["show_total"]);
                            footerMessage = reader["footer_message"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //method for changing the setting of receipt
        private void SaveSettings()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Check if a configuration record already exists
                    string checkQuery = "SELECT COUNT(*) FROM receipt_config;";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    string query;

                    if (count > 0)
                    {
                        // UPDATE existing configuration
                        query = @"UPDATE receipt_config SET 
                                    header = @header,
                                    logo_path = @logo_path,
                                    show_item_name = @show_item_name,
                                    show_price = @show_price,
                                    show_quantity = @show_quantity,
                                    show_total = @show_total,
                                    show_discount = @show_discount,
                                    show_tax = @show_tax,
                                    show_barcode = @show_barcode,
                                    footer_message = @footer_message,
                                    store_name = @store_name
                                  WHERE id = 1;";
                    }
                    else
                    {
                        // INSERT a new configuration
                        query = @"INSERT INTO receipt_config 
                                (id, header, logo_path, show_item_name, show_price, show_quantity, 
                                show_total, show_discount, show_tax, show_barcode, footer_message, 
                                store_name)
                                VALUES 
                                (1, @header, @logo_path, @show_item_name, @show_price, @show_quantity, 
                                @show_total, @show_discount, @show_tax, @show_barcode, @footer_message, 
                                @store_name);";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Bind form values — replace with your actual control names
                    cmd.Parameters.AddWithValue("@header", txtHeader.Text);
                    cmd.Parameters.AddWithValue("@logo_path", txtLogoPath.Text);
                    cmd.Parameters.AddWithValue("@show_item_name", chkItemName.Checked ? 1 : 0);
                    // if checkbox is checked set value to 1 else set it to 0
                    cmd.Parameters.AddWithValue("@show_price", chkPrice.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@show_quantity", chkQuantity.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@show_total", chkTotal.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@show_discount", chkDiscount.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@show_tax", chkTax.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@show_barcode", chkBarcode.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@footer_message", txtFooterMessage.Text);
                    cmd.Parameters.AddWithValue("@store_name", txtStoreName.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Receipt layout settings saved successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving receipt settings: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeLayOut_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnPreviewReceipt_Click(object sender, EventArgs e)
        {
            LoadReceiptConfig();
            SetupCartTable();
            AddProducts(); 
            PrintDocument pd = new PrintDocument();
            PreviewReceipt();
        }
        //shows a preview of how the receipt will look like with dummy cart data
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }
        public void PreviewReceipt()
        {
            LoadReceiptConfig(); // Load receipt settings
            SetupCartTable();    // Ensure cart table exists
            AddProducts();       // Add dummy products for preview

            string receiptText = GenerateReceiptText(cartTable, txtTotal, txtCash);

            // Show the preview in a simple Form with a TextBox
            Form previewForm = new Form
            {
                Text = "Receipt Preview",
                Size = new Size(400, 600)
            };

            System.Windows.Forms.TextBox txtPreview = new System.Windows.Forms.TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Courier New", 10),
                ScrollBars = ScrollBars.Vertical,
                Text = receiptText
            };

            previewForm.Controls.Add(txtPreview);
            previewForm.ShowDialog();
        }

        private string GenerateReceiptText(DataTable cart, decimal total, decimal cash)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("          " + storeName);
            sb.AppendLine("            " + header);
            sb.AppendLine("----------------------------------------");

            sb.AppendLine("ITEMS:");
            foreach (DataRow row in cart.Rows)
            {
                string line = "";
                if (showItemName) line += row["Product_Name"].ToString().PadRight(18);
                if (showQty) line += row["Quantity"].ToString().PadRight(6);
                if (showPrice) line += Convert.ToDecimal(row["selling_price"]).ToString("0.00").PadRight(10);
                if (showDiscount) line += Convert.ToDecimal(row["Discount"]).ToString("0.00").PadRight(8);
                if (showTax) line += Convert.ToDecimal(row["Tax Rate"]).ToString("0.00").PadRight(8);

                decimal qty = Convert.ToDecimal(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["selling_price"]);
                decimal discountRate = Convert.ToDecimal(row["Discount"]);
                decimal taxRate = Convert.ToDecimal(row["Tax Rate"]);
                decimal lineTotal = qty * price - (qty * price * discountRate / 100) + (qty * price * taxRate / 100);

                if (showTotal) line += lineTotal.ToString("0.00");
                sb.AppendLine(line);

                if (showBarCode && row["BarCode"] != DBNull.Value)
                    sb.AppendLine("  Barcode: " + row["BarCode"].ToString());
            }

            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"TOTAL: {total:0.00}");
            sb.AppendLine($"Cash Paid: {cash:0.00}");
            sb.AppendLine($"Change: {(cash - total):0.00}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(footerMessage);

            return sb.ToString();
        }


        public void AddProducts()
        {
            Product product = new Product();
            Product product1 = new Product();
            Product product2 = new Product();
            Product product3 = new Product();
            Product product4 = new Product();

            product.ProductID = 0; product.Name = "Cheese"; product.Barcode = "2219331212"; product.SellingPrice = 3;
            product.TaxRate = Convert.ToDecimal(0.3); product.Discount = Convert.ToDecimal(0.3);
            product1.ProductID = 0; product1.Name = "bread"; product1.Barcode = "224324331212"; product1.SellingPrice = 7;
            product1.TaxRate = Convert.ToDecimal(0.4); product1.Discount = Convert.ToDecimal(0.2);
            product2.ProductID = 0; product2.Name = "Fish"; product2.Barcode = "3442341212"; product2.SellingPrice = 4;
            product2.TaxRate = Convert.ToDecimal(0.07); product2.Discount = Convert.ToDecimal(0.6);
            product3.ProductID = 0; product3.Name = "Face Cream"; product3.Barcode = "93231212"; product3.SellingPrice = 8;
            product3.TaxRate = Convert.ToDecimal(0.04); product3.Discount = Convert.ToDecimal(0.1);
            product4.ProductID = 0; product4.Name = "Liver"; product4.Barcode = "5634331212"; product4.SellingPrice = 6;
            product4.TaxRate = Convert.ToDecimal(0.02); product4.Discount = Convert.ToDecimal(0.02);

            AddToCart(product, 1);
            AddToCart(product2, 1);
            AddToCart(product3, 1);
            AddToCart(product4, 1);
            AddToCart(product1, 1);
        }

        private void PrintLayOut_Load(object sender, EventArgs e)
        {
            SetupCartTable();
        }
    }
}
