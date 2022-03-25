using System;
using System.Drawing;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Controls
{
	public partial class QouteLine : UserControl
	{
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
		public bool bNextLine;
		public bool bFocusOnNextLine = true;
		public bool bSaved = false;
		public int iLineIndex;
		public string sPastelLineLink = "";
		public string sParentLinkNum = "";        
		public bool bDoCalculation = true;
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;
		private CodeProject.SystemHotkey.SystemHotkey deleteHotKey;
		public bool bAllowDuplicateLines = false;
		public decimal dMaxMultiplierValue = 0;
		public string sLineType = "";
		private string sLineCalcRuleID;
		private string sLineCalcUnit;
		public decimal dNetMassPerUnit = 0;
		public decimal dUnitNetMass = 0;
		public decimal dQtyOnHand = 0;
		public decimal dScaleQty = 0;
		public bool bUseScale = false;
		public decimal dOriginalUnitPrice = 0;
		public string sCategory;

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

		public QouteLine()
		{
			InitializeComponent();
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnHandlePaint);
			Graphics g = this.CreateGraphics();
			
			deleteHotKey = new CodeProject.SystemHotkey.SystemHotkey();
			//deleteHotKey.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			//deleteHotKey.Pressed += new System.EventHandler(this.RemoveLine);
		}

		public void removeLine(object sender, EventArgs e)
		{
			//if (this.txtCode.Text != "")
			//{
			//    if (((Documents.Salesorder)(this.Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper() == "*NEW*")//only remove if it is a new document.
			//    {

			//        SalesLineForm slDeletedLineForm = (SalesLineForm)this;
			//        ((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).deleteSalesLine(slDeletedLineForm, false);

			//    }
			//}
		}

		protected void OnHandlePaint(object sender, PaintEventArgs args)
		{
			Graphics g1 = args.Graphics;
			Pen pen = new Pen(Color.FromArgb(100, 100, 100), 2);

			g1.DrawLine(pen, 111, 0, 111, 20);
			//g1.DrawLine(pen, 361, 0, 361, 20);
			//g1.DrawLine(pen, 441, 0, 441, 20);
			//g1.DrawLine(pen, 515, 0,515, 20);
			g1.DrawLine(pen, 569, 0, 569, 20);
			g1.DrawLine(pen, 634, 0, 634, 20);
			//g1.DrawLine(pen, 666, 0, 666, 20);
			g1.DrawLine(pen, 714, 0, 714, 20);
			g1.DrawLine(pen, 794, 0, 794   , 20);
			g1.DrawLine(pen, 874, 0, 874, 20);
		}

		private void cmdSearchStore_Click(object sender, EventArgs e)
		{
		//    Cursor = System.Windows.Forms.Cursors.WaitCursor;
		//    using (Finder.StoreZoom frmStore = new Liquid.Finder.StoreZoom())
		//    {
		//        if (frmStore.ShowDialog() == DialogResult.OK)
		//        {
		//            if (frmStore.sResult != "")
		//            {
		//                txtStore.Text = frmStore.sResult;
		//                txtStore.Focus();
		//                txtStore.SelectionStart = 0;
		//                txtStore.SelectionLength = txtStore.Text.Length;
		//            }
		//        }				
		//    }
		//    Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void cmdCodeSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.Inventory frmInventory = new Liquid.Finder.Inventory())
			{
				//Sending "None" to inventory ShowDialog to identify that no workshop action should be taken 
				if (frmInventory.ShowDialog("","","") == DialogResult.OK)
				{
					if (frmInventory.sResult != "")
					{
						//check if this item has been selected...
						//if (((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).CheckDuplicateSalesLine(frmInventory.sResult))											
						//{
						//    MessageBox.Show("No duplicate items are allowed in a sales order. Please select another inventory item.", "Duplicates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						//}
						//else
						//{							
								txtCode.Text = frmInventory.sResult.Trim();
								QouteLine qlQoute = this;
								QouteLine qlLastControl = this;

									bool bValid = Populate_Inventory_Fields(ref qlQoute,true);
									txtCode.Focus();
									txtCode.SelectionStart = 0;
									txtCode.SelectionLength = txtCode.Text.Length;
									((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).addTotals();
						
								
						//}
					}
				}
			}
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void CalcScale()
		{
			
		}
		private bool Populate_Inventory_Fields(ref QouteLine qlQouteLine, bool bFocusDescription)
		{
			string sInventoryGroup = "";
			bool bExist = false;
			if (qlQouteLine.txtCode.Text == "'")
			{
				//qlQouteLine.txtMultiplier.ReadOnly = true;
				qlQouteLine.txtDescription.ReadOnly = false;
				qlQouteLine.txtDiscount.ReadOnly = true;                
				qlQouteLine.txtExcPrice.ReadOnly = true;               
				qlQouteLine.txtLastInvoiceDate.Text = "";
				qlQouteLine.txtNet.ReadOnly = true;               
				qlQouteLine.txtQuantity.ReadOnly = true;				
				qlQouteLine.txtUnit.ReadOnly = true;              
				qlQouteLine.txtDescription.Focus();
				qlQouteLine.bDoCalculation = false;
				bAllowDuplicateLines = false;
				return true;
			}
			else
			{
				//qlQouteLine.txtMultiplier.ReadOnly = false;
				qlQouteLine.txtDiscount.ReadOnly = false;
				qlQouteLine.txtExcPrice.ReadOnly = false;
				qlQouteLine.txtQuantity.ReadOnly = false;
				qlQouteLine.txtDescription.ReadOnly = false;

				qlQouteLine.bDoCalculation = true;
				using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
				{
					oConn.Open();
					string sSql = "SELECT distinct  Inventory.*, MultiStoreTrn.SellExcl01 from Inventory left join MultiStoreTrn on Inventory.ItemCode = MultiStoreTrn.ItemCode";					
					sSql += " where Inventory.ItemCode = '" + qlQouteLine.txtCode.Text.Trim() + "'";
					sSql += " AND MultiStoreTrn.StoreCode <> ''";

					PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
					while (rdReader.Read())
					{
						
						if (!bNextLine)
						{
							bNextLine = true;
							QouteLine qlNewline = new QouteLine();
							((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).AddQouteLine(qlNewline,false);

						}
						qlQouteLine.txtDescription.Text = rdReader["Description"].ToString().Trim();

						try
						{
							qlQouteLine.txtExcPrice.Text = Convert.ToDecimal(rdReader["SellExcl01"].ToString()).ToString("N2");
							dOriginalUnitPrice = Convert.ToDecimal(rdReader["SellExcl01"].ToString());
						}
						catch
						{
							MessageBox.Show("Error calculating Excluding Price of item.");
							qlQouteLine.txtExcPrice.Text = "0.00";
						}
						qlQouteLine.txtTaxType.Text = rdReader["SalesTaxType"].ToString().Trim();
						qlQouteLine.txtDiscountType.Text = rdReader["DiscountType"].ToString().Trim();

						qlQouteLine.sLineType = Functions.getLineInventoryType(qlQouteLine.txtCode.Text.Trim());

						 
						if (qlQouteLine.txtTaxType.Text == "0" || qlQouteLine.txtTaxType.Text == "2")
						{
							qlQouteLine.txtNet.BackColor = Color.Yellow;
						}
						else
						{
							qlQouteLine.txtNet.BackColor = Color.White;
						}

						if (rdReader["DiscountType"].ToString() == "0" || rdReader["DiscountType"].ToString() == "1")//AJD 20-08-2009
						{
							qlQouteLine.txtDiscount.ReadOnly = true;
						}
						qlQouteLine.txtUnit.Text = rdReader["UnitSize"].ToString();
						qlQouteLine.txtDescription.Focus();
						bExist = true;
					   
					}//end while
					rdReader.Close();
					oConn.Dispose();
					if (!bExist)
					{

						MessageBox.Show("Code does not exist.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						qlQouteLine.txtDescription.ReadOnly = true;
						return false;
					}
					else
					{
						
					}
					return true;
				}
			}
		   
		}

		private bool GetCalculationRule(string sUnit)
		{
			bool bCalcRuleExists = false;
			//sLineCalcRuleID = "";
			//sLineCalcUnit = "";

			//using (PsqlConnection oConnSol = new PsqlConnection(Connect.sConnStr))
			//{
			//    oConnSol.Open();
			//    int iReturn = 0;
			//    string sSqlSol = "Select * from SOLRM where sRuleName = '" + sUnit + "'";

			//    PsqlDataReader rdReaderSol = Liquid.Classes.Connect.getDataCommand(sSqlSol, oConnSol).ExecuteReader();
			//    while (rdReaderSol.Read())
			//    {

			//        sLineCalcRuleID = rdReaderSol["PKiRuleID"].ToString();
			//        sLineCalcUnit = rdReaderSol["SRuleUnit"].ToString();
			//        iReturn++;
			//    }
			//    rdReaderSol.Close();
			   
			//    if (iReturn > 0)
			//        bCalcRuleExists = true;
			//    oConnSol.Dispose();
			//}

			return bCalcRuleExists;
		}


		private void txtQuantity_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType().Name == "TextBox")
			{
                //if (((TextBox)sender).Text == ".")
                //{
                //    ((TextBox)sender).Text = "0";
                //}
			}
			decimal dExPrice = 0;
			if (txtExcPrice.Text != "")
			{
				dExPrice = Convert.ToDecimal(txtExcPrice.Text.Replace(",", ""));
			}
			if (((TextBox)sender).Text != "" && bDoCalculation)
			{
				decimal dTotalExDiscount = Convert.ToDecimal(txtQuantity.Text.Replace(",", "")) * dExPrice;
				txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDecimal(txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");
				((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).addTotals();
			}
			
			
		   
		}

		
		private void numeric_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (sender.GetType().Name == "TextBox")
			{
                //if (((TextBox)sender).Text.IndexOf(".") > 0 && e.KeyChar == '.')
                //{
                //    e.Handled = true;
                //    return;
                //}
			}
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')
            {
                e.Handled = true;
            }
		}

		private void txtQuantity_Leave(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text != "")
			{
				((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
			}
			else
			{
				txtQuantity.Text = "0.00";
			}
			/*if (dtDelivery.Visible && ((TextBox)sender).Text != "")
			{
				dtReturnDate.Value = dtDelivery.Value.AddDays((int)Convert.ToDouble(txtQuantity.Text)-1);
			}*/
			
		}

		private void nextControl(object sender, KeyEventArgs e)
		{
            
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    manageFrontEnd();
                }
            
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
					if (txtCode.Text == "")
					{
						cmdCodeSearch_Click(null, null);
					}
					else if (!cmdCodeSearch.Visible)
					{
						//dtDelivery.Focus();
					}
                    else if (((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).txtNumber.Text == "*NEW*")
                    {
                        QouteLine qlSales = this;
                        Populate_Inventory_Fields(ref qlSales, true);
                    }
                    else
                    {
                        txtDescription.Focus();
                    }
					break;
				case "txtDescription":
					if (!txtQuantity.ReadOnly)
					{
						txtQuantity.Focus();
					}
					else
					{
						txtQuantity.Focus();
					}
					break;
			   
				
				case "txtQuantity":
					if (txtQuantity.Text != "")
					{
						txtQuantity.Text = Convert.ToDecimal(txtQuantity.Text.Replace(",", "")).ToString("N2");
					}
					if (!txtDiscount.ReadOnly)
					{
						txtDiscount.Focus();
					}
					else
					{
						txtExcPrice.Focus();
					}

					break;
				case "txtDiscount":
					if (txtExcPrice.Text != "")
					{
						txtExcPrice.Text = Convert.ToDecimal(txtExcPrice.Text.Replace(",", "")).ToString("N2");
					}
					txtExcPrice.Focus();
					break;
				case "txtExcPrice":
					if (bFocusOnNextLine)
					{
						((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).focusNextLine(iLineIndex + 1);
					}
					break;
			}
		}
		

		public void makeLineReadOnly()
		{
			bSaved = true;
			cmdCodeSearch.Visible = false;
			//cmdSearchStore.Visible = false;
			//txtStore.ReadOnly = true;			
			txtCode.ReadOnly = true;
			txtCode.BackColor = Color.White;
			if (txtStatus.Text != "1")
			{
				txtDescription.ReadOnly = false;
			}
			else
			{
				txtDescription.ReadOnly = true;
			}
			txtDescription.BackColor = Color.White;
			
			
		//	dtDelivery.BackColor = Color.White;
			
//			dtReturnDate.BackColor = Color.White;
			txtQuantity.ReadOnly = true;
//			txtQuantity.BackColor = Color.White;
			txtDiscount.ReadOnly = true;
//			txtDiscount.BackColor = Color.White;
			txtExcPrice.ReadOnly = true;
//			txtExcPrice.BackColor = Color.White;
			//txtMultiplier.ReadOnly = true;
			txtNet.ReadOnly = true;
			
		}

		public void openLineForEdit()
		{                   
		  
		}

		public void clearLine()
		{
			txtCode.Text = "";
			txtDescription.Text = "";
			txtUnit.Text = "";
			txtQuantity.Text = "1.00";
			txtDiscount.Text = "0";
			txtExcPrice.Text = "0.00";
			txtNet.Text = "0.00";
		 //LL Phalaborwa
	  txtNet.BackColor = Color.White;
	  txtTaxType.Text = "";
	  //LL
		}

		private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
		{			
			
		}

	

		private void picInfo_Click(object sender, EventArgs e)
		{
			Liquid.Documents.SalesLineInfo frmInfo = new Liquid.Documents.SalesLineInfo();
			frmInfo.ShowDialog(this.txtCode.Text, this.txtDescription.Text, this.txtLastInvoiceDate.Text);
		}

		public void dtDelivery_ValueChanged(object sender, EventArgs e)
		{
					}

	   
		//LL Phalaborwa
		private void SalesLine_Load(object sender, EventArgs e)
		{
				txtDescription.CharacterCasing = CharacterCasing.Upper;
		txtCode.CharacterCasing = CharacterCasing.Upper;
		}

		private void picDelete_Click(object sender, EventArgs e)
		{
			string sSql = "";
			int iRet = 0;
			if (this.txtCode.Text != "")
			{
				bool bDeleteLastLine = false;								
				string sQoute = ((Forms.Qoutes.Qoute)(this.Parent.Parent.Parent.Parent)).txtNumber.Text.ToUpper().Trim();

				if (sQoute != "*NEW*" && sQoute != "")
				{
					//remove actual line from sales order...
					if (MessageBox.Show("This will permanently remove this item from this order. Are you sure?", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						bDeleteLastLine = true;
						QouteLine qlNewDeletedLine = (QouteLine)this;
						((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).deleteSalesLine(qlNewDeletedLine, bDeleteLastLine);
						return;																						  
					}                     
				}
				else
				{
					bDoCalculation = false;
					QouteLine qlNewDeletedLine = (QouteLine)this;
					((Forms.Qoutes.Qoute)(Parent.Parent.Parent.Parent)).deleteSalesLine(qlNewDeletedLine, bDeleteLastLine);
					return;
				}			
				//bDoCalculation = false;
				//SalesLineForm slDeletedLineForm = (SalesLineForm)this;
				//((Documents.Salesorder)(Parent.Parent.Parent.Parent)).deleteSalesLine(slDeletedLineForm, bDeleteLastLine);
			}
		}
		//LL Phalaborwa void
	private void txtDiscount_Leave(object sender, EventArgs e)
	{
		if (((TextBox)sender).Text != "")
		{
			((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
		}
		else
		{
			txtDiscount.Text = "0.00";
		}
		
	}
	//LL Phalaborwa void
	private void txtExcPrice_Leave(object sender, EventArgs e)
	{
		if (((TextBox)sender).Text != "")
		{
			((TextBox)sender).Text = Convert.ToDouble(((TextBox)sender).Text.Replace(",", "")).ToString("N2");
		}
		else
		{
			txtExcPrice.Text = "0.00";
		}
	}

		private void picReturned_Click(object sender, EventArgs e)
		{
		 
		}

		private void picReturned_DoubleClick(object sender, EventArgs e)
		{
			
		}

		private void chkReturn_CheckedChanged(object sender, EventArgs e)
		{
		   
		}

		private void cmdFromulaFinder_Click(object sender, EventArgs e)
		{
		}

		private void txtUnitFormula_TextChanged(object sender, EventArgs e)
		{

		}

		private void picScaleInfo_Click(object sender, EventArgs e)
		{
			using (Liquid.Forms.InventoryBreakdown frmBreakdown = new Liquid.Forms.InventoryBreakdown())
			{
				frmBreakdown.lblItemcode.Text = txtCode.Text.Trim() + " - "  + txtDescription.Text.Trim();
				frmBreakdown.lblUnit.Text = txtUnit.Text;
				frmBreakdown.dNetMassPerUnit = dNetMassPerUnit;
				frmBreakdown.dUnitNetMass = dUnitNetMass;
				frmBreakdown.dUnitPrice = dOriginalUnitPrice;
				frmBreakdown.dQtyOnHand = dQtyOnHand;
				frmBreakdown.dQtySold = dScaleQty;

				frmBreakdown.ShowDialog();

			}
		}    
	}
}
