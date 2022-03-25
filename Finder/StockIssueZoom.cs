using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class StockIssueZoom : Form
    {
        public TextBox txtActive;

        public string sDocNumber = "";
        public string sDocDate = "";
        public string sRespPersonRef = "";
        public string sSalesCode = "";
        public string sNotes = "";

        DataSet dsStockIssue;
        BindingSource bsStockIssue;

        public StockIssueZoom()
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

        private void StockIssueZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtDocNum;

            //Set Default Dates
            dtpFrom.Value = DateTime.Now.AddDays(-30).Date;
            dtpTo.Value = DateTime.Now.Date;

            DBLoadStockIssueDocs();

            this.ActiveControl = txtDocNum;
        }

        private void DBLoadStockIssueDocs()
        {
            try
            {
                dgvStockIssueDocs.AutoGenerateColumns = false;                
                dgvStockIssueDocs.DataSource = null;

                string sSql = "";

                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT * ";
                    sSql += " FROM SOLSIH ";
                    sSql += " WHERE DocDate BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd") + "'"; //JR13 01/09/2011"; 

                    sSql += " ORDER BY DocNumber DESC";

                    dsStockIssue = Connect.getDataSet(sSql, "StockIssue", liqConn);

                    bsStockIssue = new BindingSource();
                    bsStockIssue.DataSource = dsStockIssue;
                    bsStockIssue.DataMember = dsStockIssue.Tables["StockIssue"].TableName;

                    dgvStockIssueDocs.DataSource = bsStockIssue;

                    liqConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       

        #region FILTERS

        private void txtDocNum_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(DocNumber LIKE '%" + txtDocNum.Text.Replace("'", "''") + "%' OR '" + txtDocNum.Text.Replace("'", "''") + "' = '') ";
            bsStockIssue.Filter = sFilter;
        }

        private void txtRespPerson_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(RespPersonRef LIKE '%" + txtRespPerson.Text.Replace("'", "''") + "%' OR '" + txtRespPerson.Text.Replace("'", "''") + "' = '') ";
            bsStockIssue.Filter = sFilter;
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            DBLoadStockIssueDocs();
        }

        #endregion

        private void dgvStockIssueDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sDocNumber = dgvStockIssueDocs.Rows[e.RowIndex].Cells["clDocNumber"].Value.ToString();
            sDocDate = dgvStockIssueDocs.Rows[e.RowIndex].Cells["clDocDate"].Value.ToString();
            sRespPersonRef = dgvStockIssueDocs.Rows[e.RowIndex].Cells["clRespPerson"].Value.ToString();
            sSalesCode = dgvStockIssueDocs.Rows[e.RowIndex].Cells["clSalesCode"].Value.ToString();
            sNotes = dgvStockIssueDocs.Rows[e.RowIndex].Cells["clNotes"].Value.ToString();    

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        

        #region HANDLE KEY STROKES & NAVIGATION

        private void dgvStockIssueDocs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvStockIssueDocs.Rows.Count > 0)
                {
                    sDocNumber = dgvStockIssueDocs.SelectedRows[0].Cells["clDocNumber"].Value.ToString();
                    sDocDate = dgvStockIssueDocs.SelectedRows[0].Cells["clDocDate"].Value.ToString();
                    sRespPersonRef = dgvStockIssueDocs.SelectedRows[0].Cells["clRespPerson"].Value.ToString();
                    sSalesCode = dgvStockIssueDocs.SelectedRows[0].Cells["clSalesCode"].Value.ToString();
                    sNotes = dgvStockIssueDocs.SelectedRows[0].Cells["clNotes"].Value.ToString(); 

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void dgvStockIssueDocs_KeyPress(object sender, KeyPressEventArgs e)
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
                dgvStockIssueDocs.Focus();
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
                dgvStockIssueDocs.Focus();
            }
        }

        #endregion        

        private void btnFilterInclBatch_Click(object sender, EventArgs e)
        {
            string sFilter = "";
            if (txtInclBatch.Text != "")
            {
                string sSIRange = DBFetchSIRange();

                sFilter = "(DocNumber IN " + sSIRange + ")";                
            }

            bsStockIssue.Filter = sFilter;
        }

        private string DBFetchSIRange()
        {
            string sSql = "";
            string sSIRange = "(";

            using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                liqConn.Open();

                sSql = "SELECT DocNumber FROM SOLSIL";
                sSql += " WHERE BatchNumber LIKE '%" + txtInclBatch.Text + "%'"; 

                PsqlDataReader rdReader = Connect.getDataCommand(sSql, liqConn).ExecuteReader();

                if (rdReader.HasRows)
                {
                    while (rdReader.Read())
                    {
                        sSIRange += "'" + rdReader["DocNumber"].ToString().Trim() + "',";
                    }

                    rdReader.Close();
                }

                liqConn.Close();
            }

            sSIRange = sSIRange.Substring(0, sSIRange.Length - 1);
            sSIRange += ")";
            
            return sSIRange;

        }

       
               
    }
}
