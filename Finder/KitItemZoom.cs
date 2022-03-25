using System;
using Pervasive.Data.SqlClient;
using System.Windows.Forms;

namespace Liquid.Finder
{
    public partial class KitItemZoom : Form
    {
        public string sResult = "";
        public KitItemZoom()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KitItemZoom_Load(object sender, EventArgs e)
        {
            LoadKitGrid();
        }

        private void LoadKitGrid()
        {
            dgKitZoom.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                String sSql = "Select KitName From SOLKIT where KitName like '%" + txtKitName.Text.Trim() + "%' group by KitName";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgKitZoom.Rows.Add();
                    dgKitZoom.Rows[n].Cells["clKitName"].Value = rdReader["KitName"].ToString();
                }
            }
        }

        private void dgKitZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgKitZoom.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtKitName_TextChanged(object sender, EventArgs e)
        {
            LoadKitGrid();
        }

    
    }
}
