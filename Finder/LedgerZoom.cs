using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class LedgerZoom : Form
	{

		public string sResult = "";
		public string sDescription = "";
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
        
		public LedgerZoom()
		{

			InitializeComponent();
            this.ActiveControl = txtAccountCode;
        }

		private void LedgerZoom_Load(object sender, EventArgs e)
		{
			txtAccountCode.CharacterCasing = CharacterCasing.Upper;
			loadLedgerGrid();
		}

		private void loadLedgerGrid()
		{
			dgLedger.Rows.Clear();			
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConn.Open();
			string sSql = "SELECT AccNumber, AccDesc from LedgerMaster";
			sSql += " where (AccNumber like '%" + txtAccountCode.Text + "%' or '" + txtAccountCode.Text + "' = '')";
            sSql += " And (AccDesc like '%" + txtDescription.Text + "%' or '" + txtDescription.Text + "' = '')";
			sSql += " order by AccNumber";

			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
			while (rdReader.Read())
			{
				int n = dgLedger.Rows.Add();
				dgLedger.Rows[n].Cells[0].Value = rdReader["AccNumber"].ToString();
				dgLedger.Rows[n].Cells[1].Value = rdReader["AccDesc"].ToString();
				
			}
			rdReader.Close();
			oConn.Dispose();			
			
		}

		private void addDataGridLine(string[] aRecord)
		{
			int n = dgLedger.Rows.Add();

			dgLedger.Rows[n].Cells[0].Value = aRecord[2];
			dgLedger.Rows[n].Cells[1].Value = aRecord[3];
			
		}

		private void dgLedger_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sResult = dgLedger.SelectedRows[0].Cells[0].Value.ToString();
			sDescription = dgLedger.SelectedRows[0].Cells[1].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void txtAccountCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadLedgerGrid();
			}
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgLedger.Focus();
            }
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadLedgerGrid();
		}

		private void dgLedger_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				sResult = dgLedger.SelectedRows[0].Cells[0].Value.ToString();
				sDescription = dgLedger.SelectedRows[0].Cells[1].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			
		}

        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            loadLedgerGrid();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            loadLedgerGrid();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgLedger.Focus();
            }
        }

	}
}