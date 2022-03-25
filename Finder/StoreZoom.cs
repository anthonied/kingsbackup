using System;
using System.Linq;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Finder
{
	public partial class StoreZoom : Form
	{
		public string sResult = "";
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

		public StoreZoom()
		{
			InitializeComponent();
		}

		private void StoreZoom_Load(object sender, EventArgs e)
		{
			txtCode.CharacterCasing = CharacterCasing.Upper;
			loadStoreGrid();
		}

		private void loadStoreGrid()
		{
			dgStores.Rows.Clear();
			string[] aKeyValues = new string[5];
			aKeyValues[0] = txtCode.Text;
			string[] aRecord = clsSDK.Read_Record("ACCSTORE", 42, 0, aKeyValues,Global.sDataPath).Split("|".ToCharArray());
			string sResult = aRecord[0];
			if (sResult == "0")
			{
				addDataGridLine(aRecord);
			}

			while (sResult != "9")
			{
				aRecord = clsSDK.GetNext("ACCSTORE", 0,Global.sDataPath).Split("|".ToCharArray());
				sResult = aRecord[0];
				if (sResult == "0")
				{
					addDataGridLine(aRecord);
				}
			}
			dgStores.Focus();
		}
	
		private void addDataGridLine(string[] aRecord)
		{
			int n = dgStores.Rows.Add();

			dgStores.Rows[n].Cells[0].Value = aRecord[1];
			dgStores.Rows[n].Cells[1].Value = aRecord[2];
			dgStores.Rows[n].Cells[2].Value = aRecord[16];
			dgStores.Rows[n].Cells[3].Value = aRecord[17];
		}

		private void dgStores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sResult = dgStores.SelectedRows[0].Cells[0].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dgStores_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				sResult = dgStores.SelectedRows[0].Cells[0].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				if (e.KeyValue > 40)
				{
					e.SuppressKeyPress = true;
					txtCode.Text += char.ConvertFromUtf32(e.KeyValue);
					txtCode.Focus();
					txtCode.SelectionStart = txtCode.Text.Length;
					txtCode.SelectionLength = 0;
				}

			}
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadStoreGrid();
		}

	}
}