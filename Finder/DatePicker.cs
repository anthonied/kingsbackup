using System.Windows.Forms;	

namespace Liquid.Finder
{
	public partial class DatePicker : Form
	{
		public string sDate = "";
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

		public DatePicker()
		{
			InitializeComponent();
		}
				
		private void DatePicker_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				sDate = dtDate.SelectionRange.Start.ToString("dd/MM/yyyy");
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}