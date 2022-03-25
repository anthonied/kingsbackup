using System.Windows.Forms;

namespace Liquid.Forms
{
    public partial class NoteModal : Form
    {
        public string NoteName { get; set; }
        public string Note { get; set; }

        public NoteModal()
        {
            InitializeComponent();
        }

        private void NoteModal_Load(object sender, System.EventArgs e)
        {
            txtName.Focus();
        }

        private void cmdAdd_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please supply a name for the note", "No Name", MessageBoxButtons.OK);
                return;
            }

            NoteName = txtName.Text;
            Note = txtNote.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}