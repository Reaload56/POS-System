using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0.Models
{
    /// Represents a suppplier object, defining its properties and structure. 
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email {  get; set; }
        public string Address { get; set; }
    }
}
