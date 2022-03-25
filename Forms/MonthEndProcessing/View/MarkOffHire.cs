using Liquid.Domain;
using Liquid.Repository;
using System;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Forms.MonthEndProcessing.View
{
    public partial class MarkOffHire : Form
    {
        public DateTime OffHireStartDate;
        public DateTime OffHireEndDate;
        private Salesorder _salesorder;

        public MarkOffHire()
        {
            InitializeComponent();
        }

        public MarkOffHire(Salesorder salesorder)
        {
            _salesorder = salesorder;
            InitializeComponent();
            lblDeliveryNumber.Text = salesorder.Header.DocumentNumber;
        }

        private void cmdSaveOffhireDates_Click(object sender, EventArgs e)
        {
            _salesorder.OffHireStartDate = dtOffHireStartDate.Value;
            _salesorder.OffHireEndDate = dtOffHireEndDate.Value;

            var salesOrderRepository = new SalesOrderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
           
            var salesOrderIsUpdated = salesOrderRepository.UpdateSalesOrderOffHireDates(_salesorder);
            if (salesOrderIsUpdated)
               this.DialogResult = DialogResult.OK;
           
           this.Close();
        }
    }
}
