using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class UserZoom : Form
	{
		public string sUserCode = "";
		public string sDescription = "";
		public string sUserName = "";
		public string sPassword = "";
		public string sUserType = "";
		public string sCreditInvoice = "";
		public string sRetrunItemCancel = "";
		public string sCloseSalesOrder = "";
		public string sTelephoneNumber = "";
		public string sLockOrder = "";
		public string sShortName = "";
        public string sReturnItem = "";
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

		public UserZoom()
		{
			InitializeComponent();
		}
		private void UserZoom_Load(object sender, EventArgs e)
		{
			loadUserGrid();
		}

		private void loadUserGrid()
		{
			dgUserZoom.Rows.Clear();
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
			oConn.Open();

			string sSql = "Select * from SOLUS order by UserName";

			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();

			while (rdReader.Read())
			{
				int n = dgUserZoom.Rows.Add();
				dgUserZoom.Rows[n].Cells["clUserCode"].Value = rdReader["Code"].ToString();
				dgUserZoom.Rows[n].Cells["clDescription"].Value = rdReader["Description"].ToString();
				dgUserZoom.Rows[n].Cells["UserName"].Value = rdReader["UserName"].ToString();
				if (rdReader["UserType"].ToString() == "0")
					dgUserZoom.Rows[n].Cells["UserType"].Value = "Front Desk";
				if (rdReader["UserType"].ToString() == "1")
					dgUserZoom.Rows[n].Cells["UserType"].Value = "Administrator";
				if (rdReader["UserType"].ToString() == "2")
					dgUserZoom.Rows[n].Cells["UserType"].Value = "Asset Maintenance";
				dgUserZoom.Rows[n].Cells["Password"].Value = rdReader["Psswrd"].ToString();
				dgUserZoom.Rows[n].Cells["clCreditInvoice"].Value = rdReader["CreditInvoice"].ToString();
				dgUserZoom.Rows[n].Cells["clCancelReturn"].Value = rdReader["CancelReturnItem"].ToString();
				dgUserZoom.Rows[n].Cells["clCloseOrder"].Value = rdReader["CloseOrder"].ToString();
				dgUserZoom.Rows[n].Cells["clShortName"].Value = rdReader["ShortName"].ToString();
				dgUserZoom.Rows[n].Cells["clTelephoneNumber"].Value = rdReader["TelephoneNumber"].ToString();
				dgUserZoom.Rows[n].Cells["clLockOrder"].Value = rdReader["LockOrder"].ToString();
                dgUserZoom.Rows[n].Cells["clReturnItem"].Value = rdReader["ReturnItem"].ToString();
			}
			rdReader.Close();
			oConn.Dispose();
			dgUserZoom.Focus();
		}

		private void dgUserZoom_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sUserCode = dgUserZoom.Rows[e.RowIndex].Cells["clUserCode"].Value.ToString();
			sDescription = dgUserZoom.Rows[e.RowIndex].Cells["clDescription"].Value.ToString();
			sUserName = dgUserZoom.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
			sUserType = dgUserZoom.Rows[e.RowIndex].Cells["UserType"].Value.ToString();
			sPassword = dgUserZoom.Rows[e.RowIndex].Cells["Password"].Value.ToString();
			sCreditInvoice = dgUserZoom.Rows[e.RowIndex].Cells["clCreditInvoice"].Value.ToString();
			sRetrunItemCancel = dgUserZoom.Rows[e.RowIndex].Cells["clCancelReturn"].Value.ToString();
			sCloseSalesOrder = dgUserZoom.Rows[e.RowIndex].Cells["clCloseOrder"].Value.ToString();
			sTelephoneNumber = dgUserZoom.Rows[e.RowIndex].Cells["clTelephoneNumber"].Value.ToString();
			sShortName = dgUserZoom.Rows[e.RowIndex].Cells["clShortName"].Value.ToString();
			sLockOrder = dgUserZoom.Rows[e.RowIndex].Cells["clLockOrder"].Value.ToString();
            sReturnItem = dgUserZoom.Rows[e.RowIndex].Cells["clReturnItem"].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void UserZoom_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{                
				e.SuppressKeyPress = true;
				sUserCode = dgUserZoom.SelectedRows[0].Cells["clUserCode"].Value.ToString();
				sDescription = dgUserZoom.SelectedRows[0].Cells["clDescription"].Value.ToString();
				sUserName = dgUserZoom.SelectedRows[0].Cells["UserName"].Value.ToString();
				sUserType = dgUserZoom.SelectedRows[0].Cells["UserType"].Value.ToString();
				sPassword = dgUserZoom.SelectedRows[0].Cells["Password"].Value.ToString();
				sCreditInvoice = dgUserZoom.SelectedRows[0].Cells["clCreditInvoice"].Value.ToString();
				sRetrunItemCancel = dgUserZoom.SelectedRows[0].Cells["clCancelReturn"].Value.ToString();
				sCloseSalesOrder = dgUserZoom.SelectedRows[0].Cells["clCloseOrder"].Value.ToString();
				sTelephoneNumber = dgUserZoom.SelectedRows[0].Cells["clTelephoneNumber"].Value.ToString();
				sShortName = dgUserZoom.SelectedRows[0].Cells["clShortName"].Value.ToString();
				sLockOrder = dgUserZoom.SelectedRows[0].Cells["clLockOrder"].Value.ToString();
                sReturnItem = dgUserZoom.SelectedRows[0].Cells["clReturnItem"].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			
		}

		
	}
}