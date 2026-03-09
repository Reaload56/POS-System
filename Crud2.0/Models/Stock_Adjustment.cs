using Crud2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a stock adjustment object, defining its properties and structure.
    public class Stock_Adjustment
    {
        public int adjustmentId { get; set; }
        public int productId{ get; set; }
        public int quantityChanged { get; set; }
        public string reason { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
    }
}
