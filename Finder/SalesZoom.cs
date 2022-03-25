using System;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Finder
{
	public partial class SalesZoom : Form
	{
		public SalesZoom()
		{
			InitializeComponent();
		}
		
		public string sResult = "";
		public string sName = "";
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();

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

		private void SalesZoom_Load(object sender, EventArgs e)
		{
			txtSalesCode.CharacterCasing = CharacterCasing.Upper;
			loadSalesGrid();
		}

		private void loadSalesGrid()
		{
			dgSalesPersons.Rows.Clear();
			string[] aKeyValues = new string[5];
			aKeyValues[0] = txtSalesCode.Text;
			string[] aRecord = clsSDK.Read_Record("ACCSALE", 7, 0, aKeyValues,Global.sDataPath).Split("|".ToCharArray());
			string sResult = aRecord[0];
			if (sResult == "0")
			{
				addDataGridLine(aRecord);
			}

			while (sResult != "9")
			{
				aRecord = clsSDK.GetNext("ACCSALE", 0,Global.sDataPath).Split("|".ToCharArray());
				sResult = aRecord[0];
				sName = aRecord[1];
				if (sResult == "0")
				{
					addDataGridLine(aRecord);
				}
			}
			dgSalesPersons.Focus();
		}

		private void addDataGridLine(string [] aRecord)
		{
			int n = dgSalesPersons.Rows.Add();

			dgSalesPersons.Rows[n].Cells[0].Value = aRecord[1];
			dgSalesPersons.Rows[n].Cells[1].Value = aRecord[2];			
		}


		private void dgSalesPersons_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sResult = dgSalesPersons.SelectedRows[0].Cells[0].Value.ToString();
			sName = dgSalesPersons.SelectedRows[0].Cells[1].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dgSalesPersons_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				sResult = dgSalesPersons.SelectedRows[0].Cells[0].Value.ToString();
				sName = dgSalesPersons.SelectedRows[0].Cells[1].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				if (e.KeyValue > 40)
				{
					e.SuppressKeyPress = true;
					txtSalesCode.Text += char.ConvertFromUtf32(e.KeyValue);
					txtSalesCode.Focus();
					txtSalesCode.SelectionStart = txtSalesCode.Text.Length;
					txtSalesCode.SelectionLength = 0;
				}

			}
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadSalesGrid();
		}

	}
}