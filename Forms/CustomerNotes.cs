using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Forms
{
    public partial class CustomerNotes : Form
    {
        public CustomerNotes()
        {
            InitializeComponent();
        }

        private void CustomerNotes_Load(object sender, EventArgs e)
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                string sSql = "SELECT Note FROM SOLCN where IDNumber = '" + txtID.Text + "' AND CustomerCode = '" + txtAcountCode.Text + "'";

                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    txtNote.Text = rdReader["Note"].ToString();
                }

            }


        }
        
        private void cmdSaveNote_Click(object sender, EventArgs e)
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {                               
                oConn.Open();
                string sSql = "delete from SOLCN where IDNumber = '" + txtID.Text + "' And CustomerCode = '" + txtAcountCode.Text + "'";
                int iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                sSql = "Insert into SOLCN (IDNumber,CustomerCode,Note) VALUES ";
                sSql += "(";
                sSql += "'" + txtID.Text + "'";
                sSql += ",'" + txtAcountCode.Text + "'";
                sSql += ",'" + txtNote.Text + "'";
                sSql += ")";
                iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
            
                oConn.Dispose();
            }
            this.Close();
        }
        private void cmdDeleteNote_Click(object sender, EventArgs e)
        {
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();

                if (MessageBox.Show("This will delete Customer Note. Do you want to continue? ","Delete Customer Note",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
                {
                string sSql = "delete from SOLCN where IDNumber = '" + txtID.Text + "' And CustomerCode = '" + txtAcountCode.Text + "'";
                int iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                oConn.Dispose();
                this.Close();
                }
                
            }
        }

        
    }
}