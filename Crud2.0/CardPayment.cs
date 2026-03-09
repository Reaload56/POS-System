using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Crud2._0
{
    public partial class CardPayment : Form
    {
        public CardPayment()
        {
            InitializeComponent();
        }
        // Private fields to hold transaction data.
        private PoS posInfo;
        private DataTable cart;
        private decimal totalAmount, subPrice, globalDiscount, cash, change, balance;
        private int customerId = 0, paymentMethod, lastSaleId;
        private string paymentStatus, notes, invoiceNumber;
        private bool isSuccess;

        private string storeName = "MyShop", footerMessage = "Thank you for shopping with us", header = "RECEIPT", logoPath;
        private bool showBarCode, showItemName = true, showPrice = true, showQty = true, showTotal = true, showTax = true, showDiscount = true;

        ///Method to set transaction data received from the PoS form.
        private void SetData()
        {
            posInfo = MiddleManClass.GetSaleInfo();
            customerId = posInfo.CustomerId;
            cart = posInfo.Cart;
            cash = posInfo.Cash;
            totalAmount = posInfo.TotalPrice;
            subPrice = posInfo.SubPrice;
            globalDiscount = posInfo.Globaldiscount;
            paymentMethod = posInfo.PaymentMethod;
            notes = posInfo.Notes;
            balance = CustomerDAL.GetBalance(customerId);

            totalAmount = posInfo.TotalPrice + balance;
            dgvCart.DataSource = cart;// Binds the cart DataTable to the DataGridView.
            txtTotal.Text = totalAmount.ToString("0.00");
        }
        /// Loads receipt configuration settings from the database.
        public void LoadReceiptConfig()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM receipt_config WHERE id=1", conn);
                    // Assumes a single config record with ID 1
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            storeName = reader["store_name"].ToString();
                            logoPath = reader["logo_path"].ToString();
                            footerMessage = reader["footer_message"].ToString();
                            showBarCode = Convert.ToBoolean(reader["show_barcode"]);
                            showItemName = Convert.ToBoolean(reader["show_item_name"]);
                            showPrice = Convert.ToBoolean(reader["show_price"]);
                            showQty = Convert.ToBoolean(reader["show_quantity"]);
                            showTotal = Convert.ToBoolean(reader["show_total"]);
                        }
                    }
                }
            }
            catch { }
        }
        /// Initiates the receipt printing process by showing a print preview dialog.
        private void PrintReceipt()
        {
            LoadReceiptConfig();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += printDoc_PrintPage;
            new PrintPreviewDialog { Document = pd }.ShowDialog();
        }
        /// Saves the sale transaction details and its associated items to the database.
        private void SaveSale()
        {
            try
            {
                Sale sale = new Sale // Create a new Sale object with transaction details.
                {
                    InvoiceNumber = invoiceNumber,
                    CustomerID = customerId,
                    TotalAmount = totalAmount,
                    Change = change,
                    Date = DateTime.Now,
                    UserID = MiddleManClass.GetId(),
                    GlobalDiscount = globalDiscount,
                    NetAmount = subPrice,
                    AmountPaid = cash,
                    PaymentStatus = paymentStatus,
                    Notes = notes,
                    PaymentMethod = paymentMethod
                };

                List<Sale_Item> saleItems = new List<Sale_Item>();// List to hold individual sale items.
                foreach (DataRow row in cart.Rows)// Populate saleItems list from the cart DataTable.
                {
                    Sale_Item item = new Sale_Item
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        UnitPrice = Convert.ToDecimal(row["selling_price"]),
                        Discount = Convert.ToDecimal(row["Discount"]),
                        Tax = Convert.ToDecimal(row["Tax Rate"]),
                        Total =
                            (Convert.ToDecimal(row["selling_price"]) * Convert.ToInt32(row["Quantity"]))
                          - ((Convert.ToDecimal(row["selling_price"]) * Convert.ToInt32(row["Quantity"])) * (Convert.ToDecimal(row["Discount"]) / 100))
                          + ((Convert.ToDecimal(row["selling_price"]) * Convert.ToInt32(row["Quantity"])) * (Convert.ToDecimal(row["Tax Rate"]) / 100))
                    };
                    saleItems.Add(item);
                }
                // Insert the sale and its items into the database.
                int saleId = SaleDAL.InsertSale(sale, saleItems);
                lastSaleId = saleId;// Store the ID of the newly created sale.
                if (lastSaleId > 0) { isSuccess = true; }
                if (isSuccess && saleId > 0)
                {
                        balance = 0;
                        CustomerDAL.UpdateCustomerbalance(customerId, balance);

                    MessageBox.Show("Sale completed successfully! Printing receipt...");
                    PrintReceipt();
                }

                if (!isSuccess || saleId <= 0)
                {
                    MessageBox.Show("Failed to record sale.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving sale: " + ex.Message);
            }
        }
        /// Event handler for the PrintPage event of the PrintDocument, responsible for drawing the receipt content.
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 10); // Standard font for receipt text.
            int yPos = 20; // Starting Y position for drawing.

            // Draw store logo if path is valid and file exists.
            if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
            {
                Image logo = Image.FromFile(logoPath);
                // Adjust logo position and size as needed for the receipt.
                e.Graphics.DrawImage(logo, new Rectangle(0, yPos, Math.Min(logo.Width, 200), Math.Min(logo.Height, 75))); // Limit logo size.
                yPos += Math.Min(logo.Height, 75) + 10; // Move Y position below the logo with some padding.
            }

            // Draw store name and receipt header.
            e.Graphics.DrawString(storeName, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 0, yPos);
            yPos += 25; // Adjusted Y position for better spacing.
            e.Graphics.DrawString(header, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 0, yPos); // Using a slightly larger font for header.
            yPos += 20;

            // Draw transaction invoice number.
            e.Graphics.DrawString($"Invoice No: {invoiceNumber}", font, Brushes.Black, 0, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}", font, Brushes.Black, 0, yPos);
            yPos += 30; // More space before item details.

            // Construct and draw the item details header.
            string headerLine = "Item".PadRight(showItemName ? 18 : 0); // Adjust padding based on visibility.
            if (showQty) headerLine += "Qty".PadRight(6);
            if (showPrice) headerLine += "Price".PadRight(10);
            if (showDiscount) headerLine += "Disc".PadRight(8);
            if (showTax) headerLine += "Tax".PadRight(8);
            if (showTotal) headerLine += "Total";
            e.Graphics.DrawString(headerLine, new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 0, yPos); // Use a monospaced font for alignment.
            yPos += 15;
            e.Graphics.DrawString(new string('-', 50), font, Brushes.Black, 0, yPos); // Separator line.
            yPos += 15;

            // Draw each item in the cart.
            foreach (DataRow row in cart.Rows)
            {
                string line = "";
                if (showItemName) line += row["Product_Name"].ToString().PadRight(18);
                if (showQty) line += Convert.ToInt32(row["Quantity"]).ToString().PadRight(6);
                if (showPrice) line += Convert.ToDecimal(row["selling_price"]).ToString("0.00").PadRight(10);
                if (showDiscount) line += Convert.ToDecimal(row["Discount"]).ToString("0.00").PadRight(8);
                if (showTax) line += Convert.ToDecimal(row["Tax Rate"]).ToString("0.00").PadRight(8);

                // Recalculate line total for display on receipt (redundant with SaveSale, but good for self-contained printing).
                decimal qty = Convert.ToDecimal(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["selling_price"]);
                decimal discountRate = Convert.ToDecimal(row["Discount"]);
                decimal taxRate = Convert.ToDecimal(row["Tax Rate"]);
                decimal lineSubTotal = qty * price;
                decimal lineDiscountAmount = lineSubTotal * (discountRate / 100);
                decimal lineTaxAmount = lineSubTotal * (taxRate / 100);
                decimal lineTotal = lineSubTotal - lineDiscountAmount + lineTaxAmount;

                if (showTotal) line += lineTotal.ToString("0.00");
                e.Graphics.DrawString(line, new Font("Courier New", 10), Brushes.Black, 0, yPos);
                yPos += 15;

                // Draw barcode if enabled and available.
                if (showBarCode && row["Barcode"] != DBNull.Value && !string.IsNullOrEmpty(row["Barcode"].ToString())) // Corrected column name to "Barcode".
                {
                    e.Graphics.DrawString("  Barcode: " + row["Barcode"].ToString(), new Font("Courier New", 8), Brushes.Black, 0, yPos); // Smaller font for barcode.
                    yPos += 12;
                }
            }

            yPos += 15;
            e.Graphics.DrawString(new string('-', 50), font, Brushes.Black, 0, yPos); // Separator line.
            yPos += 15;

            // Draw summary totals.
            e.Graphics.DrawString("SubTotal: " + subPrice.ToString("0.00"), font, Brushes.Black, 0, yPos);
            yPos += 15;
            e.Graphics.DrawString("Discount: " + globalDiscount.ToString("0.00"), font, Brushes.Black, 0, yPos);
            yPos += 15;
            e.Graphics.DrawString("TOTAL: " + totalAmount.ToString("0.00"), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 0, yPos);
            yPos += 20;
            e.Graphics.DrawString("Amount Paid: " + cash.ToString("0.00"), font, Brushes.Black, 0, yPos);
            yPos += 15;
            e.Graphics.DrawString("Change: " + (cash - totalAmount).ToString("0.00"), font, Brushes.Black, 0, yPos);
            yPos += 30; // More space before footer.

            // Draw footer message.
            e.Graphics.DrawString(footerMessage, font, Brushes.Black, 0, yPos);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            invoiceNumber = txtTransactionReference.Text; // Get invoice number from textbox.
            SaveSale(); // Save the sale to the database and print receipt.
            this.Close(); // Close the payment form.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the payment form without saving.
        }

        private void CardPayment_Load(object sender, EventArgs e)
        {
            SetData();
        }
    }
}
