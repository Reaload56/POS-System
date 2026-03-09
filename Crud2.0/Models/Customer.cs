using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a customer object, defining its properties and structure.
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
        public DateTime PayBackDate { get; set; }
        public string CustomerType { get; set; }
    }
}
