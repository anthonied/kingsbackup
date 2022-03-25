using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class CustomerInvoiceZoom : Form
    {
        public TextBox txtActive;

        public string sDocumentNumber = "";
        public string sDocumentDate = "";
        public string sCustomerCode = "";        
        public string sOrderNumber = "";

        public string sSalesManCode = "";
        public string sDiscount = "";

        DataSet dsCustomerInv;
        BindingSource bsCustomerInv;        

        public CustomerInvoiceZoom()
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

        private void CustomerInvoiceZoom_Load(object sender, EventArgs e)
        {            
            //Set Default Dates
            dtpFrom.Value = DateTime.Now.AddDays(-30).Date;
            dtpTo.Value = DateTime.Now.Date;

            DBLoadCIGrid();

            txtActive = txtDocNumber;
            this.ActiveControl = txtDocNumber;
        }

        private void DBLoadCIGrid()
        {            
            try
            {
                dgvCustomerInvoices.AutoGenerateColumns = false;
                dgvCustomerInvoices.DataSource = null;

                //Fetch list of CI handled through liquid
                string sSql = "";
                string sLiqCIList = "(";
                            
                using (PsqlConnection liqConn = new PsqlConnection(Connect.LiquidConnectionString))
                {
                    liqConn.Open();

                    sSql = "SELECT DocNumber";
                    sSql += " FROM SOLFPINVTTRANS";
                    sSql += " WHERE Type = 0";

                    PsqlDataReader rdDocReader = Connect.getDataCommand(sSql, liqConn).ExecuteReader();

                    if (rdDocReader.HasRows)
                    {
                        while (rdDocReader.Read())
                        {
                            sLiqCIList += "'" + rdDocReader["DocNumber"].ToString().Trim() + "',";
                        }

                        rdDocReader.Close();

                        sLiqCIList = sLiqCIList.Substring(0, sLiqCIList.Length - 1);
                    }
                    else
                    {
                        sLiqCIList += "''";
                    }
                    
                    sLiqCIList += ")";

                    liqConn.Close();
                }               

                using (PsqlConnection pasConn = new PsqlConnection(Connect.PastelConnectionString))
                {
                    pasConn.Open();

                    sSql = "SELECT DISTINCT DocumentNumber, DocumentDate, HistoryHeader.CustomerCode, CustomerDesc, OrderNumber, SalesmanCode, DiscountPercent";
                    sSql += " FROM HistoryHeader";
                    sSql += " LEFT JOIN CustomerMaster on HistoryHeader.CustomerCode = CustomerMaster.CustomerCode";
                    sSql += " WHERE DocumentType IN (103,3)";

                    sSql += " AND DocumentNumber IN " + sLiqCIList;

                    sSql += " AND DocumentDate BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd") + "'";
                    sSql += " ORDER BY DocumentNumber DESC";

                    dsCustomerInv = Connect.getDataSet(sSql, "CustomerInvoices", pasConn);

                    bsCustomerInv = new BindingSource();
                    bsCustomerInv.DataSource = dsCustomerInv;
                    bsCustomerInv.DataMember = dsCustomerInv.Tables["CustomerInvoices"].TableName;

                    dgvCustomerInvoices.DataSource = bsCustomerInv;

                    pasConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Info: " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region FILTERS
        
        private void txtDocNumber_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(DocumentNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' OR '" + txtDocNumber.Text.Replace("'", "''") + "' = '') ";
            bsCustomerInv.Filter = sFilter;
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(CustomerCode LIKE '%" + txtCustomerCode.Text.Replace("'", "''") + "%' OR '" + txtCustomerCode.Text.Replace("'", "''") + "' = '') ";
            bsCustomerInv.Filter = sFilter;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(CustomerDesc LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            bsCustomerInv.Filter = sFilter;
        }

        #endregion

        private void dgvCustomerInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sDocumentNumber = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clNumber"].Value.ToString().Trim();
            sDocumentDate = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clDocDate"].Value.ToString().Trim();
            sCustomerCode = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clCustCode"].Value.ToString().Trim();
            sOrderNumber = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clOrderNumber"].Value.ToString().Trim();
            
            sSalesManCode = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clSalesman"].Value.ToString().Trim();
            sDiscount = dgvCustomerInvoices.Rows[e.RowIndex].Cells["clDiscount"].Value.ToString().Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region HANDLE KEY STROKES & NAVIGATION

        private void dgvCustomerInvoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvCustomerInvoices.Rows.Count > 0)
                {
                    sDocumentNumber = dgvCustomerInvoices.SelectedRows[0].Cells["clNumber"].Value.ToString().Trim();
                    sDocumentDate = dgvCustomerInvoices.SelectedRows[0].Cells["clDocDate"].Value.ToString().Trim();
                    sCustomerCode = dgvCustomerInvoices.SelectedRows[0].Cells["clCustCode"].Value.ToString().Trim();
                    sOrderNumber = dgvCustomerInvoices.SelectedRows[0].Cells["clOrderNumber"].Value.ToString().Trim();

                    sSalesManCode = dgvCustomerInvoices.SelectedRows[0].Cells["clSalesman"].Value.ToString().Trim();
                    sDiscount = dgvCustomerInvoices.SelectedRows[0].Cells["clDiscount"].Value.ToString().Trim();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }

        private void dgvCustomerInvoices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();

            txtActive.SelectionStart = txtDocNumber.Text.Length;
            txtActive.SelectionLength = 0;	
        }

        private void txtDocNumber_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void txtDocNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgvCustomerInvoices.Focus();
            }
        }

        #endregion
        
        private void cmdFilter_Click(object sender, EventArgs e)
        {
            DBLoadCIGrid();
        }
    }
}
