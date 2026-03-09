using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2._0
{
    /// a Class that provides static methods for performing calculations related to a shopping cart.
    public class Calculator
    {
        /// <summary>
        /// Calculates the subtotal, total tax, total discount, and final total for items in a cart.
        /// </summary>
        /// <param name="cartTable"></param>
        /// <returns></returns>
        public static CalculationResult CalculateCart(DataTable cartTable)
        {
            decimal total = 0;
            decimal subTotal = 0;
            decimal totalTax = 0;
            decimal totalDiscount = 0;
            // Iterates through each row (item) in the provided cart DataTable.
            foreach (DataRow row in cartTable.Rows)
            {
                decimal itemSubTotal = Convert.ToDecimal(row["selling_price"]) * Convert.ToInt32(row["Quantity"]);
                decimal itemDiscount = itemSubTotal * (Convert.ToDecimal(row["Discount"]) / 100);
                decimal itemTax = itemSubTotal * (Convert.ToDecimal(row["Tax Rate"]) / 100);

                subTotal += itemSubTotal;
                totalDiscount += itemDiscount;
                totalTax += itemTax;
                // Adds the net amount for the current item (subtotal - discount + tax) to the overall total.
                total += (itemSubTotal - itemDiscount + itemTax);
            }
            // Returns a new CalculationResult object populated with the final calculated values.
            return new CalculationResult
            {
                SubTotal = subTotal,
                Discount = totalDiscount,
                Tax = totalTax,
                Total = total
            };
        }
    }
}
