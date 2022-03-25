using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Forms.Qoutes
{
    public partial class ItemCodeQoutes : Form
    {
        public ItemCodeQoutes()
        {
            InitializeComponent();
        }

        public string sItemCode = "";
        public string sProjectNumber = "";

        private void ItemCodeQoutes_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {

            using (PsqlConnection oConn = new PsqlConnection(Classes.Connect.LiquidConnectionString))
            {
                string sSql = "select SOLQHH.DocDate,SOLQHH.DocNumber,SOLQHH.CustCode,Project,SOLQHL.ItemCode from SOLQHH inner join SOLQHL on SOLQHL.DocNumber = SOLQHH.DocNumber ";
                       sSql += "where ItemCode = '" + sItemCode + "' And Project = '" + sProjectNumber + "' And SOLQHH.DocNumber like '%" + txtQoute.Text.Trim() + "%'";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgQoutes.Rows.Add();
                    dgQoutes.Rows[n].Cells[0].Value = rdReader["DocNumber"].ToString();
                    dgQoutes.Rows[n].Cells[1].Value = rdReader["CustCode"].ToString();
                    dgQoutes.Rows[n].Cells[2].Value = Convert.ToDateTime(rdReader["DocDate"].ToString()).ToString("yyyy/MM/dd");                 
                }
                oConn.Dispose();
                rdReader.Close();

            }
        }

        private void dgQoutes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgQoutes.Columns[e.ColumnIndex] == clDocNumber)
            {
                string sQoute = dgQoutes.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                Liquid.Forms.Qoutes.Qoute frmQoute = new Qoutes.Qoute();
                frmQoute.ShowDialog(sQoute);
            }
        }

        private void txtQoute_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
