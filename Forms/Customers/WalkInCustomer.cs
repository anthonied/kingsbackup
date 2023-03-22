using Liquid.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid.Forms.Customers
{
    public partial class WalkInCustomer : Form
    {
        public WalkInCustomer()
        {
            InitializeComponent();
        }

        private void WalkInCustomer_Load(object sender, EventArgs e)
        {
            var api = new BlackListApiClient();

            var fraudsters = api.GetAllFraudRecords();

            if (fraudsters == null)
                return;

            dgFraudList.DataSource = fraudsters;

            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
