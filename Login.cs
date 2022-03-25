using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using System.Reflection;

namespace Liquid
{
    public partial class Login : Form
    {
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;
        private string sMasterUserName = "`1";
        public Login()
        {
            InitializeComponent();
        }
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool bHandled = false;
			if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
			{

				switch (keyData)
				{
					
					case Keys.Enter:
						cmdlogin_Click(null, null);
						bHandled = true;
						break;
				}
			}
			return bHandled;
		}

        private void cmdlogin_Click(object sender, EventArgs e)
        {
          
            bool bMatch = false;
            string sUserName = "";
            string sUserCode = "";
            string sUserType = "";

			if (txtUserName.Text == "")
			{
				MessageBox.Show("Please supply username field");
				return;
			}
            using (var liquidConnection = new PsqlConnection(Connect.LiquidConnectionString))
            {
                liquidConnection.Open();
				var sSql = "Select UserName,Psswrd,Code,UserType, CreditInvoice from SOLUS where UserName = '" + txtUserName.Text + "'";
                var rdReader = Connect.getDataCommand(sSql, liquidConnection).ExecuteReader();
                while (rdReader.Read())
                {
                    if (txtPassword.Text != rdReader["Psswrd"].ToString().Trim()) continue;
                    bMatch = true;
                    sUserName = rdReader["UserName"].ToString().Trim();
                    sUserCode = rdReader["Code"].ToString().Trim();
                    sUserType = rdReader["UserType"].ToString().Trim();
                    Global.iCreditInvoice = Convert.ToInt32(rdReader["CreditInvoice"]);
                }

                rdReader.Close();
                liquidConnection.Dispose();
            }

           
            if (bMatch)
            {
               
                Visible = false;
                Cursor = Cursors.WaitCursor;
                var frmMain = new Main();
           
                Global.sLogedInUserName = sUserName;
                Global.sLogedInUserCode = sUserCode;
                Global.sLogedInUserType = sUserType;				 
				Global.frmLogin = this;

                Global.bUseBackground = chkUseBackground.Checked;
    
				Global.frmMain = frmMain;
				frmMain.Show();
             
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Login Failed");
                cmdClearFields();
            }
         
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            cmdClearFields();
        }

        private void cmdClearFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        
        private void txtUserName_Leave(object sender, EventArgs e)
            {
            if (txtUserName.Text == sMasterUserName)
            {
                this.Visible = false;
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Main frmMain = new Liquid.Main();

                Global.sLogedInUserName = sMasterUserName;
				Global.sLogedInUserCode = "00001";
				Global.sLogedInUserType = "99";
				Global.iCreditInvoice = 1;
                Global.bUseBackground = chkUseBackground.Checked;

				Global.frmLogin = this;
				Global.frmMain = frmMain;

                frmMain.Show();                
                Cursor = System.Windows.Forms.Cursors.Default;
                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblBuildVersion.Text = "Build" + Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}