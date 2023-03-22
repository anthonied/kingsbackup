using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class SalesOrderZoom : Form
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

		public SalesOrderZoom()
		{
			InitializeComponent();
		}

		public string SelectedSalesOrderNumber = "";
		
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();

		private void SalesOrderZoom_Load(object sender, EventArgs e)
		{
			txtActive = txtSalesNumber;

			txtSalesNumber.CharacterCasing = CharacterCasing.Upper;
			txtCustomerCode.CharacterCasing = CharacterCasing.Upper;
			txtDescription.CharacterCasing = CharacterCasing.Upper;
			loadSalesGrid();
		}

		private void loadSalesGrid()
		{						
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConn.Open();
			string sSql = "SELECT Top 2000 DocumentNumber, HistoryHeader.CustomerCode CustCode, CustomerDesc, DocumentDate FROM HistoryHeader ";
			sSql += "LEFT JOIN CustomerMaster on CustomerMaster.CustomerCode = HistoryHeader.CustomerCode ";
			sSql += " WHERE DocumentType in (102,2) AND (DocumentNumber like '%" + txtSalesNumber.Text + "%' or '" + txtSalesNumber.Text + "' = '')" ;
			sSql += " AND(upper(CustomerDesc) like '%" + txtDescription.Text + "%' or '" + txtDescription.Text + "' = '') ";
			sSql += " AND(upper(HistoryHeader.CustomerCode) like '%" + txtCustomerCode.Text + "%' or '" + txtCustomerCode.Text + "' = '')  ";
			sSql += " ORDER BY DocumentNumber desc ";

			dgSalesOrder.AutoGenerateColumns = false;

			DataSet dsSalesOrder = Liquid.Classes.Connect.getDataSet(sSql, "Salesorder", oConn);

			bsSalesOrder = new BindingSource();
			bsSalesOrder.DataSource = dsSalesOrder;
			bsSalesOrder.DataMember = dsSalesOrder.Tables["Salesorder"].TableName;

			dgSalesOrder.DataSource = bsSalesOrder;
			
			oConn.Dispose();

			dgSalesOrder.Focus();
		}
				
		private void dgSalesOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var selectedIndex = dgSalesOrder.SelectedRows[0].Index;

			SelectedSalesOrderNumber = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void txtSalesNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadSalesGrid();
			}

			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				dgSalesOrder.Focus();
			}
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadSalesGrid();
		}

		private void dgSalesOrder_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				//LL Phalaborwa if
				if (dgSalesOrder.Rows.Count > 0)
				{
					SelectedSalesOrderNumber = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
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

			bsSalesOrder.Filter = sFilter;
		}

		private void txtSalesNumber_Enter(object sender, EventArgs e)
		{
			txtActive = (TextBox)sender;
		}

		private void dgSalesOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}        		
	}
}