using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Documents
{
    public partial class SalesOrderAuthorization : Form
    {
        public bool SuccessfulAuthorization = false;
        public string AutorizedPerson { get; set; }
        public bool HasAuthorizedPersons = true;

        public SalesOrderAuthorization(string customerName, string customerCode)
        {
            InitializeComponent();

            lblClientCode.Text = customerCode;
            lblClientName.Text = customerName;
            lblAuthorizedBy.Text = Global.sLogedInUserName;
        }

        private void SalesOrderAuthorization_Load(object sender, EventArgs e)
        {
            var authorisedPersons = getCustomerAuthorisedPersons(lblClientCode.Text);
            authorisedPersons.Insert(0, "Default");

           cbbAuthorizedPerson.DataSource = authorisedPersons;
        }


        private List<string> getCustomerAuthorisedPersons(string customerCode)
        {
            var persons = new List<string>();

            using (PsqlConnection connection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                var sql = String.Format("SELECT * FROM SOLAP WHERE customer_code = '{0}'", customerCode);
                PsqlDataReader rdReader = Connect.getDataCommand(sql, connection).ExecuteReader();
                while (rdReader.Read())
                {
                    persons.Add(rdReader["authorised_person"].ToString());
                }
            }

            return persons.OrderBy(x => x).ToList();
        }

        private void cmdAuthorize_Click(object sender, EventArgs e)
        {
            SuccessfulAuthorization = true;
            AutorizedPerson = cbbAuthorizedPerson.SelectedItem.ToString();
            this.Close();
        }

        

        private void cmdDecline_Click(object sender, EventArgs e)
        {
            SuccessfulAuthorization = false;
            this.Close();
        }

        private void cbbAuthorizedPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAuthorize.Focus();
        }
    }
}
