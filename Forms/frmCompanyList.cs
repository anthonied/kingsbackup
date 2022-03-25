using System;
using System.Data;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Forms
{
    public partial class frmCompanyList : Form
    {       
        public frmCompanyList()
        {
            InitializeComponent();
        }

        private void frmCompanyList_Load(object sender, EventArgs e)
        {
          
           string sXmlpath = Application.StartupPath + "/CompanyList.xml"; 
           DataSet dsCompanyList = new DataSet();

           dsCompanyList.ReadXml(sXmlpath,XmlReadMode.Auto);
            
           dgCompanyList.AutoGenerateColumns = false;
           dgCompanyList.DataSource = dsCompanyList.Tables[0];                       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadCompany_Click(object sender, EventArgs e)
        {
            //Set Global Vars
            setCompanyDetails();
        }

        private void setCompanyDetails()
        {
           
            Global.sActiveCompanyName = dgCompanyList.SelectedRows[0].Cells["CompanyName"].Value.ToString();
            Global.sDataPath = dgCompanyList.SelectedRows[0].Cells["DataPath"].Value.ToString();
            Global.sApplicationPath = dgCompanyList.SelectedRows[0].Cells["ApplicationPath"].Value.ToString();
            Global.sPastelConn = dgCompanyList.SelectedRows[0].Cells["PastelConn"].Value.ToString();
            Global.sSolPMSConn = dgCompanyList.SelectedRows[0].Cells["SOLPMSConn"].Value.ToString();
           
            //Do DB Update if Needed                        
            DBAutoUpdater();
         
            this.Visible = false;
            Cursor = Cursors.WaitCursor;
            Login frmLogin = new Login();
           
            frmLogin.Show();
        }

        private void DBAutoUpdater()
        {
            
            DBUpdater.FetchVersionDetails();
         
            if (DBUpdater.iLatestVersion > DBUpdater.iCurrVersion)
                DBUpdater.UpdateToLatest();
           
        }

        private void dgCompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                setCompanyDetails();
            }
        }
    }
}