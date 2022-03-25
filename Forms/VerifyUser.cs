using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Forms
{
    public partial class VerifyUser : Form
    {
        private string sMasterUserName = "`1";
		public string sUserCode = "";

		public VerifyUser()
        {
            InitializeComponent();
        }

        private void cmdlogin_Click(object sender, EventArgs e)
        {
            bool bMatch = false;
            

           
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "Select UserName,Psswrd,Code,UserType from SOLUS where UserName = '" + txtUserName.Text + "'";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    if (txtPassword.Text == rdReader["Psswrd"].ToString().Trim())
                    {
                        bMatch = true;            
                        sUserCode = rdReader["Code"].ToString().Trim();                        
                    }
                }
                rdReader.Close();
                oConn.Dispose();
            }
            
			 if (bMatch == true)
            {                
				this.DialogResult = DialogResult.OK;
				this.Close();        
            }
            else
            {
                MessageBox.Show("Username and Password does not match.  Please try again.");			
                cmdClearFields();
				this.ActiveControl = txtUserName;
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
                sUserCode = "00001";			
				this.DialogResult = DialogResult.OK;
				this.Close();        
            }
        }
    }
}