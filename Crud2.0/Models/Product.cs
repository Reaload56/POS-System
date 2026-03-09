using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a product object, defining its properties and structure.
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Discount { get; set; }
        public bool IsService { get; set; }
        public decimal SellingPrice { get; set; }
        public int SupplierID { get; set; }
    }
}
