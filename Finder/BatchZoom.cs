using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class BatchZoom : Form
    {
        public TextBox txtActive;

        public string sBatchNumber = "";
        public string sItemCode = "";
        public string sDescription = "";
        public string sUnit = "";
        public string sQtyOnHand = "";        

        DataSet dsBatchInfo;
        DataTable dtBatches;
        DataRow drNewRow;

        BindingSource bsBatches;
   
        public BatchZoom()
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

        private void BatchZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtBatchNum;            

            DBLoadBatchGrid();
        }

        public void DBLoadBatchGrid()
        {
            try
            {
                dgvBatches.AutoGenerateColumns = false;
                dgvBatches.Columns["clQtyOnHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBatches.DataSource = null;

                drNewRow = null;
                dtBatches = null;

                DefineDataStructures();
                
                string sSql = "";
                string sPasSql = "";
                
                string sCurrentDocNum = "";
                string sCurrentItemCode = "";

                string sCurrentSupplier = "";
                string sCurrentItemDesc = "";
                string sCurrentUnitSize = "";

                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT SOLINVTTRANS.DocNumber,";
                    sSql += " SOLINVT.ItemCode, SOLINVT.BatchNumber,QtyOnHand";

                    sSql += " FROM SOLINVT";

                    sSql += " LEFT JOIN SOLINVTTRANS on";
                    sSql += " (SOLINVT.ItemCode = SOLINVTTRANS.ItemCode AND";
                    sSql += " SOLINVT.BatchNumber = SOLINVTTRANS.BatchNumber)";                    
                                        
                    sSql += " WHERE SOLINVTTRANS.Type = 1";
                                          
                    sSql += " ORDER BY DocNumber,SOLINVT.BatchNumber,SOLINVT.ItemCode";

                    PsqlDataReader rdInvtReader = Connect.getDataCommand(sSql, liqConn).ExecuteReader();

                    if (rdInvtReader.HasRows)
                    {
                        while (rdInvtReader.Read())
                        {
                            sCurrentDocNum = rdInvtReader["DocNumber"].ToString().Trim();
                            sCurrentItemCode = rdInvtReader["ItemCode"].ToString().Trim();

                            using (PsqlConnection pasConn = new PsqlConnection(Connect.PastelConnectionString))
                            {
                                sPasSql = "SELECT SupplDesc FROM HistoryHeader";
                                sPasSql += " LEFT JOIN SupplierMaster on CustomerCode = SupplCode";
                                sPasSql += " WHERE DocumentNumber = '" + sCurrentDocNum + "'";

                                sCurrentSupplier = Connect.getDataCommand(sPasSql, pasConn).ExecuteScalar().ToString().Trim();

                                sPasSql = "SELECT Description FROM Inventory";
                                sPasSql += " WHERE ItemCode = '" +sCurrentItemCode + "'";

                                sCurrentItemDesc = Connect.getDataCommand(sPasSql, pasConn).ExecuteScalar().ToString().Trim();

                                sPasSql = "SELECT UnitSize FROM Inventory";
                                sPasSql += " WHERE ItemCode = '" + sCurrentItemCode + "'";

                                sCurrentUnitSize = Connect.getDataCommand(sPasSql, pasConn).ExecuteScalar().ToString().Trim();

                                //Build Dataset Records                                                                                                
                                drNewRow = dsBatchInfo.Tables["Batches"].NewRow();                                

                                drNewRow["BatchNumber"] = rdInvtReader["BatchNumber"].ToString().Trim();
                                drNewRow["ItemCode"] = rdInvtReader["ItemCode"].ToString().Trim();
                                drNewRow["Description"] = sCurrentItemDesc;
                                drNewRow["Supplier"] = sCurrentSupplier;
                                drNewRow["UnitSize"] = sCurrentUnitSize;
                                drNewRow["DocumentNumber"] = sCurrentDocNum;
                                drNewRow["QtyOnHand"] = rdInvtReader["QtyOnHand"].ToString().Trim();

                                dsBatchInfo.Tables["Batches"].Rows.Add(drNewRow);
                            }
                        }

                        rdInvtReader.Close();
                    }

                    bsBatches = new BindingSource();
                    bsBatches.DataSource = dsBatchInfo;
                    bsBatches.DataMember = dsBatchInfo.Tables["Batches"].TableName;

                    dgvBatches.DataSource = bsBatches;

                    liqConn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Info: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefineDataStructures()
        {
            dsBatchInfo = new DataSet();
            dtBatches = dsBatchInfo.Tables.Add("Batches");

            dtBatches.Columns.Add("BatchNumber", typeof(string));
            dtBatches.Columns.Add("ItemCode", typeof(string));
            dtBatches.Columns.Add("Description", typeof(string));
            dtBatches.Columns.Add("Supplier", typeof(string));
            dtBatches.Columns.Add("DocumentNumber", typeof(string));
                        
            dtBatches.Columns.Add("QtyOnHand", typeof(string));
            dtBatches.Columns.Add("UnitSize", typeof(string));
        }

        #region FILTERS
        
        private void txtBatchNum_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(BatchNumber LIKE '%" + txtBatchNum.Text.Replace("'", "''") + "%' OR '" + txtBatchNum.Text.Replace("'", "''") + "' = '') ";
            bsBatches.Filter = sFilter;
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(ItemCode LIKE '%" + txtItemCode.Text.Replace("'", "''") + "%' OR '" + txtItemCode.Text.Replace("'", "''") + "' = '') ";
            bsBatches.Filter = sFilter;
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Supplier LIKE '%" + txtSupplier.Text.Replace("'", "''") + "%' OR '" + txtSupplier.Text.Replace("'", "''") + "' = '') ";
            bsBatches.Filter = sFilter;
        }

        private void txtItemDesc_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(Description LIKE '%" + txtItemDesc.Text.Replace("'", "''") + "%' OR '" + txtItemDesc.Text.Replace("'", "''") + "' = '') ";
            bsBatches.Filter = sFilter;
        }

        #endregion

        private void dgvBatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sBatchNumber = dgvBatches.Rows[e.RowIndex].Cells["clBatchNum"].Value.ToString();
            sItemCode = dgvBatches.Rows[e.RowIndex].Cells["clItemCode"].Value.ToString();
            sDescription = dgvBatches.Rows[e.RowIndex].Cells["clItemDesc"].Value.ToString();
            sUnit = dgvBatches.Rows[e.RowIndex].Cells["clItemUnit"].Value.ToString();
            sQtyOnHand = dgvBatches.Rows[e.RowIndex].Cells["clQtyOnHand"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region HANDLE KEY STROKES & NAVIGATION
        
        private void dgvBatches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                if (dgvBatches.Rows.Count > 0)
                {                    
                    sBatchNumber = dgvBatches.SelectedRows[0].Cells["clBatchNum"].Value.ToString();
                    sItemCode = dgvBatches.SelectedRows[0].Cells["clItemCode"].Value.ToString();
                    sDescription = dgvBatches.SelectedRows[0].Cells["clItemDesc"].Value.ToString();
                    sUnit = dgvBatches.SelectedRows[0].Cells["clItemUnit"].Value.ToString(); 
                    
                    sQtyOnHand = dgvBatches.SelectedRows[0].Cells["clQtyOnHand"].Value.ToString(); 
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }
        private void dgvBatches_KeyPress(object sender, KeyPressEventArgs e)
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
                dgvBatches.Focus();
            }
        }

        private void txtItemCode_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvBatches.Focus();
            }
        }
        
        private void txtSupplier_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }
        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvBatches.Focus();
            }
        }

        private void txtItemDesc_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }
        private void txtItemDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvBatches.Focus();
            }
        }

        #endregion

      

       

    }
}
