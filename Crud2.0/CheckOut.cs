using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Crud2._0
{
    /// Represents the CheckOut form, which finalizes a sale transaction, handles payments,
    /// updates customer balances, and generates receipts.
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
            posInfo = MiddleManClass.GetSaleInfo();// Retrieves the PoS object containing sale info from a global helper.
        }

        // Sale-related fields
        private PoS posInfo;// Object holding Point of Sale transaction details passed from the PoS form.
        private DataTable cart;
        private decimal totalAmount, subPrice, globalDiscount, cash, change, balance;
        private int customerId = 0, paymentMethod, lastSaleId;
        private string paymentStatus, notes, invoiceNumber;
        private bool isSuccess;

        // Receipt configuration fields, loaded from the database to customize the printed receipt.
        private string storeName = "MyShop", footerMessage = "Thank you for shopping with us", header = "RECEIPT", logoPath;
        private bool showBarCode, showItemName = true, showPrice = true, showQty = true, showTotal = true, showTax = true, showDiscount = true;
        private void LoadCustomers()
        {
            // Obtains all customers from the database
            DataTable dt = CustomerDAL.GetAll();

            cbCustomers.DataSource = dt;
            cbCustomers.DisplayMember = "full_name";
            cbCustomers.ValueMember = "customer_id";
        }
        /// Populates the form's private fields with data from the 'posInfo' object.
        private void SetData()
        {
            customerId = posInfo.CustomerId;
            cart = posInfo.Cart;
            cash = posInfo.Cash;
            totalAmount = posInfo.TotalPrice;
            subPrice = posInfo.SubPrice;
            globalDiscount = posInfo.Globaldiscount;
            paymentMethod = posInfo.PaymentMethod;
            notes = posInfo.Notes;

            dgvCart.DataSource = cart;
        }
        /// Loads receipt configuration settings from the database for printing.
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
                            storeName = reader["store_name"].ToString();
                            logoPath = reader["logo_path"].ToString();
                            footerMessage = reader["footer_message"].ToString();
                            showBarCode = Convert.ToBoolean(reader["show_barcode"]);
                            showItemName = Convert.ToBoolean(reader["show_item_name"]);
                            showPrice = Convert.ToBoolean(reader["show_price"]);
                            showQty = Convert.ToBoolean(reader["show_quantity"]);
                            showTotal = Convert.ToBoolean(reader["show_total"]);
                            header = reader["header"].ToString(); // Missing
                            showTax = Convert.ToBoolean(reader["show_tax"]); // Missing
                            showDiscount = Convert.ToBoolean(reader["show_discount"]); // Missing
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading receipt configuration: {ex.Message}");
            }
        }
        /// Initiates the receipt printing process by showing a print preview.
        /*private void PrintReceipt()
        {
            LoadReceiptConfig();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += printDoc_PrintPage;
            new PrintPreviewDialog { Document = pd }.ShowDialog();
        }*/
        /// Saves the current sale transaction and its items to the database.
        private void SaveSale()
        {
            invoiceNumber = $"INV-{DateTime.Now:yyyyMMddHHmmss}-{customerId}";
            try
            {
                // Creates a new Sale object with all relevant transaction details.
                Sale sale = new Sale
                {
                    InvoiceNumber = invoiceNumber,// Generate a unique invoice number.
                    CustomerID = customerId,
                    TotalAmount = totalAmount,
                    Change = change,
                    Date = DateTime.Now,
                    UserID = MiddleManClass.GetId(),// Get the ID of the currently logged-in user.
                    GlobalDiscount = globalDiscount,
                    NetAmount = subPrice,
                    AmountPaid = cash,
                    PaymentStatus = paymentStatus,
                    Notes = notes,
                    PaymentMethod = paymentMethod
                };

                List<Sale_Item> saleItems = new List<Sale_Item>();
                // Iterate through each item in the cart to create Sale_Item objects.
                foreach (DataRow row in cart.Rows)
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
                // Insert the sale and its items into the database and get the generated Sale ID.
                int saleId = SaleDAL.InsertSale(sale, saleItems);
                if (saleId > 0)
                {
                    isSuccess = true;
                    lastSaleId = saleId;
                }

                if (isSuccess && saleId > 0)
                {

                    CustomerDAL.UpdateCustomerbalance(customerId, balance);

                    MessageBox.Show("Sale completed successfully! Printing receipt...");
                    PrintReceipt();
                }
                else
                {
                    MessageBox.Show("Failed to record sale.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving sale: " + ex.Message);
            }
        }
        /// Checks if the currently selected customer in the ComboBox is the "Default Customer".
        private bool IsDefaultCustomerSelected()
        {
            if (cbCustomers.SelectedValue == null) return true;
            int id = Convert.ToInt32(cbCustomers.SelectedValue);

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT customerType FROM customers WHERE customer_id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result.ToString() == "Default Customer") return true;
                }
            }
            return false;
        }
        /// Handles the Load event for the CheckOut form, initializing UI elements and data.
        private void CheckOut_Load(object sender, EventArgs e)
        {
            // Temporarily disable the event handler to prevent it from firing prematurely.
            this.cbCustomers.SelectedIndexChanged -= new System.EventHandler(this.cbCustomers_SelectedIndexChanged);

            SetData();
            LoadCustomers();

            txtGlobalDiscount.Text = globalDiscount.ToString("0.00");
            txtCash.Text = cash.ToString("0.00");
            txtSubPrice.Text = subPrice.ToString("0.00");

            // Get the initial customer balance from the database.
            this.balance = CustomerDAL.GetBalance(customerId);
            txtBalance.Text = this.balance.ToString("0.00");

            // Calculate the final total by adding the customer's balance to the sale total.
            this.totalAmount = posInfo.TotalPrice + this.balance;
            

            // Update the change with the final total.
            this.change = this.cash - this.totalAmount;
            if (this.change < 0)
            {
                this.change = 0;
            }
            txtChange.Text = this.change.ToString("0.00");

            // Setting the data source for the DataGridView
            dgvCart.DataSource = cart;

            // Setting the selected customer in the combobox
            cbCustomers.SelectedValue = customerId;

            this.totalAmount = Math.Round(this.totalAmount, 2);
            this.cash = Math.Round(this.cash, 2);

            // Show/hide credit/debt panels based on the transaction
            txtTotal.Text = this.totalAmount.ToString("0.00");
            if (this.totalAmount < this.cash)
            {
                pnlCredit.Visible = true;
                pnlDebt.Visible = false;
            }
            else if (this.totalAmount > this.cash)
            { 
                pnlCredit.Visible = false; 
                pnlDebt.Visible = true;
            }
            else
            {
                pnlCredit.Visible = true;
                pnlDebt.Visible = false;
            }
            // Re-enable the event handler.
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelSale2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveDebt_Click(object sender, EventArgs e)
        {
            // Prevents default customer from accruing debt.
            if (IsDefaultCustomerSelected())
            {
                MessageBox.Show("Default Customer cannot have Debt");
                new Customers().ShowDialog();
                return;// Exit if default customer is still selected.
            }

            paymentStatus = "Pending Debt";// Set status to pending debt.
            balance = this.totalAmount - this.cash; // Calculate the amount the customer owes.
            if (balance > 0) balance = +balance;

            change = 0;
            SaveSale();
            this.Close();// Close the form.
        }

        private void btnSaveCredit_Click(object sender, EventArgs e)
        {
            // Prevents default customer from accruing credit.
            if (IsDefaultCustomerSelected())
            {
                MessageBox.Show("Default Customer cannot have Credit");
                new Customers().ShowDialog();
                return;// Exit if default customer is still selected.
            }

            paymentStatus = "Pending Credit";// Set status to pending credit.

            // Calculate balance: overpayment means the store owes the customer, represented as a negative balance.
            balance = cash - totalAmount;
            if (balance > 0) balance = -balance;

            change = 0;
            SaveSale();
            this.Close();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (cash >= totalAmount)// Check if enough cash is provided.
            {
                change = cash - totalAmount;
                balance = 0;
                paymentStatus = "Completed";

                SaveSale();

                this.Close();
            }
            else
            {
                MessageBox.Show("Insufficient cash. Please use the 'Save as Debt' button for incomplete payments.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void PrintReceipt()
        {
            string receiptText = GenerateReceiptText();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, e) =>
            {
                // Just print the string; no Graphics or Images
                e.Graphics.DrawString(receiptText, new Font("Courier New", 10), Brushes.Black, new PointF(0, 0));
            };

            PrintDialog printDlg = new PrintDialog
            {
                Document = pd
            };

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                PreviewReceipt();
                pd.Print();
            }
        }

        private string GenerateReceiptText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("          " + storeName);
            sb.AppendLine("            " + header);
            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"Invoice No: {invoiceNumber}");
            sb.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
            sb.AppendLine("----------------------------------------");

            // Item header
            string itemHeader = "";
            if (showItemName) itemHeader += "Item".PadRight(18);
            if (showQty) itemHeader += "Qty".PadRight(6);
            if (showPrice) itemHeader += "Price".PadRight(10);
            if (showDiscount) itemHeader += "Disc".PadRight(8);
            if (showTax) itemHeader += "Tax".PadRight(8);
            if (showTotal) itemHeader += "Total";
            sb.AppendLine(itemHeader);
            sb.AppendLine("----------------------------------------");

            // Items
            foreach (DataRow row in cart.Rows)
            {
                string line = "";
                if (showItemName) line += row["Product_Name"].ToString().PadRight(18);
                if (showQty) line += Convert.ToInt32(row["Quantity"]).ToString().PadRight(6);
                if (showPrice) line += Convert.ToDecimal(row["selling_price"]).ToString("0.00").PadRight(10);
                if (showDiscount) line += Convert.ToDecimal(row["Discount"]).ToString("0.00").PadRight(8);
                if (showTax) line += Convert.ToDecimal(row["Tax Rate"]).ToString("0.00").PadRight(8);

                decimal qty = Convert.ToDecimal(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["selling_price"]);
                decimal discountRate = Convert.ToDecimal(row["Discount"]);
                decimal taxRate = Convert.ToDecimal(row["Tax Rate"]);
                decimal lineSubTotal = qty * price;
                decimal lineDiscountAmount = lineSubTotal * (discountRate / 100);
                decimal lineTaxAmount = lineSubTotal * (taxRate / 100);
                decimal lineTotal = lineSubTotal - lineDiscountAmount + lineTaxAmount;

                if (showTotal) line += lineTotal.ToString("0.00");
                sb.AppendLine(line);

                // Optional barcode
                if (showBarCode && row["Barcode"] != DBNull.Value && !string.IsNullOrEmpty(row["Barcode"].ToString()))
                {
                    sb.AppendLine("  Barcode: " + row["Barcode"].ToString());
                }
            }

            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"SubTotal: {subPrice:0.00}");
            sb.AppendLine($"Discount: {globalDiscount:0.00}");
            sb.AppendLine($"TOTAL: {totalAmount:0.00}");
            sb.AppendLine($"Amount Paid: {cash:0.00}");
            sb.AppendLine($"Change: {(cash - totalAmount):0.00}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(footerMessage);

            return sb.ToString();
        }
        private void PreviewReceipt()
        {
            LoadReceiptConfig(); // Load receipt settings

            string receiptText = GenerateReceiptText();

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


        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }
        /// Recalculates total amount and updates UI based on the selected customer's balance.
        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Exit if no valid selection.
            if (cbCustomers.SelectedValue == null || cbCustomers.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Get the new customer ID
                this.customerId = Convert.ToInt32(cbCustomers.SelectedValue);

                // Get the customer's balance from the database
                decimal customerBalance = CustomerDAL.GetBalance(this.customerId);

                // Update the balance text box
                txtBalance.Text = customerBalance.ToString("0.00");

                // Recalculate the total amount to include the customer's balance
                decimal originalTotalAmount = posInfo.TotalPrice;

                // Add the customer's balance to the total.
                // A positive balance (debt) adds to the total.
                // A negative balance (credit) subtracts from the total.
                this.totalAmount = originalTotalAmount + customerBalance;
                txtTotal.Text = this.totalAmount.ToString("0.00");

                // Update the change and check/debt panels
                this.change = this.cash - this.totalAmount;
                if (this.change < 0)
                {
                    this.change = 0;
                }
                txtChange.Text = this.change.ToString("0.00");

                this.totalAmount = Math.Round(this.totalAmount, 2);
                this.cash = Math.Round(this.cash, 2);

                // Show/hide credit/debt panels based on the transaction

                if (this.totalAmount < this.cash)
                {
                    pnlCredit.Visible = true;
                    pnlDebt.Visible = false;
                }
                else if (this.totalAmount > this.cash)
                {
                    pnlCredit.Visible = false;
                    pnlDebt.Visible = true;
                }
                else
                {
                    pnlCredit.Visible = true;
                    pnlDebt.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer balance: {ex.Message}");
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCash.Text, out decimal parsedCash))// Attempt to parse cash input.
            {
                this.cash = parsedCash;
                this.change = this.cash - this.totalAmount;
                if (this.change < 0)
                {
                    this.change = 0;
                }
                txtChange.Text = this.change.ToString("0.00");

                this.totalAmount = Math.Round(this.totalAmount, 2);
                this.cash = Math.Round(this.cash, 2);

                // Update panel visibility based on current cash and total amount.

                if (this.totalAmount < this.cash)
                {
                    pnlCredit.Visible = true;
                    pnlDebt.Visible = false;
                }
                else if (this.totalAmount > this.cash)
                {
                    pnlCredit.Visible = false;
                    pnlDebt.Visible = true;
                }
                else
                {
                    pnlCredit.Visible = true;
                    pnlDebt.Visible = false;
                }
            }
            else// If input is not a valid decimal.
            {
                this.cash = 0;
                this.change = 0;
                txtChange.Text = "0.00";

                pnlDebt.Visible = (this.totalAmount > 0);
                pnlCredit.Visible = false;
                
            }
        }
    }
}
