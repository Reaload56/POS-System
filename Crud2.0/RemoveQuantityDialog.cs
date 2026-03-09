using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud2._0
{
    //form to remove a specific products quantity or to totally remove it
    public partial class RemoveQuantityDialog : Form
    {
        public int QuantityToRemove;
        public RemoveQuantityDialog()
        {
            InitializeComponent();
        }
        public RemoveQuantityDialog(int maxQuantity)
        {
            InitializeComponent();
            this.nudQuantity.Maximum = maxQuantity;//sets the maximum quantity to the number of available products in cart
            this.nudQuantity.Value = 1; // Default to removing one item
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //sends data to remove specified quantity from cart
            this.QuantityToRemove = (int)this.nudQuantity.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
