using System;
using System.Data;
using System.Windows.Forms;

using Pervasive.Data.SqlClient;

using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class FPBatchZoom : Form
    {
        public TextBox txtActive;

        public string sBatchNumber = "";
        public string sItemCode = "";
        public string sDescription = "";
        public string sUnit = "";
        public double dQtyOnHand = 0;

        DataSet dsFPBatchInfo;
        BindingSource bsFPBatch;

        public FPBatchZoom()
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

        private void FPBatchZoom_Load(object sender, EventArgs e)
        {
            DBLoadFPBatchGrid();

            txtActive = txtBatchNum;
            this.ActiveControl = txtBatchNum;
        }

        private void DBLoadFPBatchGrid()
        {
            try
            {
                dgvFPBatches.AutoGenerateColumns = false;
                dgvFPBatches.DataSource = null;

                string sSql = "";

                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT DISTINCT SOLFPINVT.*,PDescription, PUnit ";
                    sSql += " FROM SOLFPINVT";
                    sSql += " LEFT JOIN SOLPRODL on PBatchNumber = BatchNumber";
                    sSql += " AND PItemCode = ItemCode";
                    sSql += " ORDER BY BatchNumber";

                    dsFPBatchInfo = Connect.getDataSet(sSql, "FPBatches", liqConn);

                    bsFPBatch = new BindingSource();
                    bsFPBatch.DataSource = dsFPBatchInfo;
                    bsFPBatch.DataMember = dsFPBatchInfo.Tables["FPBatches"].TableName;

                    dgvFPBatches.DataSource = bsFPBatch;
                    dgvFPBatches.ClearSelection();

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
            bsFPBatch.Filter = sFilter;
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(ItemCode LIKE '%" + txtItemCode.Text.Replace("'", "''") + "%' OR '" + txtItemCode.Text.Replace("'", "''") + "' = '') ";
            bsFPBatch.Filter = sFilter;
        }

        private void txtItemDesc_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(PDescription LIKE '%" + txtItemDesc.Text.Replace("'", "''") + "%' OR '" + txtItemDesc.Text.Replace("'", "''") + "' = '') ";
            bsFPBatch.Filter = sFilter;
        }

        #endregion

        private void dgvFPBatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sBatchNumber = dgvFPBatches.Rows[e.RowIndex].Cells["clBatchNum"].Value.ToString();
            sItemCode = dgvFPBatches.Rows[e.RowIndex].Cells["clItemCode"].Value.ToString();
            sDescription = dgvFPBatches.Rows[e.RowIndex].Cells["clItemDesc"].Value.ToString();
            sUnit = dgvFPBatches.Rows[e.RowIndex].Cells["clUnit"].Value.ToString();

            dQtyOnHand = Convert.ToDouble(dgvFPBatches.Rows[e.RowIndex].Cells["clQtyOnHand"].Value.ToString());
        }

        private void dgvFPBatches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvFPBatches.Rows.Count > 0)
                {
                    sBatchNumber = dgvFPBatches.SelectedRows[0].Cells["clBatchNum"].Value.ToString();
                    sItemCode = dgvFPBatches.SelectedRows[0].Cells["clItemCode"].Value.ToString();
                    sDescription = dgvFPBatches.SelectedRows[0].Cells["clItemDesc"].Value.ToString();
                    sUnit = dgvFPBatches.SelectedRows[0].Cells["clUnit"].Value.ToString();

                    dQtyOnHand = Convert.ToDouble(dgvFPBatches.SelectedRows[0].Cells["clQtyOnHand"].Value.ToString());

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }

        private void dgvFPBatches_KeyPress(object sender, KeyPressEventArgs e)
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
                dgvFPBatches.Focus();
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


    }
}
