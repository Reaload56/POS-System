using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a stock object, defining its properties and structure.
    public class Stock
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public int TotalProductsBought { get; set; }
    }

}
