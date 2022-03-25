using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class CustomerZoom : Form
	{
		BindingSource bsSalesOrder;
		public TextBox txtActive;
		
		public string CustomerCode = "";
		public string DeliveryCode = "";
		public string CustomerDescription = "";

		public	Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
		private CodeProject.SystemHotkey.SystemHotkey newCustomerKey;

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

		public CustomerZoom()
		{
			InitializeComponent();
		    newCustomerKey = new CodeProject.SystemHotkey.SystemHotkey {Shortcut = System.Windows.Forms.Shortcut.CtrlN};

		    newCustomerKey.Pressed += new System.EventHandler(this.cmdNew_Click);
		}

		private void CustomerZoom_Load(object sender, EventArgs e)
		{
			txtActive = txtAccountCode;
			txtAccountCode.CharacterCasing = CharacterCasing.Upper;
			txtDescription.CharacterCasing = CharacterCasing.Upper;
			loadCustomerGrid();
		}
		
		private void loadCustomerGrid()
		{
			var pastelConnection = new PsqlConnection(Classes.Connect.PastelConnectionString);
			pastelConnection.Open();

			var sql = string.Format(@"SELECT CustomerMaster.CustomerCode,Telephone, CustomerDesc,CustomerMaster.UserDefined01 'IDNumber',  if(Blocked = '1','Blocked','Active') 'Blocked'
                        FROM CustomerMaster
			            LEFT JOIN DeliveryAddresses on (CustomerMaster.CustomerCode = DeliveryAddresses.CustomerCode and DeliveryAddresses.Telephone <> '')
			            WHERE (CustomerMaster.CustomerCode LIKE '%{0}%' or '{0}' = '') 
			            AND (upper(CustomerMaster.CustomerDesc) LIKE '%{1}%' or '{1}' = '')            
			            ORDER BY CustomerMaster.CustomerCode ", txtAccountCode.Text.Replace("\r", ""), txtDescription.Text);
            
                
			
			var customerDataSet = Classes.Connect.getDataSet(sql, "Customers", pastelConnection);

			bsSalesOrder = new BindingSource();
			bsSalesOrder.DataSource = customerDataSet;
			bsSalesOrder.DataMember = customerDataSet.Tables["Customers"].TableName;            

			dgCustomers.DataSource = bsSalesOrder;

			pastelConnection.Dispose();
			dgCustomers.Focus();
		}

		private void addDataGridLine(string [] aRecord)
		{
			int n = dgCustomers.Rows.Add();

			dgCustomers.Rows[n].Cells[0].Value = aRecord[1];
			dgCustomers.Rows[n].Cells[1].Value = aRecord[4];
			dgCustomers.Rows[n].Cells[2].Value = aRecord[5];
			dgCustomers.Rows[n].Cells[3].Value = aRecord[13];

		}

		private void dgCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			LoadCustomerNote();
		}

		private void txtAccountCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadCustomerGrid();
			}

			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				dgCustomers.Focus();
			}
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadCustomerGrid();
		}

		private void dgCustomers_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
			   
				if (dgCustomers.Rows.Count > 0)
				{
					CustomerCode = dgCustomers.SelectedRows[0].Cells[0].Value.ToString();
					CustomerDescription = dgCustomers.SelectedRows[0].Cells["clDescription"].Value.ToString();
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}			
		}

		private void LoadCustomerNote()
		{

			bool bnote = false;
			using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
			{
				oConn.Open();
				string sSql = "SELECT Note FROM SOLCN where IDNumber = '" + dgCustomers.SelectedRows[0].Cells[3].Value.ToString().Trim() + "' AND CustomerCode = '" + dgCustomers.SelectedRows[0].Cells[0].Value.ToString().Trim() + "'";

				PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
				while (rdReader.Read())
				{
					Liquid.Forms.CompanyNotePopUp frmCompanyNote = new Liquid.Forms.CompanyNotePopUp();
					frmCompanyNote.lblCompanyNote.Text = rdReader["Note"].ToString();
					frmCompanyNote.lblCompanyName.Text = dgCustomers.SelectedRows[0].Cells["clDescription"].Value.ToString().Trim();
					if (frmCompanyNote.ShowDialog() == DialogResult.OK)
					{
						CustomerCode = dgCustomers.SelectedRows[0].Cells[0].Value.ToString();
						CustomerDescription = dgCustomers.SelectedRows[0].Cells["clDescription"].Value.ToString();

						this.DialogResult = DialogResult.OK;
						bnote = true;
					}
					else
					{
						bnote = true;
					}
				}
			}
			if (!bnote)
			{
				CustomerCode = dgCustomers.SelectedRows[0].Cells[0].Value.ToString();
				CustomerDescription = dgCustomers.SelectedRows[0].Cells["clDescription"].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;		
				using (CustomerView frmCustomer = new Liquid.Finder.CustomerView())
				{
					if (frmCustomer.ShowDialog(true) == DialogResult.OK)
					{
						CustomerCode = frmCustomer.sResult;
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void dgCustomers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\t' && e.KeyChar != '\b')
				txtActive.Text += e.KeyChar.ToString();

			txtActive.Focus();
			txtActive.SelectionStart = txtActive.Text.Length;
			txtActive.SelectionLength = 0;
	 
		}

		private void txtAccountCode_TextChanged(object sender, EventArgs e)
		{
			string sFilter = "(CustomerCode LIKE '%" + txtAccountCode.Text.Replace("'", "''").Replace("\r", "") + "%' OR '" + txtAccountCode.Text.Replace("'", "''").Replace("\r", "") + "' = '') ";
			sFilter += " AND (CustomerDesc LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' OR '" + txtDescription.Text.Replace("'", "''") + "' = '') ";            
			sFilter += " AND (Telephone LIKE '%" + txtTelephoneNumber.Text.Replace("'", "''") + "%' OR '" + txtTelephoneNumber.Text.Replace("'", "''") + "' = '') ";
			sFilter += " AND (IDNumber LIKE '%" + txtIDNumber.Text.Replace("'", "''") + "%' OR '" + txtIDNumber.Text.Replace("'", "''") + "' = '') ";           

			bsSalesOrder.Filter = sFilter;

		}

		private void txtAccountCode_Enter(object sender, EventArgs e)
		{
			txtActive = (TextBox)sender;
		}

		private void chkBlocked_CheckedChanged(object sender, EventArgs e)
		{
			loadCustomerGrid();
		}
	}
}