using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class ProjectZoom : Form
    {
        BindingSource bsProjectZoom;
        public string sResult;
        public ProjectZoom()
        {
            InitializeComponent();
        }

        private void ProjectZoom_Load(object sender, EventArgs e)
        {
            LoadProjectGrid();
        }

        private void LoadProjectGrid()
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "Select ProjectNumber AS 'Project Number',ProjectDescription AS 'Project Description' FROM SOLPROJ where ProjectNumber like '%" + txtProjectNumber.Text + "%' AND ProjectDescription like '%" + txtProjectDescription.Text + "%' order by ProjectNumber";
               // dgProjectZoom.AutoGenerateColumns = false;

                DataSet dsProjectZoom = Liquid.Classes.Connect.getDataSet(sSql, "Project", oConn);

                bsProjectZoom = new BindingSource();
                bsProjectZoom.DataSource = dsProjectZoom;
                bsProjectZoom.DataMember = dsProjectZoom.Tables["Project"].TableName;

                dgProjectZoom.DataSource = bsProjectZoom;
                dgProjectZoom.Columns[0].Width = 190;
                dgProjectZoom.Columns[1].Width = 250;
              
                oConn.Dispose();
            }
        }

        private void txtProjectNumber_TextChanged(object sender, EventArgs e)
        {
            LoadProjectGrid();
        }

        private void txtProjectDescription_TextChanged(object sender, EventArgs e)
        {
            LoadProjectGrid();
        }

        private void dgProjectZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgProjectZoom.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgProjectZoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtProjectNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgProjectZoom.Focus();
            }
        }

        private void dgProjectZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgProjectZoom.Rows.Count > 0)
                {
                    sResult = dgProjectZoom.SelectedRows[0].Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
