using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a Point Of Sale  object, defining its properties and structure for passing point of sale data
    public class PoS
    {
        public DataTable Cart {  get; set; }
        public decimal Cash {  get; set; }
        public int CustomerId { get; set; }
        public decimal Globaldiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SubPrice { get; set; }
        public decimal Change {  get; set; }
        public int PaymentMethod { get; set; }
        public string Notes { get; set; }
    }
}
