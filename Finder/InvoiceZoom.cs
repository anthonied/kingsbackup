using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class InvoiceZoom : Form
    {
        BindingSource bsSalesOrder;
        public TextBox txtActive;

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

        public InvoiceZoom()
        {
            InitializeComponent();
        }

        public string sResult = "";
        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();

        private void SalesOrderZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtSalesNumber;

            txtSalesNumber.CharacterCasing = CharacterCasing.Upper;
            txtCustomerCode.CharacterCasing = CharacterCasing.Upper;
            txtDescription.CharacterCasing = CharacterCasing.Upper;
            loadInvoiceGrid();
        }

        private void loadInvoiceGrid()
        {
            //dgSalesOrder.Rows.Clear();

            PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
            oConn.Open();
            string sSql = "SELECT top 200 HistoryHeader.Freight01 Salesorder,HistoryHeader.Message03 Site, DocumentNumber, HistoryHeader.CustomerCode CustCode, CustomerDesc, DocumentDate FROM HistoryHeader ";
            sSql += "LEFT JOIN CustomerMaster on CustomerMaster.CustomerCode = HistoryHeader.CustomerCode ";  
            sSql += " WHERE DocumentType in (103,3) AND (ltrim(rtrim(DocumentNumber)) like '%" + txtSalesNumber.Text + "%' or '" + txtSalesNumber.Text + "' = '')";
            sSql += " AND(upper(CustomerDesc) like '%" + txtDescription.Text + "%' or '" + txtDescription.Text + "' = '') ";
            sSql += " AND(upper(HistoryHeader.CustomerCode) like '%" + txtCustomerCode.Text + "%' or '" + txtCustomerCode.Text + "' = '') ";
            sSql += " ORDER BY DocumentNumber desc";
            
            dgSalesOrder.AutoGenerateColumns = false;
           
            DataSet dsSalesOrder = Liquid.Classes.Connect.getDataSet(sSql, "Invoice", oConn); 
            bsSalesOrder = new BindingSource();            
            bsSalesOrder.DataSource = dsSalesOrder;
            bsSalesOrder.DataMember = dsSalesOrder.Tables["Invoice"].TableName;
            dgSalesOrder.DataSource = bsSalesOrder;
            oConn.Dispose();
            dgSalesOrder.Focus();
            //foreach (DataGridViewRow dgRow in dgSalesOrder.Rows)
            //{
            //    string sInvoiceNumber = dgRow.Cells["clNumber"].Value.ToString();
            //    using (PsqlConnection oConnIL = new PsqlConnection(Liquid.Classes.Connect.sConnStr))
            //    {
            //        sSql = "Select top 1 SiteName from SOLIL where DocumentNumber = '" + sInvoiceNumber + "'";
            //        PsqlDataReader rdReaderIL = Liquid.Classes.Connect.getDataCommand(sSql, oConnIL).ExecuteReader();
            //        while (rdReaderIL.Read())
            //        {
            //            dgRow.Cells["clSite"].Value = rdReaderIL["SiteName"].ToString();                       
            //        }
            //        rdReaderIL.Dispose();
            //        oConnIL.Dispose();
            //    }
            //}
        }

        private void dgSalesOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtSalesNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadInvoiceGrid();
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgSalesOrder.Focus();
            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            loadInvoiceGrid();
        }

        private void dgSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgSalesOrder.Rows.Count > 0)
                {
                    sResult = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                //if (e.KeyValue > 40)
                //{
                //    e.SuppressKeyPress = true;
                //    txtSalesNumber.Text += char.ConvertFromUtf32(e.KeyValue).ToString();
                //    txtSalesNumber.Focus();
                //    txtSalesNumber.SelectionStart = txtSalesNumber.Text.Length;
                //    txtSalesNumber.SelectionLength = 0;
                //}
            }
        }

        private void dgSalesOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();
            txtActive.SelectionStart = txtActive.Text.Length;
            txtActive.SelectionLength = 0;
        }

        private void txtSalesNumber_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(DocumentNumber LIKE '%" + txtSalesNumber.Text.Replace("'", "''") + "%' OR '" + txtSalesNumber.Text.Replace("'", "''") + "' = '')";
            sFilter += " AND(CustomerDesc LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND(CustCode LIKE '%" + txtCustomerCode.Text.Replace("'", "''") + "%' or '" + txtCustomerCode.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND(Salesorder LIKE '%" + txtSalesOrder.Text.Replace("'", "''") + "%' or '" + txtSalesOrder.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND(Site LIKE '%" + txtSite.Text.Replace("'", "''") + "%' or '" + txtSite.Text.Replace("'", "''") + "' = '') ";
            bsSalesOrder.Filter = sFilter;
        }

        private void txtSalesNumber_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

        private void cmdFilterInvoiceZoom_Click(object sender, EventArgs e)
        {
            if (txtSalesNumber.Text != "")
            {
                PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
                oConn.Open();
                string sSql = "SELECT top 100 HistoryHeader.Freight01, Salesorder,HistoryHeader.Message03 Site, DocumentNumber, HistoryHeader.CustomerCode CustCode, CustomerDesc, DocumentDate, DeliveryAddresses.Heading";
                sSql += " FROM HistoryHeader , CustomerMaster, DeliveryAddresses ";
                sSql += " WHERE (DocumentNumber like '%" + txtSalesNumber.Text + "%' or '" + txtSalesNumber.Text + "' = '') AND DocumentType in (103,3) ";
                sSql += " AND CustomerMaster.CustomerCode = HistoryHeader.CustomerCode  and DeliveryAddresses.CustomerCode = HistoryHeader.CustomerCode  ";
                sSql += " ORDER BY DocumentNumber desc";

                dgSalesOrder.AutoGenerateColumns = false;

                DataSet dsSalesOrder = Liquid.Classes.Connect.getDataSet(sSql, "Invoice", oConn);
                bsSalesOrder = new BindingSource();
                bsSalesOrder.DataSource = dsSalesOrder;
                bsSalesOrder.DataMember = dsSalesOrder.Tables["Invoice"].TableName;
                dgSalesOrder.DataSource = bsSalesOrder;
                oConn.Dispose();
                dgSalesOrder.Focus();
                
            }
        }        	
    }
}