using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class OpenSalesOrderZoom : Form
	{

		public string sResult = "";
		public string sCustomer = "";
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
		public DialogResult ShowDialog(string sSelectedCustomer)
		{
			sCustomer = sSelectedCustomer;
			lblCustomerValue.Text = sSelectedCustomer;
			return this.ShowDialog();
		}
		public OpenSalesOrderZoom()
		{
			InitializeComponent();
		}

		private void OpenSalesOrderZoom_Load(object sender, EventArgs e)
		{
			txtSalesNumber.CharacterCasing = CharacterCasing.Upper;
			loadSalesOrderGrid();
		}

		private void loadSalesOrderGrid()
		{
			dgSalesOrder.Rows.Clear();		
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
			oConn.Open();
			string sSql = "SELECT DocNumber, CustomerCode, DocDate from SOLHH";
			sSql += " where DocType = 2 and Status = 0 and (CustomerCode = '" + sCustomer + "' or '" + sCustomer + "' = '')" ;
			sSql += " order by DocNumber";

			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
			while (rdReader.Read())
			{
				int n = dgSalesOrder.Rows.Add();
				dgSalesOrder.Rows[n].Cells[0].Value = rdReader["DocNumber"].ToString();
				dgSalesOrder.Rows[n].Cells[1].Value = rdReader["CustomerCode"].ToString();
				dgSalesOrder.Rows[n].Cells[2].Value = rdReader["DocDate"].ToString();
			}
			rdReader.Close();
			oConn.Dispose();
			dgSalesOrder.Focus();
		}

		private void dgSalesOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sResult = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void txtSalesNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadSalesOrderGrid();
			}
		}

		private void cmdFilter_Click(object sender, EventArgs e)
		{
			loadSalesOrderGrid();
		}

		private void dgSalesOrder_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				sResult = dgSalesOrder.SelectedRows[0].Cells[0].Value.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				if (e.KeyValue > 40)
				{
					e.SuppressKeyPress = true;
					txtSalesNumber.Text += char.ConvertFromUtf32(e.KeyValue);
					txtSalesNumber.Focus();
					txtSalesNumber.SelectionStart = txtSalesNumber.Text.Length;
					txtSalesNumber.SelectionLength = 0;
				}

			}
		}
	}
}