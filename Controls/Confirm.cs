using System.Windows.Forms;

namespace Liquid.Controls
{
    public partial class Confirm : Form
    {
        public Confirm(string questionText)
        {
            InitializeComponent();
            lblQuestion.Text = questionText;
        }

        private void cmdYes_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdNo_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Confirm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
