using Crud2._0.Data_Access_Layers;
using Crud2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Crud2._0
{
    public partial class Point_Of_Sale : Form
    {
        DataTable cartTable = new DataTable(), products = new DataTable();
        int customerId;
        string user;
        string paymentStatus = "Paid", SelectedPaymentMethod;
        decimal netAmount = 0, grossamount = 0, amountPaid = 0, Totaldiscount = 0, Totaltax = 0, TotalWithOutBal = 0;
        int lastSaleId = 0, paymentMethod;
        Product product = new Product();


        public void UserName()
        {
            user = MiddleManClass.GetUser();

        }
        public Point_Of_Sale(bool lowStock)
        {
            InitializeComponent();
        }

        private void Point_Of_Sale_Load(object sender, EventArgs e)
        {
            this.cbCustomers.SelectedIndexChanged -= new System.EventHandler(this.cbCustomers_SelectedIndexChanged);// Temporarily disable the event handler to prevent it from firing prematurely.
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.ImageAlign = ContentAlignment.MiddleCenter;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;

            LoadCustomers();// loads customer data on to combobox
            SetupCartTable();
            products = ProductDAL.LoadProducts();
            UserName();
            LoadPaymentMethods();
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);// Re-enables the event handler.
            dgvCart.Visible = false;
            LoadProducts();
            dgvProducts.Dock = DockStyle.Fill;
            RestoreSaleSession();
            txtBalance.Text = Convert.ToString(CustomerDAL.GetBalance(customerId));//to load the selected customer's balance
        }

        public void SaveSaleSession()
        {
            var sale = new PoS
            {
                Cart = (DataTable)dgvCart.DataSource,
                Cash = decimal.TryParse(txtCash.Text, out var cash) ? cash : 0,
                CustomerId = customerId,
                Globaldiscount = decimal.TryParse(txtDiscount.Text, out var disc) ? disc : 0,
                SubPrice = decimal.TryParse(txtSubPrice.Text, out var sub) ? sub : 0,
                TotalPrice = decimal.TryParse(txtTotal.Text, out var total) ? total : 0,
                Change = decimal.TryParse(txtChange.Text, out var change) ? change : 0,
                PaymentMethod = paymentMethod,
                Notes = txtNotes.Text
            };

            SaleSession.CurrentSale = sale;
        }

        private void RestoreSaleSession()
        {
            if (SaleSession.CurrentSale != null)
            {
                var sale = SaleSession.CurrentSale;

                cartTable = sale.Cart;
                txtCash.Text = sale.Cash.ToString("0.00");
                customerId = sale.CustomerId;
                cbCustomers.SelectedValue = customerId;
                txtDiscount.Text = sale.Globaldiscount.ToString("0.00");
                txtSubPrice.Text = sale.SubPrice.ToString("0.00");
                txtTotal.Text = sale.TotalPrice.ToString("0.00");
                txtChange.Text = sale.Change.ToString("0.00");
                paymentMethod = sale.PaymentMethod;
                cbPaymentMethods.SelectedValue = paymentMethod;
                txtNotes.Text = sale.Notes;
                LoadCart();
            }
        }

        public void SetTextBoxes()
        {
            txtDiscount.Text = Totaldiscount.ToString("0.00");
            txtTax.Text = Totaltax.ToString("0.00");
            txtSubPrice.Text = netAmount.ToString("0.00");
        }
        public void LoadProducts()
        {
            dgvProducts.DataSource = products;
        }
        private void SetupCartTable()
        {
            //loads the columns for the cartTable
            cartTable.Columns.Add("ProductId", typeof(int));
            cartTable.Columns.Add("Product_Name", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("selling_price", typeof(decimal));
            cartTable.Columns.Add("Tax Rate", typeof(decimal));
            cartTable.Columns.Add("Discount", typeof(decimal));
            cartTable.Columns.Add("BarCode", typeof(string));

            //loads cart datagrid view with data from cart table
            dgvCart.DataSource = cartTable;

            // Hide ProductId and barcode columns in DataGridView
            dgvCart.Columns["ProductId"].Visible = false;
            dgvCart.Columns["BarCode"].Visible = false;
        }
        public void LoadCart()
        {
            dgvCart.DataSource = cartTable;
        }

        public void LoadPaymentMethods()
        {
            DataTable dt = PaymentMethodsDAL.GetAll();//obtains all payment methods 
            cbPaymentMethods.DataSource = dt; //sets payment methods to the payment methods combobox
            cbPaymentMethods.DisplayMember = "name";
            cbPaymentMethods.ValueMember = "payment_method_id";

            //sets the selected paymenthod to cash by default
            foreach (DataRow row in ((DataTable)cbPaymentMethods.DataSource).Rows)//itterates through all rows in payment method table
            {
                if (row["name"].ToString().Equals("Cash", StringComparison.OrdinalIgnoreCase))
                {
                    cbPaymentMethods.SelectedValue = row["payment_method_id"];
                    break;
                }
            }
        }

        public void LoadCustomers()
        {
            DataTable dt = CustomerDAL.GetAll();//obtains all customer data and sets it to table

            cbCustomers.DataSource = dt;
            cbCustomers.DisplayMember = "full_name";
            cbCustomers.ValueMember = "customer_id";

            if (dt.Rows.Count > 0)
            {
                DataRow[] walkInRow = dt.Select("customerType  = 'Default Customer'");//sets default customer as selected customer
                if (walkInRow.Length > 0)
                {
                    customerId = Convert.ToInt32(walkInRow[0]["customer_id"]);
                    cbCustomers.SelectedValue = customerId;

                    CalculateAndSetTotals();
                }
            }

        }

        public void AddToCart(Product product, int qty)
        {
            DataRow existingRow = cartTable.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["ProductId"]) == product.ProductID);//checks if product is already in table
            int stockQuantity = 0;
            stockQuantity = StockDAL.GetStockQuantity(product.ProductID);

            if (existingRow != null)
            {
                int TotalQty = Convert.ToInt32(existingRow["Quantity"]) + qty;//if the selected product already exists in table it adds to the quantity

                if (stockQuantity >= TotalQty)
                {
                    existingRow["Quantity"] = TotalQty; // checks if there is enough stock
                }
                else
                {
                    int remainingStock = Convert.ToInt32(existingRow["Quantity"]) - stockQuantity;
                    MessageBox.Show("Not enough stock. Available: " + stockQuantity);

                }

            }
            else
            {
                if (stockQuantity >= qty)
                {
                    DataRow newRow = cartTable.NewRow();
                    newRow["ProductId"] = product.ProductID;
                    newRow["Product_Name"] = product.Name;
                    newRow["BarCode"] = product.Barcode;
                    newRow["selling_price"] = product.SellingPrice;
                    newRow["Tax Rate"] = product.TaxRate;
                    newRow["Discount"] = product.Discount;
                    newRow["Quantity"] = qty;
                    cartTable.Rows.Add(newRow);
                }
                else
                {
                    MessageBox.Show("Available stock is " + stockQuantity.ToString());
                }
            }
            // Update total
            string balance = txtBalance.Text;
            CalculateAndSetTotals();

            LoadCart();

        }

        private void CalculateAndSetTotals() // calculates and sets the totals values of textboxes
        {
            if (cartTable == null || cartTable.Rows.Count == 0)
            {
                txtSubPrice.Text = "0.00";
                txtTax.Text = "0.00";
                txtDiscount.Text = "0.00";
                txtTotal.Text = "0.00";
                return;
            }

            CalculationResult result = Calculator.CalculateCart(cartTable);//obtains results of total calculation of items in cart table

            decimal globalDiscount = 0;
            decimal.TryParse(txtGlobalDiscount.Text, out globalDiscount);//obtains and sets global discount value

            decimal customerBalance = 0;
            decimal.TryParse(txtBalance.Text, out customerBalance);//obtains and sets customer balance value

            decimal finalAmount = result.Total;
            if (globalDiscount > 0)
            {
                finalAmount -= (finalAmount * (globalDiscount / 100));
            }
            TotalWithOutBal = finalAmount;
            finalAmount += customerBalance;

            //changes values on text boxes
            txtSubPrice.Text = result.SubTotal.ToString("0.00");
            txtTax.Text = result.Tax.ToString("0.00");
            txtDiscount.Text = result.Discount.ToString("0.00");
            finalAmount = Math.Round(finalAmount, 2);
            txtTotal.Text = finalAmount.ToString("0.00");

            netAmount = result.SubTotal;
            grossamount = finalAmount;
            Totaldiscount = result.Discount + (result.Total * (globalDiscount / 100));
            Totaltax = result.Tax;
            

            SetTextBoxes();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //searches for product set in txtSearch by product name
            DataTable dt = ProductDAL.Find(txtSearch.Text);
            if (dt != null)
            {
                dgvProducts.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Product not found.");
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int qty = 1;

            //sets product details to product object 
            if (dgvProducts.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = dgvProducts.SelectedCells[0];
                DataGridViewRow row = cell.OwningRow;
                if (row.IsNewRow) return;

                product.ProductID = Convert.ToInt32(row.Cells["product_id"].Value);//sets id from the cell product_id in products data table
                product.Name = row.Cells["name"].Value.ToString();
                product.SellingPrice = Convert.ToDecimal(row.Cells["selling_price"].Value);
                product.TaxRate = Convert.ToDecimal(row.Cells["tax_rate"].Value);
                product.Discount = row.Cells["discount"] != null ? Convert.ToDecimal(row.Cells["discount"].Value) : 0;
                product.Barcode = row.Cells["barcode"].Value.ToString();

                if (numUdQuantity.Value > 0)
                    qty = Convert.ToInt32(numUdQuantity.Value);

                AddToCart(product, qty);
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartTable.Clear();
            txtTotal.Text = "0.00";

        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCart.SelectedRows[0];
                int currentQty = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                // If the quantity is 1, just remove the row as before
                if (currentQty <= 1)
                {
                    cartTable.Rows.RemoveAt(selectedRow.Index);
                }
                else
                {
                    // If the quantity is > 1, ask the user how many to remove
                    using (RemoveQuantityDialog dialog = new RemoveQuantityDialog(currentQty))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int qtyToRemove = dialog.QuantityToRemove;
                            if (qtyToRemove > 0 && qtyToRemove <= currentQty)
                            {
                                selectedRow.Cells["Quantity"].Value = currentQty - qtyToRemove;
                            }
                            else if (qtyToRemove == currentQty)
                            {
                                cartTable.Rows.RemoveAt(selectedRow.Index);
                            }
                        }
                    }
                }

                // Recalculate totals after the removal
                CalculateAndSetTotals();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {

                string notes = txtNotes.Text;
                bool isSuccess;
                if (cbPaymentMethods.SelectedValue == null)
                {
                    MessageBox.Show("Please select a payment method.");
                    return;
                }
                paymentMethod = Convert.ToInt32(cbPaymentMethods.SelectedValue);
                // Validating CartTable and Customers combobox 
                if (cartTable.Rows.Count == 0) { MessageBox.Show("Cart is empty!"); return; }//prevents check out from loading if there are no products in cart table 

                if (cbCustomers.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }

                decimal globalDiscount;
                decimal.TryParse(txtGlobalDiscount.Text, out globalDiscount);
                //loads point of sale data so that check out can access accurate values
                PoS posData = new PoS
                {
                    Cart = cartTable,
                    TotalPrice = TotalWithOutBal,
                    SubPrice = netAmount,
                    Globaldiscount = globalDiscount,
                    CustomerId = customerId,
                    Cash = amountPaid,
                    PaymentMethod = paymentMethod,
                    Notes = notes
                };
                MiddleManClass.SetSaleInfo(posData);
                if (SelectedPaymentMethod == "Card")
                {
                    CardPayment cardPayment = new CardPayment();
                    cardPayment.ShowDialog(); //loads card payment form
                }
                else
                {
                    CheckOut checkOut = new CheckOut();
                    checkOut.ShowDialog(); //loads cash payment form
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during checkout: " + ex.Message);
            }
        }


        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            //the method recalculates change whenever cash value is changed
            if (decimal.TryParse(txtCash.Text, out decimal parsedCash))
            {
                amountPaid = parsedCash;
                txtChange.Text = (amountPaid - grossamount).ToString("0.00");//calculates the customers change based on the amount they are paying
            }
            else
            {
                txtChange.Text = "";
            }
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            if (btnViewCart.Text == "View Cart")
            {
                LoadCart();//loads card data
                dgvCart.Visible = true;
                dgvCart.Dock = DockStyle.Fill;
                dgvProducts.Visible = false; //hides products data table
                btnViewCart.Text = "View Products"; //changes the text of the button
            }
            else
            {
                LoadProducts();
                dgvCart.Visible = false;
                dgvProducts.Visible = true;
                dgvProducts.Dock = DockStyle.Fill;//hides cart data table
                btnViewCart.Text = "View Cart";//changes the text of the button
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (searchTerm.Length > 0) // Only search if there's text
            {
                DataTable foundProducts = ProductDAL.Find(searchTerm);
                dgvProducts.DataSource = foundProducts;
            }
            else
            {
                LoadProducts(); // Or clear dgvProducts if txtSearch is empty
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchTerm = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    DataTable foundProducts = ProductDAL.Find(searchTerm);
                    dgvProducts.DataSource = foundProducts; // Update search results DGV

                    if (foundProducts.Rows.Count == 1)//Add Found Item to cart
                    {
                        dgvProducts.ClearSelection(); // Clear previous selections
                        dgvProducts.Rows[0].Selected = true; // Select the first (and only) row

                        btnAddToCart_Click(sender, e); // Simulate a click on the Add button

                        txtSearch.Clear(); // Clear the search box for the next input
                        txtSearch.Focus(); // Keep focus on search box for rapid scanning

                        e.Handled = true;       // Prevent beep
                        e.SuppressKeyPress = true; // Prevent other default Enter key actions
                    }
                    else if (foundProducts.Rows.Count > 1)
                    {
                        // User needs to manually select from dgvProducts
                        MessageBox.Show("Multiple products found. Please select one from the list and click 'Add'.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvProducts.Focus(); // Give focus to the DGV for selection
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                    }
                }
                else
                {
                    LoadProducts(); // Reload all products if search box is empty
                    dgvProducts.ClearSelection();
                }
            }
        }
        private void dgvProducts_SelectedChanged(object sender, EventArgs e)
        {

        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomers.SelectedValue == null) return;

            this.customerId = Convert.ToInt32(cbCustomers.SelectedValue);

            try
            {
                txtBalance.Text = Convert.ToString(CustomerDAL.GetBalance(this.customerId));//recalculates customer balance
                CalculateAndSetTotals();// recalculates totals
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            Customers customerForm = new Customers();

            customerForm.ShowDialog();//loads customer form for adding a new customer

            LoadCustomers();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure it's a valid row
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                // Retrieve product information from the selected row
                Product product = new Product();
                product.ProductID = Convert.ToInt32(row.Cells["product_id"].Value);
                product.Name = row.Cells["name"].Value.ToString();
                product.SellingPrice = Convert.ToDecimal(row.Cells["selling_price"].Value);
                product.TaxRate = Convert.ToDecimal(row.Cells["tax_rate"].Value);
                product.Discount = Convert.ToDecimal(row.Cells["discount"].Value);
                product.Barcode = row.Cells["barcode"].Value.ToString();

                int qty = 1;
                AddToCart(product, qty);
            }
        }
        private void cbPaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentMethods.SelectedItem != null)
            {
                string selectedText = cbPaymentMethods.Text;

                //changes selected payment method based on combobox value
                if (selectedText == "Card")
                {
                    SelectedPaymentMethod = "Card";
                    txtCash.Text = txtTotal.Text;
                }
                else
                {
                    SelectedPaymentMethod = "Cash";
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
