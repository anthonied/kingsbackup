using System;
using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class Error : Form
    {
        public Error(string message)
        {
            InitializeComponent();
            lblMsg.Text = message;
        }

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
