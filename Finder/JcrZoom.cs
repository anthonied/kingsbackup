using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class JcrZoom : Form
    {
        public JcrZoom()
        {
            InitializeComponent();
        }
        public string sResult = "";
        public string sCustCode = "";

        private void LoadJcrGrid()
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "Select Jcr as 'JCR Number', CustCode as 'Customer Code'  FROM SOLPDH where Jcr like '%" + txtJcr.Text + "%' group by Jcr,CustCode order by CustCode";
                // dgProjectZoom.AutoGenerateColumns = false;
                DataSet dsJcrZoom = Liquid.Classes.Connect.getDataSet(sSql, "Jcr", oConn);
                BindingSource bsJcrZoom = new BindingSource();
                bsJcrZoom.DataSource = dsJcrZoom;
                bsJcrZoom.DataMember = dsJcrZoom.Tables["Jcr"].TableName;
                dgJcrZoom.DataSource = bsJcrZoom;
                oConn.Dispose();

                dgJcrZoom.Columns[0].Width = 160;
                dgJcrZoom.Columns[1].Width = 160;
            }
        }

      

        private void txtJcr_TextChanged(object sender, EventArgs e)
        {
            LoadJcrGrid();
        }

        private void JcrZoom_Load(object sender, EventArgs e)
        {
            LoadJcrGrid();
        }

        private void dgJcrZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {      
            sResult = dgJcrZoom.SelectedRows[0].Cells[0].Value.ToString();
            sCustCode = dgJcrZoom.SelectedRows[0].Cells[1].Value.ToString();         
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
     
        private void dgJcrZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgJcrZoom.Rows.Count > 0)
                {
                    sResult = dgJcrZoom.SelectedRows[0].Cells[0].Value.ToString();
                    sCustCode = dgJcrZoom.SelectedRows[0].Cells[1].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
