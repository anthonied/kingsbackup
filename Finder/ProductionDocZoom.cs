using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class ProductionDocZoom : Form
    {
        public TextBox txtActive;

        public string sDocNumber = "";
        public string sDocDate = "";
        public string sRespPersonRef = "";
        public string sSalesCode = "";
        public string sNotes = "";

        DataSet dsProductionDocs;
        BindingSource bsProductionDocs;

        public ProductionDocZoom()
        {
            InitializeComponent();
        }

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();
                        break;
                }

            }
            return bHandled;
        }

        private void ProductionDocZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtDocNum;
            this.ActiveControl = txtDocNum;

            //Set Default Dates
            dtpFrom.Value = DateTime.Now.AddDays(-30).Date;
            dtpTo.Value = DateTime.Now.Date;

            DBLoadProductionDocGrid();
        }

        private void DBLoadProductionDocGrid()
        {
            try
            {
                dgvProductionDocs.AutoGenerateColumns = false;
                dgvProductionDocs.DataSource = null;

                string sSql = "";

                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT * FROM SOLPRODH ";

                    sSql += " WHERE DocDate BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd") + "'"; //JR13 01/09/2011"; 
                    sSql += " ORDER BY DocNumber DESC";

                    dsProductionDocs = Connect.getDataSet(sSql, "ProductionDocs", liqConn);

                    bsProductionDocs = new BindingSource();
                    bsProductionDocs.DataSource = dsProductionDocs;
                    bsProductionDocs.DataMember = dsProductionDocs.Tables["ProductionDocs"].TableName;

                    dgvProductionDocs.DataSource = bsProductionDocs;
                    dgvProductionDocs.ClearSelection();

                    liqConn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Info: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        #region FILTERS

        private void txtDocNum_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(DocNumber LIKE '%" + txtDocNum.Text.Replace("'", "''") + "%' OR '" + txtDocNum.Text.Replace("'", "''") + "' = '') ";
            bsProductionDocs.Filter = sFilter;
        }

        private void txtRespPerson_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(RespPersonRef LIKE '%" + txtRespPerson.Text.Replace("'", "''") + "%' OR '" + txtRespPerson.Text.Replace("'", "''") + "' = '') ";
            bsProductionDocs.Filter = sFilter;
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            DBLoadProductionDocGrid();
        }

        #endregion

        #region HANDLE KEY STROKES & NAVIGATION

        private void dgvProductionDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sDocNumber = dgvProductionDocs.SelectedRows[0].Cells["clDocNumber"].Value.ToString();
            sDocDate = dgvProductionDocs.SelectedRows[0].Cells["clDocDate"].Value.ToString();
            sRespPersonRef = dgvProductionDocs.SelectedRows[0].Cells["clRespPerson"].Value.ToString();
            sSalesCode = dgvProductionDocs.SelectedRows[0].Cells["clSalesCode"].Value.ToString();
            sNotes = dgvProductionDocs.SelectedRows[0].Cells["clNotes"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvProductionDocs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvProductionDocs.Rows.Count > 0)
                {
                    sDocNumber = dgvProductionDocs.SelectedRows[0].Cells["clDocNumber"].Value.ToString();
                    sDocDate = dgvProductionDocs.SelectedRows[0].Cells["clDocDate"].Value.ToString();
                    sRespPersonRef = dgvProductionDocs.SelectedRows[0].Cells["clRespPerson"].Value.ToString();
                    sSalesCode = dgvProductionDocs.SelectedRows[0].Cells["clSalesCode"].Value.ToString();
                    sNotes = dgvProductionDocs.SelectedRows[0].Cells["clNotes"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgvProductionDocs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();

            txtActive.SelectionStart = txtDocNum.Text.Length;
            txtActive.SelectionLength = 0;
        }
               
        private void txtDocNum_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtDocNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvProductionDocs.Focus();
            }
        }

        private void txtRespPerson_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtRespPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvProductionDocs.Focus();
            }
        }

        #endregion

        

    }
}
