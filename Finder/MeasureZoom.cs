using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class MeasureZoom : Form
    {
        public MeasureZoom()
        {
            InitializeComponent();
        }
        public string sUnit = "";
        public string sCategory = "001";
        private void MeasureZoom_Load(object sender, EventArgs e)
        {
            //int iRow = dgvUnits.Rows.Add();
            //dgvUnits.Rows[iRow].Cells[0].Value = "EACH";
            //iRow = dgvUnits.Rows.Add();
            //dgvUnits.Rows[iRow].Cells[0].Value = "KILO";
            //iRow = dgvUnits.Rows.Add();
            //dgvUnits.Rows[iRow].Cells[0].Value = "12KG";
            loaddgvUnits();
        }

        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sUnit = dgvUnits.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void loaddgvUnits()
        {
            dgvUnits.Rows.Clear();
       
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "select * from SOLMS where fkInventoryCategory = '" + sCategory.Trim() + "'";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgvUnits.Rows.Add();
                    dgvUnits.Rows[n].Cells[0].Value = rdReader["sUnit"].ToString();
                    dgvUnits.Rows[n].Cells[1].Value = rdReader["dNetMass"].ToString();
                }
                rdReader.Close();
            }
        }

        private void txtSearchFilter_TextChanged(object sender, EventArgs e)
        {
            dgvUnits.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "select * from SOLMS where sUnit like '%" + txtSearchFilter.Text + "%' AND fkInventoryCategory = '" + sCategory + "'";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgvUnits.Rows.Add();
                    dgvUnits.Rows[n].Cells[0].Value = rdReader["sUnit"].ToString();
                    dgvUnits.Rows[n].Cells[1].Value = rdReader["dNetMass"].ToString();
                }
                rdReader.Close();
            }

        }

        private void dgvUnits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loaddgvUnits();
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvUnits.Focus();

            }
        }

    }
}