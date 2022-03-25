using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Forms
{
	public partial class Users : Form
	{
		int iUpdate = 0;
		string sOldUserName = "";
		private CodeProject.SystemHotkey.SystemHotkey SearchUserHotKey;
		private string[] aActiveComponentsValidate = new string[3];

		public Users()
		{            
			InitializeComponent();

			SearchUserHotKey = new CodeProject.SystemHotkey.SystemHotkey();

			SearchUserHotKey.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			SearchUserHotKey.Pressed += new System.EventHandler(this.cmdSearch_Click);
			
		}

		private void Changes_TextChanged(object sender, EventArgs e)
		{
			cmdSave.Enabled = true;
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{
			//Validations
			if (txtUserName.Text == "")
			{
				MessageBox.Show("The Username may not be blank");
				txtUserName.Focus();
				return;
			}
			else if (txtPassword.Text == "")
			{
				MessageBox.Show("The Password may not be blank");
				txtPassword.Focus();
				return;
			}
			else if (selUserType.Text == "")
			{
				MessageBox.Show("Please select a User Type");
				selUserType.Focus();
				return;
			}
			else if (txtTel.Text == "")
			{
				MessageBox.Show("Please insert a Telephone Number for User");
				txtTel.Focus();
				return;
			}

			int iUserType = -1;
			if (selUserType.Text == "Front Desk")
				iUserType = 0;
			else if (selUserType.Text == "Administrator")
				iUserType = 1;
			else if (selUserType.Text == "Asset Maintenance")
				iUserType = 2;

			int iCancelReturn = 0;
			if (chkCancelReturn.Checked)
			{
				iCancelReturn = 1;
			}

			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
			oConn.Open();
			string sSql = "";
			string sSqlHL = "";
			int iReturn = 0;            

			if (txtUserName.Text != sOldUserName)
			{
				sSql = "select count(UserName) from SOLUS where UserName = '" + txtUserName.Text + "'";

				iReturn = Convert.ToInt32(Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString());
				if (iReturn > 0)
				{
					MessageBox.Show("The username already exists");
					return;
				}
			}
			string sCreditInvoice = "0";
			if (chkCreditInvoice.Checked)
			{
				sCreditInvoice = "1";
			}

			string sCloseOrder = "0";
			if (chkCloseOrder.Checked)
			{
				sCloseOrder = "1";
			}

			string sLockOrder = "0";
			if (chkLockOrder.Checked)
			{
				sLockOrder = "1";
			}

			string sReturnItem = "0";
			if (chkReturnItems.Checked)
			{
				sReturnItem = "1";
			}

			if (iUpdate == 0)
			{
				string sUserCode = "";
				if (txtUserCode.Text == "New")
				{
					sUserCode = getNextUserCode();
				}
			
				sSql = "Insert into SOLUS ";
				sSql += "(Code,Description,UserName,Psswrd,UserType,CreditInvoice, CancelReturnItem, CloseOrder, LockOrder, ShortName, TelephoneNumber, ReturnItem) ";
				sSql += "Values ";
				sSql += "('" + sUserCode + "','" + txtDescription.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "'," + iUserType + "," + sCreditInvoice + ", " + iCancelReturn + ", " + sCloseOrder + ", " + sLockOrder + ",'" + txtShortName.Text + "','" + txtTel.Text + "','" + sReturnItem + "')";
				sSqlHL = "Insert into SalesmanMaster ";
				sSqlHL += "(Code,Description,ComMethod) ";
				sSqlHL += "Values ";
				sSqlHL += "('" + sUserCode + "','" + txtDescription.Text + "','1')";
				txtUserCode.Text = sUserCode;
			}
			else if (iUpdate == 1)
			{
				sSql = "update SOLUS SET ";
				sSql += "Code = '" + txtUserCode.Text + "',";
				sSql += "Description = '" + txtDescription.Text + "',";
				sSql += "UserName = '" + txtUserName.Text + "',";
				sSql += "Psswrd = '" + txtPassword.Text + "',";
				sSql += "UserType = " + iUserType + " ";
				sSql += ", CreditInvoice = " + sCreditInvoice + " ";
				sSql += ", CancelReturnItem = " + iCancelReturn + " ";
				sSql += ", CloseOrder = " + sCloseOrder + " ";
				sSql += ", ShortName = '" + txtShortName.Text + "' ";
				sSql += ", TelephoneNumber = '" + txtTel.Text + "' ";
				sSql += ", LockOrder = '" + sLockOrder + "' ";
				sSql += ", ReturnItem = '" + sReturnItem + "' ";
				sSql += "where UserName = '" + sOldUserName + "'";

				sSqlHL = "Update SalesmanMaster set ";
				sSqlHL += "Description = '" + txtDescription.Text + "' ";
				sSqlHL += "where code = '" + txtUserCode.Text + "'";
			}

			iReturn = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
			oConn.Dispose();

			PsqlConnection oConHL = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConHL.Open();
			iReturn = Liquid.Classes.Connect.getDataCommand(sSqlHL, oConHL).ExecuteNonQuery();
			oConHL.Dispose();

			cmdSave.Enabled = false;
		}

		private string getNextUserCode()
		{
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
			oConn.Open();
			string sSql = "select max(Code) userCode from SOLUS";

			string sMaxUserCode = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();

			int iUserCode = 0;
			if (sMaxUserCode != "")
			{
				try
				{

					iUserCode = Convert.ToInt32(sMaxUserCode);
				}
				catch
				{
					iUserCode = 0;
				}
			}
			
			iUserCode = iUserCode + 1;
			sMaxUserCode = iUserCode.ToString("00000");
			oConn.Dispose();
			return sMaxUserCode;
			
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			txtUserCode.Text = "New";
			txtDescription.Text = "";
			txtPassword.Text = "";
			txtUserName.Text = "";
			selUserType.Text = "";
			txtShortName.Text = "";
			txtTel.Text = "";
			iUpdate = 0;
			sOldUserName = "";
			chkCancelReturn.Checked = false;
			chkCloseOrder.Checked = false;
			chkCreditInvoice.Checked = false;
			cmdSave.Enabled = false;
		}

		private void cmdSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Liquid.Finder.UserZoom frmUserZoom = new Liquid.Finder.UserZoom())
			{
				if (frmUserZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmUserZoom.sUserName != "")
					{                        
						txtUserCode.Text = frmUserZoom.sUserCode;
						txtDescription.Text = frmUserZoom.sDescription;
						txtUserName.Text = frmUserZoom.sUserName;
						txtPassword.Text = frmUserZoom.sPassword;
						txtShortName.Text = frmUserZoom.sShortName;
						selUserType.Text = "";
						selUserType.Text = frmUserZoom.sUserType;
						txtTel.Text = frmUserZoom.sTelephoneNumber;
						iUpdate = 1;
						sOldUserName = frmUserZoom.sUserName;
						if (frmUserZoom.sCreditInvoice == "1")
						{
							chkCreditInvoice.Checked = true;
						}
						else
						{
							chkCreditInvoice.Checked = false;
						}
						if (frmUserZoom.sRetrunItemCancel == "1")
							chkCancelReturn.Checked = true;
						else
							chkCancelReturn.Checked = false;

						if (frmUserZoom.sLockOrder == "1")
							chkLockOrder.Checked = true;
						else
							chkLockOrder.Checked = false;
						if (frmUserZoom.sCloseSalesOrder == "1")
							chkCloseOrder.Checked = true;
						else
							chkCloseOrder.Checked = false;
						if (frmUserZoom.sReturnItem == "1")
							chkReturnItems.Checked = true; 
						else
							chkReturnItems.Checked = false; 

					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void Users_Load(object sender, EventArgs e)
		{
			aActiveComponentsValidate = ((Main)this.MdiParent).aActiveComponents;

			selUserType.Items.Add("Front Desk");
			selUserType.Items.Add("Administrator");

			if (aActiveComponentsValidate[2] == "1")
			{
				selUserType.Items.Add("Asset Maintenance");
			}
			txtUserCode.Text = "New";
		}

		private void txtDescription_TextChanged(object sender, EventArgs e)
		{
			cmdSave.Enabled = true;
		}
	}
}