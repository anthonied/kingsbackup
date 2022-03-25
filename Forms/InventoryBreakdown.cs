using System;
using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class InventoryBreakdown : Form
    {
        public decimal dNetMassPerUnit = 0;
        public decimal dUnitNetMass = 0;
        public decimal dQtyOnHand = 0;
        public decimal dQtySold = 0;
        public decimal dUnitPrice = 0;
        public int iQtySold = 0;
        
        public InventoryBreakdown()
        {
            InitializeComponent();
        }

        private void InventoryBreakdown_Load(object sender, EventArgs e)
        {
            lblQtyOnHand.Text = dQtyOnHand.ToString();
            lblNetMassPerUnit.Text = dNetMassPerUnit.ToString();
            lblUnitNetMass.Text = dUnitNetMass.ToString();
            lblUnitPrice.Text = dUnitPrice.ToString("N2");
            lblQtySold.Text = dQtySold.ToString("N2");
            iQtySold = Convert.ToInt32(dQtySold);
            lblQtyOnOrder.Text = iQtySold.ToString();
            lblQtyLeft.Text = (dQtyOnHand - Convert.ToDecimal(iQtySold)).ToString();
            lblPriceQtyOnOrder.Text = iQtySold.ToString();
            lblTotalPrice.Text = (Convert.ToDecimal(iQtySold) * dUnitPrice).ToString("N2");

        }

      
    }
}