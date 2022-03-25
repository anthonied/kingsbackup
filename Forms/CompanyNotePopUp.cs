using System;
using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class CompanyNotePopUp : Form
    {
        
        public CompanyNotePopUp()
        {
            InitializeComponent();
        }
        public bool bContinueClick = false;

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CompanyNote_Load(object sender, EventArgs e)
        {
            Liquid.Finder.CustomerZoom frmCustomerZoom = new Liquid.Finder.CustomerZoom();
            frmCustomerZoom.txtAccountCode.Text = "";
        }
    }
}