using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class SupplierDocumentZoom : Form
    {
        BindingSource bsSupplDocs;
        public TextBox txtActive;

        private string sBatchDocType = "";
        private string sNormalDocType = "";
        private string sCustomerCode = "";
        private string sAvailableDocs = "";
        
        public string sResult = "";
        public string sDocumentType = "";

        public SupplierDocumentZoom()
        {
            InitializeComponent();
        }

        private void SupplierDocumentZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtDocNumber;
            txtDocNumber.CharacterCasing = CharacterCasing.Upper;
            txtCustomerCode.CharacterCasing = CharacterCasing.Upper;
            txtDescription.CharacterCasing = CharacterCasing.Upper;

            //Set Default Dates
            dtpFrom.Value = DateTime.Now.AddDays(-30).Date;
            dtpTo.Value = DateTime.Now.Date;

            loadDocumentGrid();
        }

        public DialogResult ShowDialog(string BatchDocType, string NormalDocType, string CustomerCode, string AvailDocs)
        {
            sBatchDocType = BatchDocType;
            sNormalDocType = NormalDocType;
            sCustomerCode = CustomerCode;

            sAvailableDocs = AvailDocs;

            return this.ShowDialog();
        }

        private void loadDocumentGrid()
        {
            string sCompletedValue = char.ConvertFromUtf32(1);

            //dgSupplDocs.Rows.Clear();

            PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
            oConn.Open();
            
            string sSql = "SELECT DocumentType,DocumentNumber, HistoryHeader.CustomerCode CustCode, SupplDesc, DocumentDate"; 
            sSql += " FROM HistoryHeader";
            sSql += " LEFT JOIN SupplierMaster on SupplierMaster.SupplCode = HistoryHeader.CustomerCode ";

            if(sAvailableDocs != "")
                sSql += " WHERE DocumentNumber IN (" +sAvailableDocs + ") AND (DocumentNumber LIKE '%" + txtDocNumber.Text + "%' or '" + txtDocNumber.Text + "' = '')";
            else
                sSql += " WHERE DocumentType IN (" + sBatchDocType + "," + sNormalDocType + ") and (DocumentNumber like '%" + txtDocNumber.Text + "%' or '" + txtDocNumber.Text + "' = '')";

            sSql += " AND (upper(SupplDesc) LIKE '%" + txtDescription.Text + "%' or '" + txtDescription.Text + "' = '') ";
            sSql += " AND (upper(HistoryHeader.CustomerCode) LIKE '%" + txtCustomerCode.Text + "%' OR '" + txtCustomerCode.Text + "' = '') ";
            
            if (sCustomerCode != "")
                sSql += " AND HistoryHeader.CustomerCode = '" + sCustomerCode + "' ";

            if(sBatchDocType == "107" || sNormalDocType == "7")
                sSql += " AND HistoryHeader.CustomerCode = '" + sCustomerCode + "' ";

            sSql += " AND GRNMisc NOT IN ('" + sCompletedValue + "') ";

            sSql += " AND DocumentDate BETWEEN '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpTo.Value.ToString("yyyy-MM-dd") + "'"; //JR13 31/08/2011

            sSql += " ORDER by DocumentNumber DESC ";

            //JR
            dgSupplDocs.AutoGenerateColumns = false;

            DataSet dsSupplDocs = Liquid.Classes.Connect.getDataSet(sSql, "SupplierDocs", oConn);

            bsSupplDocs = new BindingSource();
            bsSupplDocs.DataSource = dsSupplDocs;
            bsSupplDocs.DataMember = dsSupplDocs.Tables["SupplierDocs"].TableName;

            dgSupplDocs.DataSource = bsSupplDocs;

            /*PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                int n = dgSupplDocs.Rows.Add();
                dgSupplDocs.Rows[n].Cells[0].Value = rdReader["DocumentNumber"].ToString();
                dgSupplDocs.Rows[n].Cells[1].Value = rdReader["CustCode"].ToString();
                dgSupplDocs.Rows[n].Cells[2].Value = Convert.ToDateTimeFromddMMyyyySlash(rdReader["DocumentDate"]).ToString("dd/MM/yyyy");
                dgSupplDocs.Rows[n].Cells[3].Value = rdReader["SupplDesc"].ToString();
 
                //JR Edit
                dgSupplDocs.Rows[n].Cells[4].Value = rdReader["DocumentType"].ToString();
            }
            rdReader.Close();*/

            oConn.Dispose();

            dgSupplDocs.Focus();
        }

        private void dgSalesOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgSupplDocs.SelectedRows[0].Cells[0].Value.ToString();
            sDocumentType = dgSupplDocs.SelectedRows[0].Cells[4].Value.ToString();

			this.DialogResult = DialogResult.OK;
			this.Close();
        }

        private void txtDocNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadDocumentGrid();
			}

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgSupplDocs.Focus();
            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            loadDocumentGrid();
        }

        private void dgSupplDocs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				sResult = dgSupplDocs.SelectedRows[0].Cells[0].Value.ToString();
                sDocumentType = dgSupplDocs.SelectedRows[0].Cells[4].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				if (e.KeyValue > 40)
				{
					e.SuppressKeyPress = true;
					txtActive.Text += char.ConvertFromUtf32(e.KeyValue);
                    txtActive.Focus();
                    txtActive.SelectionStart = txtActive.Text.Length;
                    txtActive.SelectionLength = 0;
				}
			}
        }

        private void txtDocNumber_TextChanged(object sender, EventArgs e)
        {
            string sFilter = "(DocumentNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' OR '" + txtDocNumber.Text.Replace("'", "''") + "' = '')";
            sFilter += " AND(SupplDesc LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";
            sFilter += " AND(CustCode LIKE '%" + txtCustomerCode.Text.Replace("'", "''") + "%' OR '" + txtCustomerCode.Text.Replace("'", "''") + "' = '')";

            bsSupplDocs.Filter = sFilter;
        }
                
        private void dgSupplDocs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();
            txtActive.SelectionStart = txtActive.Text.Length;
            txtActive.SelectionLength = 0;
        }

        private void txtCustomerCode_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

    }
}