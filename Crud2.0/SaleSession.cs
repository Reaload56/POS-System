using Crud2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    internal class SaleSession
    {
        public static PoS CurrentSale { get; set; }
        public static void Clear()
        {
            CurrentSale = null;
        }
    }
}
