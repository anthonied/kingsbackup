using System;
using System.Drawing;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Controls
{
	public partial class CreditLine : UserControl
	{
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
		public bool bNextLine;
		public int iLineIndex;
		public SalesLineForm SlParentLineForm;
		public bool bDoCalculation = true;
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool bHandled = false;
			if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
			{
				switch (keyData)
				{
					case Keys.Tab:
						manageFrontEnd();
						bHandled = true;
						break;
					case Keys.Enter:
						manageFrontEnd();
						bHandled = true;
						break;
				}
			}
			return bHandled; //handled
		}

		private void manageFrontEnd()
		{
			Control cntSelectedControl = this.ActiveControl;

			switch (cntSelectedControl.Name)
			{
				case "txtStore":
					txtCode.Focus();
					break;
				case "txtCode":					
					txtQuantity.Focus();
					break;

				case "txtQuantity":				
					txtExcPrice.Focus();
					break;
			
			}
		}

		private void numeric_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')
			{
				e.Handled = true;
			}
		
		}
		public void calcCreditLine()
		{
			if (txtQuantity.Text != "" && txtExcPrice.Text != "")
			{
				double dQuantity = Convert.ToDouble(this.txtQuantity.Text);
				double dExValue = Convert.ToDouble(this.txtExcPrice.Text);
				this.txtNet.Text = (dQuantity * dExValue).ToString("N2");
			}
			else
			{
				this.txtNet.Text = "0.00";
			}
		}

		protected void OnHandlePaint(object sender, PaintEventArgs args)
		{
			Graphics g1 = args.Graphics;
			Pen pen = new Pen(Color.FromArgb(100, 100, 100), 2);

			g1.DrawLine(pen, 56, 0, 56, 20);
			g1.DrawLine(pen, 171, 0, 171, 20);
			g1.DrawLine(pen, 421, 0, 421, 20);
			g1.DrawLine(pen, 501, 0, 501, 20);
			g1.DrawLine(pen, 581, 0, 581, 20);
			g1.DrawLine(pen, 641, 0, 641, 20);
			g1.DrawLine(pen, 726, 0, 726, 20);
			g1.DrawLine(pen, 791, 0, 791, 20);
			g1.DrawLine(pen, 871, 0, 871, 20);
		}

		public CreditLine()
		{
			InitializeComponent();
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnHandlePaint);
			Graphics g = this.CreateGraphics();
			if (Global.iCreditInvoice == 0)
			{
				cmdRemoveCredit.Visible = false;				
			}
		}

	

		private void txtExcPrice_KeyUp(object sender, KeyEventArgs e)
		{
			calcCreditLine();
		}
	}
}
