using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class RawSIBatchZoom : Form
    {
        public TextBox txtActive;

        public string sBatchNumber = "";
        public string sItemCode = "";
        public string sDescription = "";

        DataSet dsRawBatchInfo;
        BindingSource bsRawBatch;

        public string sDocNumFilter = "";

        public RawSIBatchZoom()
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

        private void RawSIBatchZoom_Load(object sender, EventArgs e)
        {            
            lblSINumber.Text = sDocNumFilter;
            DBLoadRawBatchGrid();

            txtActive = txtBatchNum;
            this.ActiveControl = txtBatchNum;
        }

        private void DBLoadRawBatchGrid()
        {
            try
            {
                dgvRawBatches.AutoGenerateColumns = false;                
                dgvRawBatches.DataSource = null;                

                string sSql = "";

                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT * FROM SOLSIL";
                    sSql += " WHERE DocNumber = '" +sDocNumFilter + "'" ;

                    dsRawBatchInfo = Connect.getDataSet(sSql, "RawBatch", liqConn);

                    bsRawBatch = new BindingSource();
                    bsRawBatch.DataSource = dsRawBatchInfo;
                    bsRawBatch.DataMember = dsRawBatchInfo.Tables["RawBatch"].TableName;

                    dgvRawBatches.DataSource = bsRawBatch;                    

                    liqConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Info: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #region FILTERS

        private void txtBatchNum_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(BatchNumber LIKE '%" + txtBatchNum.Text.Replace("'", "''") + "%' OR '" + txtBatchNum.Text.Replace("'", "''") + "' = '') ";
            bsRawBatch.Filter = sFilter;
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(ItemCode LIKE '%" + txtItemCode.Text.Replace("'", "''") + "%' OR '" + txtItemCode.Text.Replace("'", "''") + "' = '') ";
            bsRawBatch.Filter = sFilter;
        }

        private void txtItemDesc_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Description LIKE '%" + txtItemDesc.Text.Replace("'", "''") + "%' OR '" + txtItemDesc.Text.Replace("'", "''") + "' = '') ";
            bsRawBatch.Filter = sFilter;
        }

        #endregion

        private void dgvRawBatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sBatchNumber = dgvRawBatches.Rows[e.RowIndex].Cells["clBatchNum"].Value.ToString();
            sItemCode = dgvRawBatches.Rows[e.RowIndex].Cells["clItemCode"].Value.ToString();
            sDescription = dgvRawBatches.Rows[e.RowIndex].Cells["clItemDesc"].Value.ToString();
        }

        private void dgvRawBatches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvRawBatches.Rows.Count > 0)
                {
                    sBatchNumber = dgvRawBatches.SelectedRows[0].Cells["clBatchNum"].Value.ToString();
                    sItemCode = dgvRawBatches.SelectedRows[0].Cells["clItemCode"].Value.ToString();
                    sDescription = dgvRawBatches.SelectedRows[0].Cells["clItemDesc"].Value.ToString();                                        

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }

        #region HANDLE KEY STROKES & NAVIGATION

        private void dgvRawBatches_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();

            txtActive.SelectionStart = txtBatchNum.Text.Length;
            txtActive.SelectionLength = 0;	
        }

        private void txtBatchNum_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtBatchNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvRawBatches.Focus();
            }
        }

        private void txtItemCode_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtItemDesc_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        #endregion
    }
}
