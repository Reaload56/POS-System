using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a sale object, defining its properties and structure.
    internal class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public string InvoiceNumber { get; set; }
        public string Notes { get; set; }
        public int PaymentMethod { get; set; }
        public decimal Change {  get; set; }
        public decimal GlobalDiscount {  get; set; }

    }
}
