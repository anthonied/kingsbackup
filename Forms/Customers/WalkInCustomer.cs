using Liquid.Classes;
using Liquid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Liquid.Forms.Customers
{
    public partial class WalkInCustomer : Form
    {
        public TempCustomer TempCustomer;
        private List<Fraudster> _fraudsters;
        public WalkInCustomer()
        {
            InitializeComponent();
           
        }

        private void WalkInCustomer_Load(object sender, EventArgs e)
        {
            var api = new BlackListApiClient();

            _fraudsters = api.GetAllFraudRecords();

            if (_fraudsters == null)
                return;

            loadAllFraudsters();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            TempCustomer = new TempCustomer
            {
                IdNumber = txtID.Text,
                Email = txtEmail.Text,
                Phone = txtMobile.Text,
                Name = txtName.Text,
                Surname = txtSurname.Text
            };

            this.DialogResult = DialogResult.OK;
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            dgFraudList.DataSource = _fraudsters.Where(item => filterGrid(item)).ToList();
            dgFraudList.Refresh();
        }

        private bool filterGrid(Fraudster item)
        {
            return item.ZaId.Contains(txtID.Text) && item.Email.ToUpper().Contains(txtEmail.Text.ToUpper()) &&
               item.Name.ToUpper().Contains(txtName.Text.ToUpper()) && item.Surname.ToUpper().Contains(txtSurname.Text.ToUpper()) &&
               item.Phone.Contains(txtMobile.Text);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            loadAllFraudsters();
        }

        private void loadAllFraudsters()
        {
            dgFraudList.DataSource = _fraudsters;
            dgFraudList.Refresh();
        }
    }
}
