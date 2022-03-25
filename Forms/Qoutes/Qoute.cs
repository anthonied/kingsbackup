using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using Liquid.Controls;

namespace Liquid.Forms.Qoutes
{
	public partial class Qoute : Form
	{
		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
		public int iLineCounter = 0;
		public int iSalesOrderStatus = 0;
		public int iLockedStatus = 0;
		public Control[] aQoutelines = new Control[0];
		public Control[] aCreditlines = new Control[0];
		public object[,] aUpdate = new object[0, 5];
		private string sCustDelivCode = "";
		public bool bInvoiceMode = false;
		public bool bMonthEndMode = false;
		public bool bPermanentMonthEnd = false;
		private bool bBlockedCustomer = false;
		private CodeProject.SystemHotkey.SystemHotkey saveHotKey;
		private CodeProject.SystemHotkey.SystemHotkey loadOrderHotKey;
		//private CodeProject.SystemHotkey.SystemHotkey depositCashHotKey;
		//private CodeProject.SystemHotkey.SystemHotkey depositCardHotKey;		
		private CodeProject.SystemHotkey.SystemHotkey depositAccountHotKey;
		//private CodeProject.SystemHotkey.SystemHotkey depositEftHotKey;	
		public bool bDoGLTransaction = true;
		public bool bSaved = false;
		public string sDepositDebit = "", sDepositCredit = "";
		public int iLineRowIndex = 0, iInvoiceLineRowIndex = 0, iCreditLineRowIndex;
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;
		public string[] aMainAddressList = new string[10];
		public Color[] aSalesOrderStatusColor = new Color[] { Color.LimeGreen, Color.DarkCyan, Color.Orange, Color.Black };
		private double dLineNett = 0;
		private DateTime dtInvoiceDate = DateTime.Now;
		private ReportClass rptInvoice;
		//Styles
		private DataGridViewCellStyle cssDowntimeRow = new DataGridViewCellStyle();

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool bHandled = false;
			if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
			{
				string sTabName = tcPortal.SelectedTab.Name;
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
			return bHandled;
		}

		public DialogResult ShowDialog(string sQoute)
		{
			loadQoute(sQoute);
			return this.ShowDialog();
		}
		
		
		public Qoute()
		{
			InitializeComponent();
			this.ActiveControl = txtNumber;
			saveHotKey = new CodeProject.SystemHotkey.SystemHotkey();
			loadOrderHotKey = new CodeProject.SystemHotkey.SystemHotkey();			
			depositAccountHotKey = new CodeProject.SystemHotkey.SystemHotkey();
			saveHotKey.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			saveHotKey.Pressed += new System.EventHandler(this.cmdSaveOrder_Click);
			loadOrderHotKey.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
			loadOrderHotKey.Pressed += new System.EventHandler(this.cmdSearchNumber_Click);
			depositAccountHotKey.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			depositAccountHotKey.Pressed += new System.EventHandler(this.deposit_method_click);		
			//Styles
			cssDowntimeRow.BackColor = Color.Beige;		
		}
		public void fillSalesInvoices()
		{
			//selInvoices.Items.Clear();
			//selInvoices.Items.Add("-Select Invoice-");
		   
		}

		private void SalesOrder_Load(object sender, EventArgs e)
		{
			
		}


		void dgReturnItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if ((e.RowIndex == -1))
			{
				// fill gradient background 
				Brush gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(e.CellBounds, Color.Blue, Color.BlueViolet, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(gradientBrush, e.CellBounds);
				gradientBrush.Dispose();

				// paint rest of cell 
				e.Paint(e.CellBounds, DataGridViewPaintParts.Border |
				DataGridViewPaintParts.ContentForeground);
				e.Handled = true;
			}
		}

		public void removeLine(object sender, EventArgs e)
		{
			if (txtNumber.Text.ToUpper() == "*NEW*")//only remove if it is a new document.
			{
				if (this.ActiveControl.Name.StartsWith("slNewLine_"))
				{
					QouteLine qlDeletedLine = (QouteLine)this.ActiveControl;
					deleteSalesLine(qlDeletedLine, false);
				}
			}
		}

		public void deleteSalesLine(QouteLine qlDeletedLine, bool bDeleteLastLine)
		{
			bool bDeleteControl = false;
			for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			{
				QouteLine qlThisline = (((QouteLine)aQoutelines[iLines]));

				if (iLines != aQoutelines.Length - 1 || bDeleteLastLine) //Never delete the last row
				{
					if (qlDeletedLine.Name == qlThisline.Name)
					{
						bDeleteControl = true;
						this.pnlDetails.Controls.Remove(qlDeletedLine);
						if (iLines != aQoutelines.Length - 1)
						{
							(((QouteLine)aQoutelines[iLines + 1])).txtCode.Focus(); // focus on the next line
						}
					}
					if (bDeleteControl && iLines != aQoutelines.Length - 1) //resize the line array
					{
						aQoutelines[iLines] = aQoutelines[iLines + 1]; //Move all the controls one up in the list
						(((QouteLine)aQoutelines[iLines + 1])).Location = new Point((((QouteLine)aQoutelines[iLines + 1])).Location.X, (((QouteLine)aQoutelines[iLines + 1])).Location.Y - 20); // move location of control to new position
						(((QouteLine)aQoutelines[iLines + 1])).iLineIndex--;//sync the lineindex of the control array
					}
				}
				else if (bDeleteLastLine)
				{
					bDeleteControl = true;
					this.pnlDetails.Controls.Remove(qlDeletedLine);
					if (iLines != aQoutelines.Length - 1)
					{
						(((QouteLine)aQoutelines[iLines + 1])).txtCode.Focus(); // focus on the next line
					}
				}
			}
			if (bDeleteControl)//update the line array
			{
				Array.Resize<Control>(ref aQoutelines, aQoutelines.Length - 1);
				iLineRowIndex--;
			}
			addTotals();
			//Check if you want to close the order
			if (aQoutelines.Length == 0)
			{
				if (MessageBox.Show("There are no more lines in this order. Do you want to close this order?", "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Functions.CloseOrder(txtNumber.Text.Trim());
				}
			}
		}


		public void deleteSalesLine(string sDeleteLinkNum, bool bDeleteLastLine)
		{
			bool bDeleteControl = false;
			for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			{
				QouteLine slThisline = (((QouteLine)aQoutelines[iLines]));

				if (iLines != aQoutelines.Length - 1 || bDeleteLastLine) //Never delete the last row
				{
					if (sDeleteLinkNum == slThisline.sPastelLineLink)
					{
						bDeleteControl = true;
						this.pnlDetails.Controls.Remove(slThisline);
						if (iLines != aQoutelines.Length - 1)
						{
							(((QouteLine)aQoutelines[iLines + 1])).txtCode.Focus(); // focus on the next line
						}
					}
					if (bDeleteControl && iLines != aQoutelines.Length - 1) //resize the line array
					{
						aQoutelines[iLines] = aQoutelines[iLines + 1]; //Move all the controls one up in the list
						(((QouteLine)aQoutelines[iLines + 1])).Location = new Point((((QouteLine)aQoutelines[iLines + 1])).Location.X, (((QouteLine)aQoutelines[iLines + 1])).Location.Y - 20); // move location of control to new position
						(((QouteLine)aQoutelines[iLines + 1])).iLineIndex--;//sync the lineindex of the control array
					}
				}
			}
			if (bDeleteControl)//update the line array
			{
				Array.Resize<Control>(ref aQoutelines, aQoutelines.Length - 1);
				iLineRowIndex--;
			}
			addTotals();
			//Check if you want to close the order
			if (aQoutelines.Length == 0)
			{
				if (MessageBox.Show("There are no more lines in this order. Do you want to close this order?", "Close Order?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Functions.CloseOrder(txtNumber.Text.Trim());
					cmdNewOrder_Click(null, null);
				}

			}
		}


		public bool CheckDuplicateSalesLine(string sCompareText)
		{
			for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			{

				QouteLine qlThisline = (((QouteLine)aQoutelines[iLines]));
				if (qlThisline.txtCode.Text.Trim() == sCompareText.Trim())
				{
					if (qlThisline.bAllowDuplicateLines)//AJD 12-09-2009
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
			return false;
		}

		public void InsertQouteLine(int iLineIndex, QouteLine qlNewLine)
		{

			//for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			//{
			//    QouteLine qlThisline = (((QouteLine)aQoutelines[iLines]));


			//    if (qlThisline.iLineIndex == iLineIndex)//start line
			//    {
			//        Array.Resize<Control>(ref aQoutelines, aQoutelines.Length + 1);//Add new row
			//        iLineRowIndex++;
			//        for (int iShiftLines = aQoutelines.Length - 1; iShiftLines > iLines + 1; iShiftLines--)
			//        {
			//            aQoutelines[iShiftLines] = aQoutelines[iShiftLines - 1];
			//            (((QouteLine)aQoutelines[iShiftLines])).Location = new Point((((QouteLine)aQoutelines[iShiftLines - 1])).Location.X, (((QouteLine)aQoutelines[iShiftLines - 1])).Location.Y + 20); // move location of control to new position
			//            (((QouteLine)aQoutelines[iShiftLines])).iLineIndex++;//sync the lineindex of the control array
			//        }
			//        aQoutelines[iLines + 1] = qlNewLine;
			//        qlNewLine.Top = 17 + ((iLineIndex + 1) * 20);
			//        qlNewLine.Left = 4;
					
			//        qlNewLine.TabIndex = 50 + aQoutelines.Length;
			//        qlNewLine.TabStop = true;
			//        qlNewLine.iLineIndex = iLines + 1;
			//        qlNewLine.Name = "qlNewLine_" + (aQoutelines.Length - 1).ToString();
			//        this.pnlDetails.Controls.Add(qlNewLine);
			//        qlNewLine.BringToFront();
			//        return;
			//    }
			//}
		}

		public void AddQouteLine(QouteLine qlNewLine, bool bLoad)
		{
			if (!bLoad)
			{
				Array.Resize<Control>(ref aQoutelines, aQoutelines.Length + 1);
				aQoutelines[aQoutelines.Length - 1] = qlNewLine;
				if (iLineRowIndex < 21)
					qlNewLine.Top = 17 + ((iLineRowIndex) * 20);
				else
					qlNewLine.Top = 408; //16 + ((iLineRowIndex) * 18);

				qlNewLine.Left = 4;

				qlNewLine.TabIndex = 50 + aQoutelines.Length;
				qlNewLine.TabStop = true;

				qlNewLine.iLineIndex = aQoutelines.Length - 1;
				qlNewLine.Name = "qlNewLine_" + (aQoutelines.Length - 1);

				this.pnlDetails.Controls.Add(qlNewLine);
				qlNewLine.BringToFront();
				iLineRowIndex++;
			}
			else
			{
				Array.Resize<Control>(ref aQoutelines, aQoutelines.Length + 1);
				aQoutelines[aQoutelines.Length - 1] = qlNewLine;              
				qlNewLine.Top = 17 + ((iLineRowIndex) * 20);              
				qlNewLine.Left = 4;
				qlNewLine.TabIndex = 50 + aQoutelines.Length;
				qlNewLine.TabStop = true;
				qlNewLine.iLineIndex = aQoutelines.Length - 1;
				qlNewLine.Name = "qlNewLine_" + (aQoutelines.Length - 1);
				this.pnlDetails.Controls.Add(qlNewLine);
				qlNewLine.BringToFront();
				iLineRowIndex++;

			}
		}



		public void addTotals()
		{
			decimal dTotal = 0;
			decimal dDiscountCalcTotal = 0;
			decimal dDiscount = 0;
			decimal dTaxTotal = 0;
			decimal dNonTaxTotal = 0;
			string sLastMasterItem = "";
			string sLastMasterItemDiscountType = "";

			for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			{
				QouteLine qlActive = (QouteLine)aQoutelines[iLines];
				
				dTotal += Convert.ToDecimal(qlActive.txtNet.Text);
				//if (((QouteLine)aQoutelines[iLines]).txtDiscountType.Text == "2" || ((QouteLine)aQoutelines[iLines]).txtDiscountType.Text == "3")
				//{
					dDiscountCalcTotal += Convert.ToDecimal(qlActive.txtNet.Text);
					//sLastMasterItem = "*DT-" + ((QouteLine)aQoutelines[iLines]).txtCode.Text;
					//sLastMasterItemDiscountType = ((QouteLine)aQoutelines[iLines]).txtDiscountType.Text;
				//}

				if (qlActive.txtTaxType.Text == "0" || qlActive.txtTaxType.Text == "2") //Tax free item
				{
					dNonTaxTotal += Convert.ToDecimal(qlActive.txtNet.Text);
				}
				if (txtDiscount.Text != "" && txtDiscount.Text != ".")
				{
					dDiscount = Convert.ToDecimal(txtDiscount.Text) / 100 * dDiscountCalcTotal;
				}

			}

			lblDiscountValue.Text = dDiscount.ToString("N2");
			dTotal -= dDiscount;
			dTaxTotal = dTotal - dNonTaxTotal;
			lblTotalExValue.Text = dTotal.ToString("N2");
			lblTotalTaxValue.Text = (dTaxTotal * 0.15m).ToString("N2");
			lblTotalValue.Text = ((dTaxTotal * 1.15m) + dNonTaxTotal).ToString("N2");
		}


		public void focusNextLine(int iLineIndex)
		{
			//LL 17/09/2009 - start
			if ((iLineIndex >= aQoutelines.Length && txtNumber.Text == "*NEW*") || (iLineIndex >= aQoutelines.Length && txtNumber.Text == ""))
			{
				if (txtNumber.Text == "")
					txtNumber.Text = "*NEW*";
				//LL 17/09/2009 - end
				QouteLine qlNewline = new QouteLine();
				AddQouteLine(qlNewline,false);
			}
			if (iLineIndex < aQoutelines.Length)
			{
				QouteLine qlNewLine = (QouteLine)aQoutelines[iLineIndex];
				qlNewLine.txtCode.Focus();
			}
		}

		private void cmdSearchNumber_Click(object sender, EventArgs e)
		{

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
				case "txtNumber":
					if (txtNumber.Text == "")
					{
						cmdSearchNumber_Click(null, null);
					}
					else if (txtNumber.Text != "*NEW*")
					{
						loadQoute(txtNumber.Text);
					}
					else
					{
						txtCustomerCode.Focus();
					}
					break;
				case "txtCustomerCode":
					if (txtCustomerCode.Text == "")
					{
						findCustomer(txtCustomerCode);
						dtDate.Focus();
					}
					else
					{
						loadCustomer(false, false);
						if (aQoutelines.Length == 0)
						{
							QouteLine qlNewLine = new QouteLine();
							AddQouteLine(qlNewLine,false);
						}
					}
					break;
				case "txtDelAd1":
					txtDelAd2.Focus();
					break;
				case "txtDelAd2":
					txtDelAd3.Focus();
					break;
				case "txtDelAd3":
					txtDelAd4.Focus();
					break;
				case "txtDelAd4":
					txtDelAd5.Focus();
					break;
				case "txtDelAd5":
					txtContact.Focus();
					break;
				case "txtContact":
					txtTelephone.Focus();
					break;
				case "txtTelephone":
					txtFax.Focus();
					break;
				case "txtFax":
					txtMobile.Focus();
					break;
				case "txtMobile":
					txtEmail.Focus();
					break;
				case "txtEmail":
					dtDate.Focus();
					break;
				//LL Phalaborwa
				case "selAddresses":
					dtDate.Focus();
					break;
				//LL end

				case "dtDate":
					txtSalesCode.Focus();
					break;
				case "txtSalesCode":
					txtDiscount.Focus();
					break;
				case "cmdSalesPerson":
					txtDiscount.Focus();
					break;
				case "txtDiscount":
					dtExpiryDate.Focus();
					break;
				case "dtExpiryDate":
					txtCustomerRef.Focus();
					break;
				case "txtCustomerRef":
					focusNextLine(0);
					break;
				case "txtNotes":
					txtNotes.Text += "\r\n";
					int i = txtNotes.Text.Length;
					txtNotes.SelectionStart = i;
					txtNotes.Focus();
					break;
				case "txtQouteNotes":
					txtQouteNotes.Text += "\r\n";
					int i2 = txtQouteNotes.Text.Length;
					txtQouteNotes.SelectionStart = i2;
					txtQouteNotes.Focus();
					break;



			}
		}

		private void findCustomer(TextBox srcBox)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.CustomerZoom frmCustomerZoom = new Finder.CustomerZoom())
			{
				if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmCustomerZoom.CustomerCode != "")
					{
						srcBox.Text = frmCustomerZoom.CustomerCode;
						srcBox.Focus();
						srcBox.SelectionStart = 0;
						srcBox.SelectionLength = srcBox.Text.Length;
                        sCustDelivCode = frmCustomerZoom.DeliveryCode;
						loadCustomer(false, false);
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private string findCustomerDelivery()
		{
			string[] aKeyValues = new string[5];
			aKeyValues[0] = txtCustomerCode.Text;
			Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
			return (clsSDK.Read_Record("ACCDELIV", 4, 2, aKeyValues, Global.sDataPath));
		}

		private string findCustomerHeader()
		{
			string[] aKeyValues = new string[5];
			aKeyValues[0] = txtCustomerCode.Text;
			Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
			return (clsSDK.Read_Record("ACCMASD", 2, 0, aKeyValues, Global.sDataPath));
		}

		private void loadCustomer(bool bAlertMessage, bool bReadOnly)
		{
			bool bRecord = false;
			bBlockedCustomer = false;

			if (txtCustomerCode.Text != "")
			{
				string sCode = "";

				////if (selAddresses.Text != "Main")
				////{
				////    sCode = selAddresses.Text.Substring(selAddresses.Text.IndexOf("[") + 1, selAddresses.Text.Length - (selAddresses.Text.IndexOf("[") + 1)).Replace("]", "");
				////}

				PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
				oConn.Open();
				string sSql = "select Top 1 PostAddress01, PostAddress02, PostAddress03, PostAddress04, CustomerDesc, Discount, PaymentTerms, CreditLimit, ";
				sSql += "CurrBalanceThis01, CurrBalanceThis02, CurrBalanceThis03, CurrBalanceThis04, CurrBalanceThis05, CurrBalanceThis06, CurrBalanceThis07, CurrBalanceThis08, CurrBalanceThis09, CurrBalanceThis10, CurrBalanceThis11, CurrBalanceThis12, CurrBalanceThis13, ";
				sSql += "CurrBalanceLast01, IncExc, CurrBalanceLast02, CurrBalanceLast03, CurrBalanceLast04, CurrBalanceLast05, CurrBalanceLast06, CurrBalanceLast07, CurrBalanceLast08, CurrBalanceLast09, CurrBalanceLast10, CurrBalanceLast11, CurrBalanceLast12, CurrBalanceLast13, ";
				sSql += "DeliveryAddresses.*, Blocked from  CustomerMaster ";
				sSql += "inner join DeliveryAddresses on CustomerMaster.CustomerCode = DeliveryAddresses.CustomerCode ";
				sSql += "where CustomerMaster.CustomerCode = '" + txtCustomerCode.Text.Replace("'", "") + "' and  (CustDelivCode = '" + sCode + "' or CustDelivCode = '')";
				DialogResult drMessage = DialogResult.No;
				PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
				while (rdReader.Read())
				{
					if (bAlertMessage)
					{
						drMessage = MessageBox.Show("This customer record exists in the database. Do you want to load this customer data?", "Record Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					}
					if (!bAlertMessage || drMessage == DialogResult.Yes)
					{
						if (rdReader["Blocked"].ToString().Trim() == "0")
							bRecord = true;
						else
							bBlockedCustomer = true;

						txtDelAd1.Text = rdReader["DelAddress01"].ToString().Trim();
						txtDelAd2.Text = rdReader["DelAddress02"].ToString().Trim();
						txtDelAd3.Text = rdReader["DelAddress03"].ToString().Trim();
						txtDelAd4.Text = rdReader["DelAddress04"].ToString().Trim();
						txtDelAd5.Text = rdReader["DelAddress05"].ToString().Trim();
						//txtContact.Text = rdReader["Contact"].ToString().Trim();
						//    txtTelephone.Text = rdReader["Telephone"].ToString().Trim();
						//    txtFax.Text = rdReader["Fax"].ToString().Trim();

						//txtIncExc.Text = rdReader["IncExc"].ToString().Trim();

						txtMobile.Text = rdReader["Cell"].ToString().Trim();

						txtEmail.Text = rdReader["Email"].ToString().Trim();


						//txtDelAd1.ReadOnly = true;
						//txtDelAd2.ReadOnly = true;
						//txtDelAd3.ReadOnly = true;
						//txtDelAd4.ReadOnly = true;
						//txtDelAd5.ReadOnly = true;


						aMainAddressList[0] = txtDelAd1.Text;
						aMainAddressList[1] = txtDelAd2.Text;
						aMainAddressList[2] = txtDelAd3.Text;
						aMainAddressList[3] = txtDelAd4.Text;
						aMainAddressList[4] = txtDelAd5.Text;
						aMainAddressList[5] = txtContact.Text;
						aMainAddressList[6] = txtTelephone.Text;
						aMainAddressList[7] = txtMobile.Text;
						aMainAddressList[8] = txtFax.Text;
						aMainAddressList[9] = txtEmail.Text;

						txtPostAd1.Text = rdReader["PostAddress01"].ToString().Trim();
						txtPostAd2.Text = rdReader["PostAddress02"].ToString().Trim();
						txtPostAd3.Text = rdReader["PostAddress03"].ToString().Trim();
						txtPostAd4.Text = rdReader["PostAddress04"].ToString().Trim();

						txtCustomerDescription.Text = rdReader["CustomerDesc"].ToString().Trim();
						txtDiscount.Text = (Convert.ToDecimal(rdReader["Discount"].ToString().Trim()) / 100).ToString();

						//txtContact.ReadOnly = true;
						//txtTelephone.ReadOnly = true;
						//txtMobile.ReadOnly = true;
						//txtFax.ReadOnly = true;
						//txtEmail.ReadOnly = true;
						if (bReadOnly)
						{
							//txtPosAd1.ReadOnly = true;
							//txtPosAd2.ReadOnly = true;
							//txtPosAd3.ReadOnly = true;
							//txtPosAd4.ReadOnly = true;

							txtCustomerDescription.ReadOnly = true;
							txtDiscount.ReadOnly = true;
						}

						string sPaymentTerms = rdReader["PaymentTerms"].ToString().Trim();
						if (sPaymentTerms == "0")
						{
							sPaymentTerms = "Current";
						}
						else
						{
							sPaymentTerms += " Days";

						}
						//lblPaymentTermsValue.Text = sPaymentTerms;

						double dCurrentBalance = 0;
						double dCreditLimit = Convert.ToDouble(rdReader["CreditLimit"].ToString().Trim());
						for (int iIndex = 1; iIndex <= 13; iIndex++)
						{
							dCurrentBalance += Convert.ToDouble(rdReader["CurrBalanceThis" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
							dCurrentBalance += Convert.ToDouble(rdReader["CurrBalanceLast" + iIndex.ToString().PadLeft(2, "0".ToCharArray()[0])]);
						}
						//Check Credit Limit vs Balance if Customer should be blocked
						if (dCurrentBalance > dCreditLimit)
						{
							overCreditLimtColor(Color.Red);
							if (!bBlockedCustomer)
							{
								if (Global.bAutoBlockCustomer)
								{
									blockCustomer(txtCustomerCode.Text.Trim());
								}
								else if (Global.bNotifyIfcustoverCredtiLimit)
								{
									if (MessageBox.Show("Customer " + txtCustomerCode.Text.Trim() + " is over his credit limit. Do you want to block this customer?", "Customer Over Credit Limit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
									{
										blockCustomer(txtCustomerCode.Text.Trim());
									}
								}
							}
						}
						else
						{
							if (bInvoiceMode)
								overCreditLimtColor(Color.LightSteelBlue);
							else
								overCreditLimtColor(Color.LemonChiffon);
						}
						//lblCurrentBalanceValue.Text = "R" + dCurrentBalance.ToString("N2");
						//lblCreditLimitValue.Text = "R" + dCreditLimit.ToString("N2");
						//lblInfoCurrentBalance.Text = "R" + dCurrentBalance.ToString("N2");
						//lblInfoCreditLimit.Text = "R" + dCreditLimit.ToString("N2");
						//lblForecast.Text = "";
						//lblInfoForecastBalance.Text = "";
						//lblInfoForecast.Text = "";

						//////selAddresses.Focus();

						//////this.selAddresses.SelectedIndexChanged -= new System.EventHandler(this.selAddresses_SelectedIndexChanged);

						//////selAddresses.Items.Clear();
						////////load additional addresses
						//////selAddresses.Items.Add("Main");

						//////sSql = "select * from DeliveryAddresses ";
						//////sSql += "where CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";
						//////sSql += " and  ltrim(rtrim(CustDelivCode)) <> ''";
						//////sSql += " order by Heading ";
						//////selAddresses.SelectedIndex = 0;

						//////PsqlDataReader rdDeliveryReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
						//////while (rdDeliveryReader.Read())
						//////{
						//////    string sAddressLine = rdDeliveryReader["Heading"].ToString().Trim();
						//////    if (sAddressLine == "")
						//////    {
						//////        sAddressLine = "Main [" + rdDeliveryReader["CustDelivCode"].ToString().Trim() + "]";

						//////    }
						//////    else
						//////    {
						//////        sAddressLine += " [" + rdDeliveryReader["CustDelivCode"].ToString().Trim() + "]";
						//////    }
						//////    selAddresses.Items.Add(sAddressLine);
						//////}
						//////rdDeliveryReader.Close();

						//////if (sCustDelivCode == "\0\0\0\0\0\0\0\0\0\0 []" || CustomerCode == "")
						//////{
						//////    sCustDelivCode = "Main";
						//////}

						//////selAddresses.SelectedItem = sCustDelivCode;
						////////buildCustDetail();

						//////this.selAddresses.SelectedIndexChanged += new System.EventHandler(this.selAddresses_SelectedIndexChanged);
					}
					else//no error message
					{
					}
				}
				if (!bRecord)//record does not exist
				{
					if (bBlockedCustomer) //Record Exists but Customer is Blocked
					{
						MessageBox.Show("This Customer Account is blocked and cannot be used.", "Customer Blocked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						disableButtons();
					}
					else
					{
						MessageBox.Show("This customer record does not exists in the database.", "No Such Record Exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						clearCustomer();//no on alert message
					}
				}
				rdReader.Close();
				oConn.Dispose();
			}
		}

		private void overCreditLimtColor(Color sColor)
		{
			//tpShip.BackColor = sColor;
			//tpPostal.BackColor = sColor;
			//tpForecast.BackColor = sColor;
			//txtPosAd1.BackColor = sColor;
			//txtPosAd2.BackColor = sColor;
			//txtPosAd3.BackColor = sColor;
			//txtPosAd4.BackColor = sColor;
		}

		private void blockCustomer(string sCustomerCode)
		{
			using (PsqlConnection oConnBlock = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
			{
				oConnBlock.Open();
				string sSql = "update CustomerMaster set blocked = '1' where CustomerCode = '" + sCustomerCode + "'";
				int iReturn = Liquid.Classes.Connect.getDataCommand(sSql, oConnBlock).ExecuteNonQuery();
				if (iReturn > 0)
				{
					MessageBox.Show("Customer account is successfully blocked");
					disableButtons();
				}
				oConnBlock.Dispose();
			}
		}

		private void clearCustomer()
		{
			txtDelAd1.Text = "";
			txtDelAd2.Text = "";
			txtDelAd3.Text = "";
			txtDelAd4.Text = "";

			//txtPosAd1.Text = "";
			//txtPosAd2.Text = "";
			//txtPosAd3.Text = "";
			//txtPosAd4.Text = "";

			txtContact.Text = "";
			txtTelephone.Text = "";
			txtFax.Text = "";
			txtMobile.Text = "";
			txtEmail.Text = "";

			txtCustomerDescription.Text = "";
			txtDiscount.Text = "";

		}

		private void disableButtons()
		{
			cmdSaveOrder.Enabled = false;
			//cmdCloseOrder.Enabled = false;        
			cmdNewLine.Enabled = false;
			//cmdViewMonthEnd.Enabled = false;
			cmdPrintQoute.Enabled = false;
		}

		private void cmdSearchCustomer_Click(object sender, EventArgs e)
		{
			TextBox srcBox = null;
			switch (((Button)sender).Name)
			{
				case "cmdSearchCustomer":
					srcBox = txtCustomerCode;
					break;
				   
			}
			findCustomer(srcBox);
		}

		private void cmdSaveOrder_Click(object sender, EventArgs e)
		{

		}

		private int getPadQtyCenter(string sInsertString)
		{
			int iReturnQty = 0;

			iReturnQty = ((45 - sInsertString.Length) / 2) + sInsertString.Length;

			return iReturnQty;
		}

		public void makeReadOnly(bool bUpdateInventory)
		{
			txtCustomerCode.ReadOnly = true;
			cmdSearchCustomer.Visible = false;
			cmdSalesPerson.Visible = false;
			txtSalesCode.ReadOnly = true;
			txtDiscount.ReadOnly = true;
			//txtFreight.ReadOnly = true;
			//txtShipDeliver.ReadOnly = true;
			//txtMessage1.ReadOnly = true;
			//txtMessage2.ReadOnly = true;
			//txtMessage3.ReadOnly = true;
			//radActive.Enabled = false;
			//radStandingOrder.Enabled = false;
			//radFutureOrder.Enabled = false;

			dtDate.Enabled = false;
			txtSalesCode.ReadOnly = true;
			txtCustomerRef.ReadOnly = false;
			txtDiscount.ReadOnly = true;
			dtExpiryDate.Enabled = false;
			//cmdCard.Visible = false;
			//cmdCash.Visible = false;
			//cmdEFT.Visible = false;
			//cmdAccount.Visible = false;
			//lblDepositMethod.Visible = true;
			//txtDepositMethod.Visible = true;
			//txtDepositAmount.ReadOnly = true;
			//txtDepositMethod.ReadOnly = true;

			//Readonly Line Items
			for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
			{
				QouteLine qlThisline = (((QouteLine)aQoutelines[iLines]));
				if (qlThisline.txtCode.Text != "")
				{

					qlThisline.makeLineReadOnly();
					//book this inventory out
					
				}
				else
				{
					this.tpSalesOrder.Controls.Remove(qlThisline);
				}
			}
		}

		private void cmdNewOrder_Click(object sender, EventArgs e)
		{

		}

		public void loadQoute(string sQouteNumber)
		{
			using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
			{
				
				string sSql = "Select * From SOLQHH where DocNumber = '" + sQouteNumber.Trim() +"'";
				PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
				while (rdReader.Read())
				{
					//Clear current qoute
					for (int iLines = 0; iLines < aQoutelines.Length; iLines++)
					{
						QouteLine qlThisline = (((QouteLine)aQoutelines[iLines]));
						pnlDetails.Controls.Remove(qlThisline);
					}
					aQoutelines = new Control[0];
					iLineRowIndex = 0;
					txtCustomerCode.Text = rdReader["CustCode"].ToString();
					txtDelAd1.Text = rdReader["DelAddress01"].ToString();
					txtDelAd2.Text = rdReader["DelAddress02"].ToString();
					txtDelAd3.Text = rdReader["DelAddress03"].ToString();
					txtDelAd4.Text = rdReader["DelAddress04"].ToString();
					txtDelAd5.Text = rdReader["DelAddress05"].ToString();
					txtTelephone.Text = rdReader["Tel"].ToString();
					txtFax.Text = rdReader["Fax"].ToString();
					txtContact.Text = rdReader["Contact"].ToString();
					dtDate.Value = Convert.ToDateTime(rdReader["DocDate"].ToString());
					txtSalesCode.Text = rdReader["SalesCode"].ToString();
					txtDiscount.Text = rdReader["DiscPerc"].ToString();
					dtExpiryDate.Value = Convert.ToDateTime(rdReader["ExpDate"].ToString());
					txtCustomerRef.Text = rdReader["CustRef"].ToString();
					txtNotes.Text = rdReader["Notes"].ToString();
					//get status
					if (rdReader["Status"].ToString() == "1")
					{
						pnlStatus.BackColor = Color.LimeGreen;
						cmdReject.Visible = false;
						cmdAccept.Visible = false;
					}
					else if (rdReader["Status"].ToString() == "2")
					{
						pnlStatus.BackColor = Color.Red;
						cmdReject.Visible = false;
						cmdAccept.Visible = false;
					}
					else
					{
						pnlStatus.BackColor = Color.SandyBrown;
						cmdReject.Visible = true;
						cmdAccept.Visible = true;
					}

					txtProject.Text = rdReader["Project"].ToString();
					//get postal addresses
					using (PsqlConnection oConnPastel = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
					{
						string sSqlPastel = "Select PostAddress01, PostAddress02, PostAddress03, PostAddress04, CustomerDesc FROM CustomerMaster where CustomerCode = '" + txtCustomerCode.Text + "'";
						PsqlDataReader rdReaderPastel = Liquid.Classes.Connect.getDataCommand(sSqlPastel, oConnPastel).ExecuteReader();
						while (rdReaderPastel.Read())
						{
							txtCustomerDescription.Text = rdReaderPastel["CustomerDesc"].ToString();
							txtPostAd1.Text = rdReaderPastel["PostAddress01"].ToString();
							txtPostAd2.Text = rdReaderPastel["PostAddress02"].ToString();
							txtPostAd3.Text = rdReaderPastel["PostAddress03"].ToString();
							txtPostAd4.Text = rdReaderPastel["PostAddress04"].ToString();                           
						}
						oConnPastel.Dispose();
						rdReaderPastel.Close();
					}

					   //get line info
						string sSqlHL = "Select * From SOLQHL where DocNumber = '" + sQouteNumber + "' order by LinkNum";
						PsqlDataReader rdReaderHL = Liquid.Classes.Connect.getDataCommand(sSqlHL, oConn).ExecuteReader();
						while (rdReaderHL.Read())
						{
							LoadLines(rdReaderHL["ItemCode"].ToString(), rdReaderHL["Multiplier"].ToString(), rdReaderHL["Qty"].ToString(), rdReaderHL["UnitPrice"].ToString(), rdReaderHL["Description"].ToString(), rdReaderHL["DiscountPercentage"].ToString(), rdReaderHL["LinkNum"].ToString(), rdReaderHL["Unit"].ToString());
						}
						rdReaderHL.Close();
					// get pic attachment
						dgAttachPicture.Rows.Clear();
						string sSqlQa = "Select * From SOLQA where FkDocNumber = '" + txtNumber.Text + "'";
						PsqlDataReader rdReaderQa = Liquid.Classes.Connect.getDataCommand(sSqlQa, oConn).ExecuteReader();
						while (rdReaderQa.Read())
						{
							int n = dgAttachPicture.Rows.Add();
							dgAttachPicture.Rows[n].Cells[0].Value = rdReaderQa["Path"].ToString();
						}
						dgAttachPicture.Rows.Add();
						rdReaderQa.Close();
					
					
					//get notes
					 string sSqlQN = "Select * From SOLQN where FkDocNumber = '" + txtNumber.Text + "'";
					 PsqlDataReader rdReaderQN = Liquid.Classes.Connect.getDataCommand(sSqlQN, oConn).ExecuteReader();
					 while (rdReaderQN.Read())
					 {
						 txtQouteNotes.Text = rdReaderQN["Note"].ToString();
					 }
					 rdReaderQN.Close();
				  }
				oConn.Dispose();
				rdReader.Close();                               
			}
			addTotals();
			txtNumber.Text = sQouteNumber;
			

		}

		private void LoadLines(string sItemCode, string sMultiplier, string sQty,string sExclPrice, string sDescription, string sDisc, string sLinkNum, string sUnit)
		{

			QouteLine qlNewLine = new QouteLine();
			qlNewLine.bDoCalculation = false;
			qlNewLine.txtCode.Text = sItemCode;
			qlNewLine.txtUnit.Text = sUnit;
			qlNewLine.txtDiscount.Text = sDisc;
			qlNewLine.txtExcPrice.Text = sExclPrice;
			qlNewLine.txtDescription.Text = sDescription;
			//qlNewLine.cmdCodeSearch.Visible = false;
			//qlNewLine.txtExcPrice.ReadOnly = true;
			//qlNewLine.txtMultiplier.Text = sMultiplier;
			qlNewLine.txtQuantity.Text = sQty;
			if (pnlStatus.BackColor == Color.LimeGreen)
				qlNewLine.txtQuantity.ReadOnly = true;

			decimal dQty = Convert.ToDecimal(sMultiplier) * Convert.ToDecimal(sQty);
			double dTotalExDiscount = Convert.ToDouble(dQty) * Convert.ToDouble(qlNewLine.txtExcPrice.Text.Replace(",", ""));
			qlNewLine.txtNet.Text = (dTotalExDiscount - (dTotalExDiscount * (Convert.ToDouble(qlNewLine.txtDiscount.Text.Replace(",", "")) / 100))).ToString("N2");           
			AddQouteLine(qlNewLine,true);
			qlNewLine.bDoCalculation = true;
		}

		private string GetContactAddress(string sCustomer, string sContact, string sTel, string sFax)
		{
			string aReturn = "";

			using (PsqlConnection oConnDelAddress = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
			{
				oConnDelAddress.Open();

				string sSqlAdd = "Select CustDelivCode, Heading from DeliveryAddresses ";
				sSqlAdd += "where CustomerCode = '" + sCustomer.Replace("'", "''") + "' ";
				sSqlAdd += "and Contact = '" + sContact.Replace("'", "''").Replace("\0", " ").Trim() + "' ";
				sSqlAdd += "and Telephone = '" + sTel.Trim().Replace("'", "''") + "' ";
				sSqlAdd += "and Fax = '" + sFax.Trim().Replace("'", "''").Replace("\0", " ").Trim() + "' ";

				PsqlDataReader rdAddressReader = Liquid.Classes.Connect.getDataCommand(sSqlAdd, oConnDelAddress).ExecuteReader();
				while (rdAddressReader.Read())
				{
					aReturn = rdAddressReader["Heading"].ToString().Trim() + " [" + rdAddressReader["CustDelivCode"].ToString().Trim() + "]";
				}
				rdAddressReader.Close();
				oConnDelAddress.Dispose();
			}


			return aReturn;
		}        

		private void cmdSalesPerson_Click(object sender, EventArgs e)
		{

		}

		private void deposit_method_click(object sender, EventArgs e)
		{

		}

		private void LoadReceivePaymentScreen()
		{

		   
		}

		private string[] getSalesOrderRecord(string sSalesNumber)
		{
			string[] aKeyValuesSales = new string[5];
			aKeyValuesSales[0] = sSalesNumber;
			aKeyValuesSales[1] = "2";
			return (clsSDK.Read_Record("ACCHISTH", 28, 4, aKeyValuesSales, Global.sDataPath).Split("|".ToCharArray()));
		}

		private void ProcessReturnItems(PsqlConnection oPasConn, PsqlConnection oSolConn, ref SalesLineForm slActive)
		{
		   
		}

		public void setSalesOrderStatus(int iStatus)
		{
			iSalesOrderStatus = iStatus;
			//pnlSalesStatus.BackColor = (Color)aSalesOrderStatusColor[iStatus];
			if (iStatus == 3)
			{
				cmdNewLine.Enabled = false;
				cmdSaveOrder.Enabled = false;
			}
			else
			{
				cmdNewLine.Enabled = true;
				cmdSaveOrder.Enabled = true;
			}
		}

		private void cmdCreditEntireInvoice_Click(object sender, EventArgs e)
		{
			//send message to invoice engine

		}

		public void addUpdateInstruction(string sObjectID, int iInstruction, object oData, string sQuantity, string sMultiplier)
		{
			//Instructions
			// 0 -  Update Sales Line Delivery Date
			// 1 - New Sales Order Line

			cmdSaveOrder.Enabled = true;
			//check if instruction allready exist
			for (int iRow = 0; iRow < aUpdate.GetLength(0); iRow++)
			{
                if ((aUpdate[iRow, 0].ToString() + aUpdate[iRow, 1].ToString()) == (sObjectID + iInstruction))
				{
					aUpdate[iRow, 2] = oData;
					aUpdate[iRow, 3] = sQuantity;
					aUpdate[iRow, 4] = sMultiplier;
					return;
				}
			}
			//Add row if instruction does not exist
			Functions.ResizeArray(ref aUpdate, aUpdate.GetLength(1), aUpdate.GetLength(0) + 1);
			aUpdate[aUpdate.GetLength(0) - 1, 0] = sObjectID;
			aUpdate[aUpdate.GetLength(0) - 1, 1] = iInstruction;
			aUpdate[aUpdate.GetLength(0) - 1, 2] = oData;
			aUpdate[aUpdate.GetLength(0) - 1, 3] = sQuantity;
			aUpdate[aUpdate.GetLength(0) - 1, 4] = sMultiplier;
		}

		private void cmdNewLine_Click(object sender, EventArgs e)
		{
			QouteLine qlNewline = new QouteLine();
			AddQouteLine(qlNewline,false);
			qlNewline.bNextLine = true;
			qlNewline.txtCode.Focus();
			qlNewline.bFocusOnNextLine = false;
			//addUpdateInstruction(qlNewline.Name, 1, qlNewline, qlNewline.txtQuantity.Text, qlNewline.txtMultiplier.Text);
		}

		private string getPastelLine(SalesLineForm slThisLineForm)
		{
			string sLine = "";
			string sLineType = "4";
			if (slThisLineForm.txtCode.Text == "'")
			{
				sLine += "|"; //Cost Price
				sLine += "|"; //Line Quantity
				sLine += "|"; //Exclusive Price Per Unit
				sLine += "|"; //Inclusive Price Per Unit							
				sLine += "|"; //Unit
				sLine += "|"; //Tax Type
				sLine += "|"; //Discount Type
				sLine += "|"; //Discount %
				sLine += "|"; //Code
				sLine += slThisLineForm.txtDescription.Text.Trim() + "|"; //Description
				sLine += "7|"; //Line Type
				sLine += "|"; //Multistore
				sLine += "|"; //CostCode				
			}
			else if (slThisLineForm.txtCode.Text != "")//line defined by Code
			{
				string sQuantity = (Convert.ToDecimal(slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim()) * Convert.ToDecimal(slThisLineForm.txtQuantity.Text.Replace(",", "").Trim())).ToString();
				sLine += "|"; //Cost Price
				sLine += sQuantity + "|"; //Line Quantity
				sLine += slThisLineForm.txtExcPrice.Text.Replace(",", "").Trim() + "|"; //Exclusive Price Per Unit
                //LL 16/09/2009 -- start
                /*if (slThisLineForm.txtTaxType.Text == "0")
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text)).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit							
                else if (slThisLineForm.txtTaxType.Text == "1")
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text) * 1.15).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit							
                else if (slThisLineForm.txtTaxType.Text == "2")
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text)).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit		
                */
                sLine += getInclusivePrice(slThisLineForm.txtTaxType.Text, slThisLineForm.txtExcPrice.Text).ToString().Replace(",", "") + "|";

                //LL 16/09/2009 -- end
                sLine += slThisLineForm.txtUnit.Text.Trim() + "|"; //Unit
				sLine += slThisLineForm.txtTaxType.Text.PadLeft(2, "0".ToCharArray()[0]) + "|"; //Tax Type
				sLine += "0|"; //Discount Type
				sLine += slThisLineForm.txtDiscount.Text.Replace(".", "").Replace(",", "") + "|"; //Discount %
				sLine += slThisLineForm.txtCode.Text.Trim() + "|"; //Code
				sLine += slThisLineForm.txtDescription.Text.Trim() + "|"; //Description
				sLine += sLineType + "|"; //Line Type
				sLine += slThisLineForm.txtStore.Text.Trim() + "|"; //Multistore
				sLine += "|"; //CostCode				
			}
			return (sLine);
		}

        private double getInclusivePrice(string taxType, string exclusivePrice)
        {
            //0 rate
            if (taxType == "0" || taxType == "3")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", ""));
            }
            //14% rate
            if (taxType == "1" || taxType == "2")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 1.14;
            }
            //100% rate
            if (taxType == "4")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 2;
            }
            //15% rate
            if (taxType == "5" || taxType == "6")
            {
                return Convert.ToDouble(exclusivePrice.Replace(",", "")) * 1.15;
            }

            throw new NotImplementedException($"Invalid Tax Type {taxType}");
        }

        private void insertSolHistoryLine(SalesLineForm slThisLineForm, Pervasive.Data.SqlClient.PsqlConnection oConn, string sHeaderDocumentNumber)
		{

			string sDelivery = "", sReturn = "", sType = "", sSql = "";
			if (slThisLineForm.dtReturnDate.Visible && slThisLineForm.txtCode.Text != "" && slThisLineForm.txtQuantity.Text != "0")//line defined by Code and must be a lease item
			{
				sType = "1"; //Lease Item
			}
			string sStatus = slThisLineForm.txtStatus.Text;
			if (sStatus == "")
			{
				sStatus = "0";
			}
			if (slThisLineForm.dtReturnDate.Visible == false)//not a lease item
			{
				sDelivery = "null";
				sReturn = "null";
			}
			else
			{
				DateTime dtNow = DateTime.Now;
				if (dtNow.Day != slThisLineForm.dtDelivery.Value.Day)
				{
					sDelivery = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy 08:00") + "'";
				}
				else
				{
					sDelivery = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy HH:mm") + "'";
				}

				DateTime dtNow2 = DateTime.Now;
				if (dtNow.Day != slThisLineForm.dtReturnDate.Value.Day)
				{
					sReturn = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy HH:mm") + "'";
				}
				else
				{
					sReturn = "'" + slThisLineForm.dtDelivery.Value.ToString("dd-MM-yyyy 08:00") + "'";
				}



			}


			if (slThisLineForm.txtCode.Text != "" && slThisLineForm.txtCode.Text != "'")
			{
				sSql = "INSERT into SOLHL";
				sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
				sSql += " VALUES ";
				sSql += "(";
				sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
				sSql += ",'" + slThisLineForm.txtCode.Text + "'";
				sSql += "," + sDelivery;
				sSql += "," + sReturn;
				sSql += "," + sStatus;
				sSql += "," + (slThisLineForm.iLineIndex + 1);
				sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
				sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
				sSql += "," + sDelivery;
				sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
				sSql += ",'" + slThisLineForm.txtDescription.Text + "'";
				sSql += ")";
				int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
				slThisLineForm.sPastelLineLink = (slThisLineForm.iLineIndex + 1).ToString();
			}
			else if (slThisLineForm.txtCode.Text != "")
			{
				sSql = "INSERT into SOLHL";
				sSql += " (Header, ItemCode, DeliveryDate, ReturnDate, Status,LinkNum, Multiplier, Qty, OrigDeliveryDate,sCalculationRule, Description) ";
				sSql += " VALUES ";
				sSql += "(";
				sSql += "'" + sHeaderDocumentNumber.Trim() + "'";
				sSql += ",'C'";
				sSql += "," + sDelivery;
				sSql += "," + sReturn;
				sSql += "," + sStatus;
				sSql += "," + (slThisLineForm.iLineIndex + 1);
				sSql += "," + slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim();
				sSql += "," + slThisLineForm.txtQuantity.Text.Replace(",", "").Trim();
				sSql += "," + sDelivery;
				sSql += ",'" + slThisLineForm.txtUnitFormula.Text + "'";
				sSql += ",'" + slThisLineForm.txtDescription.Text + "'";
				sSql += ")";
				int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
				slThisLineForm.sPastelLineLink = (slThisLineForm.iLineIndex + 1).ToString();

			}
			//if (slThisLineForm.txtCode.Text == "'")
			//{
			//    slThisLineForm.sPastelLineLink = (slThisLineForm.iLineIndex + 1).ToString();
			//}
		}

		private void cmdRePrintDelNote_Click(object sender, EventArgs e)
		{

		}

		private void UpdateNextDocNumber(PsqlConnection oConn, string sNextNumber)
		{

			string sSql = "Update SOLCS set DepositReceivedNumbe = " + sNextNumber;
			int iReturn = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
			if (iReturn == 0)
				MessageBox.Show("An error occured when updating the Goods Issued Number in SOLCS");

		}

		private string BuildGlString(string sDebitAccount, string sCreditAccount, string sReference, string sDescription, string sAmount, string sGDC, string sDocumentNumber, string sOpenItemType)
		{
			Liquid.Classes.Generate clGenerate = new Liquid.Classes.Generate();
			string sPeriod = clGenerate.GetPeriodValue(DateTime.Now);

			string sImport = sPeriod + "|"; //Period
			sImport += DateTime.Now.ToString("dd/MM/yyyy") + "|"; //Date
			sImport += sGDC + "|"; //GDC
			sImport += sDebitAccount + "|"; //Account Number
			sImport += sReference + "|"; //Reference
			sImport += sDescription + "|"; //Description
			sImport += sAmount + "|"; //Amount
			sImport += "00|"; //Tax Type
			sImport += "0|"; //Tax Amount - No tax on deposit
			sImport += sOpenItemType + "|"; //Open Type - You tell Pastel that the transactions are allocations by setting this field to “A”
			sImport += "|"; //Job Code
			sImport += "|"; //Matching Referent
			sImport += "0|"; //Discount Amount
			sImport += "0|"; //Discount Type
			sImport += sCreditAccount + "|"; //Contra Account
			sImport += "1|"; //Exchange Rate
			sImport += "1"; //Bank exchange rate

			return sImport;
		}

		

		private int CountDays(DayOfWeek day, DateTime start, DateTime end)
		{
			TimeSpan ts = end - start; // Total duration
			int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
			int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
			int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
			if (sinceLastDay < 0)
				sinceLastDay += 7;                           // Adjust for negative days since last [day]
			// If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
			if (remainder >= sinceLastDay)
				count++;
			return count;
		}
        
		private string GetPeriodEnd()
		{
			string sReturn = "";
			using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
			{
				oConn.Open();
				string sSql = "Select NumberPeriodsThis, PerEndThis01, PerEndThis02, PerEndThis03, PerEndThis04, ";
				sSql += "PerEndThis05, PerEndThis06, PerEndThis07, PerEndThis08, PerEndThis09, PerEndThis10, ";
				sSql += "PerEndThis11, PerEndThis12, PerEndThis13,PerStartThis01, PerStartThis02, PerStartThis03, PerStartThis04, ";
				sSql += "PerStartThis05, PerStartThis06, PerStartThis07, PerStartThis08, PerStartThis09, PerStartThis10, ";
				sSql += "PerStartThis11, PerStartThis12, PerStartThis13, CurrentPeriod from LedgerParameters";

				PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();

				while (rdReader.Read())
				{

					sReturn = Convert.ToDateTime(rdReader["PerEndThis" + rdReader["CurrentPeriod"].ToString().PadLeft(2, "0".ToCharArray()[0])]).ToString("MM/dd/yyyy");

				}
				rdReader.Close();
				oConn.Dispose();
			}
			return sReturn;

		}

		private string CreateDocLineFromSalesline(SalesLineForm slThisLineForm, int iLines)
		{
			string sLine = "";
			if (slThisLineForm.sLineType != "Comment" && slThisLineForm.txtCode.Text.Trim() != "'")
			{
				string sQuantity = (Convert.ToDecimal(slThisLineForm.txtMultiplier.Text.Replace(",", "").Trim()) * Convert.ToDecimal(slThisLineForm.txtQuantity.Text.Replace(",", "").Trim())).ToString();
				sLine += "|"; //Cost Price
				sLine += sQuantity + "|"; //Line Quantity
				sLine += slThisLineForm.txtExcPrice.Text.Replace(",", "").Trim() + "|"; //Exclusive Price Per Unit
                //LL 16/09/2009 -- start
                /*if (slThisLineForm.txtTaxType.Text == "0")
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text)).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit							
                else if (slThisLineForm.txtTaxType.Text == "1")
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text) * 1.15).ToString().Replace(",", "") + "|"; //Inclusive Price Per Unit		
                else
                    sLine += (Convert.ToDouble(slThisLineForm.txtExcPrice.Text)).ToString().Replace(",", "") + "|"; //All other tax type will send a 0 tax value through
                    */
                sLine += getInclusivePrice(slThisLineForm.txtTaxType.Text, slThisLineForm.txtExcPrice.Text).ToString().Replace(",", "") + "|";
                //LL 16/09/2009 -- end
                sLine += slThisLineForm.txtUnit.Text.Trim() + "|"; //Unit
				sLine += slThisLineForm.txtTaxType.Text.PadLeft(2, "0".ToCharArray()[0]) + "|"; //Tax Type
				sLine += "0|"; //Discount Type
				sLine += slThisLineForm.txtDiscount.Text.Replace(".", "").Replace(",", "") + "|"; //Discount %
				sLine += slThisLineForm.txtCode.Text.Trim() + "|"; //Code
				sLine += slThisLineForm.txtDescription.Text.Trim() + "~" + iLines + "|"; //Description
				sLine += "4|"; //Line Type
				sLine += slThisLineForm.txtStore.Text.Trim() + "|"; //Line Type
				sLine += "|"; //CostCode
				sLine += "^" + slThisLineForm.sLineType; // Generate Invoice Function Needs Line Type                
				if (slThisLineForm.sLineType == "1")//Lease Item
				{

					sLine += "^" + slThisLineForm.dtDelivery.Value.ToString("dd/MM/yyyy") + "^" + slThisLineForm.dtReturnDate.Value.ToString("dd/MM/yyyy");
				}
				sLine += "^" + slThisLineForm.sPastelLineLink;//Add linknum at end of string in order to delete line from SOLHL
				string sReturned = "0";
				if (slThisLineForm.picReturned.Visible)
				{
					sReturned = "1";
				}
				sLine += "^" + sReturned;//Add linknum at end of string in order to delete line from SOLHL


			}
			else
			{
				string sDescription = slThisLineForm.txtDescription.Text;
				//                if (slThisLineForm.txtDescription.Text.StartsWith("*D"))
				//              {
				//               
				//          }
				sLine = "|"; //Cost Price
				sLine += "|"; //Line Quantity							
				sLine += "|"; //Exclusive Price Per Unit
				sLine += "|"; //Inclusive Price Per Unit					
				sLine += "|"; //Unit
				sLine += "|"; //Tax Type
				sLine += "|"; //Discount Type
				sLine += "|"; //Discount %
				sLine += "'|"; //Code
				sLine += sDescription + "|"; //Description
				sLine += "7|"; //Line Type
				sLine += "|"; //Line Type
				sLine += "|"; //CostCode                
				sLine += "^*C";
			}
			return sLine;
		}

		private void chkInvoiceConsumables_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void FrontendInvoiceMode()
		{
		   // cmdViewInvoiceMode.ImageIndex = 1;
			bInvoiceMode = true;
			cmdSaveOrder.Enabled = false;
			this.tpSalesOrder.BackColor = Color.LightSteelBlue;
			//this.tpShip.BackColor = Color.LightSteelBlue;
			this.txtCustomerDescription.BackColor = Color.LightSteelBlue;
			//this.tpPostal.BackColor = Color.LightSteelBlue;
			this.pnlCodeLabel.BackColor = Color.LightSteelBlue;
			this.pnlDescriptionLabel.BackColor = Color.LightSteelBlue;
		   
			//this.panel61.BackColor = Color.LightSteelBlue;
			this.pnlUnitLabel.BackColor = Color.LightSteelBlue;
			this.pnlQtyLabel.BackColor = Color.LightSteelBlue;
			this.pnlDisLabel.BackColor = Color.LightSteelBlue;
			this.pnlDiscountLabel.BackColor = Color.LightSteelBlue;
			this.pnlExcPriceLabel.BackColor = Color.LightSteelBlue;
			this.pnlNettLabel.BackColor = Color.LightSteelBlue;
			this.panel25.BackColor = Color.LightSteelBlue;
		   
			
			//this.txtPosAd1.BackColor = Color.LightSteelBlue;
			//this.txtPosAd2.BackColor = Color.LightSteelBlue;
			//this.txtPosAd3.BackColor = Color.LightSteelBlue;
			//this.txtPosAd4.BackColor = Color.LightSteelBlue;
			//this.pnlSalesOrderStatus.BackColor = Color.LightSteelBlue;
			//lblReturnHeading.Text = "Invoice";
		}

		private void cmdViewInvoiceMode_Click(object sender, EventArgs e)
		{

		}

		private void DoForecast(DateTime dtForecastUpto)
		{
		   
		}

		private void cmdLockOrder_Click(object sender, EventArgs e)
		{

		}

		private void cmdPrintDepotInvoice_Click(object sender, EventArgs e)
		{

		}

		private void chkPublicHolidays_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void selAddresses_SelectedIndexChanged(object sender, EventArgs e)
		{
		  
			//buildCustDetail();
		}

		private void cmdSaveOrder_Click_1(object sender, EventArgs e)
		{

			using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
			{  
				string sDocNumber = "";
				if (txtNumber.Text.Trim() == "*NEW*") //new qoute
				{
					//Generate QouteNumber
					string sSqlPrefix = "Select QoutePrefix From SOLCS";
					string sPrefix = Liquid.Classes.Connect.getDataCommand(sSqlPrefix, oConn).ExecuteScalar().ToString().Trim();
					int iPrefixLength = sPrefix.Length;
					int iPadLength = 8 - iPrefixLength;
					int iDocNumber;
					string sSqlDocNumber = "Select Max(DocNumber) From SOLQHH";
					string sNumber = Liquid.Classes.Connect.getDataCommand(sSqlDocNumber, oConn).ExecuteScalar().ToString().Trim();
					if (sNumber == "")
					{
						sNumber = "0"; //firts invoice
						iDocNumber = Convert.ToInt32(sNumber + 1);
					}
					else
					{
						iDocNumber = Convert.ToInt32(sNumber.Remove(0, iPrefixLength)) + 1;
					}

					sNumber = iDocNumber.ToString().PadLeft(iPadLength, '0');
					sDocNumber = sPrefix + sNumber;

					//save new details
					int iStatus = 0;
					//status of qoute 1 = new 2 = accepted 3 = rejected
					if (pnlStatus.BackColor == Color.LimeGreen)
					{
						iStatus = 1;
					}
					else if (pnlStatus.BackColor == Color.Red)
					{
						iStatus = 2;
					}
				 
					//insert header info into solqhh
					string sSql = "INSERT into SOLQHH";
					sSql += " (DocNumber, CustCode, DocDate, CustRef, SalesCode, Notes, DelAddress01, DelAddress02, DelAddress03, DelAddress04, DelAddress05";
					sSql += " ,ExpDate, Tel, Fax, Contact, DiscPerc, Total, TotalTax,TotalDiscount, TotalExcl,Status,Project) Values ";
					sSql += "('" + sDocNumber + "','" + txtCustomerCode.Text.Trim() + "','" + dtDate.Value.ToString("yyyy-MM-dd") + "','" + txtCustomerRef.Text.Trim().Replace("'","''") + "'";
					sSql += ",'" + txtSalesCode.Text.Trim() + "','" + txtNotes.Text.Replace("'", "''") + "','" + txtDelAd1.Text.Trim().Replace("'", "''") + "','" + txtDelAd2.Text.Trim().Replace("'", "''") + "','" + txtDelAd3.Text.Trim().Replace("'", "''") + "'";
					sSql += ",'" + txtDelAd4.Text.Trim().Replace("'", "''") + "','" + txtDelAd5.Text.Trim().Replace("'", "''") + "','" + dtExpiryDate.Value.ToString("yyyy-MM-dd") + "','" + txtTelephone.Text.Trim().Replace("'", "''") + "','" + txtFax.Text.Trim().Replace("'", "''") + "'";
					sSql += ",'" + txtContact.Text.Trim().Replace("'", "''") + "','" + txtDiscount.Text.Trim().Replace("'", "''") + "'," + Convert.ToDouble(lblTotalValue.Text.Trim()) + "," + Convert.ToDouble(lblTotalTaxValue.Text.Trim()) + "," + Convert.ToDouble(lblDiscountValue.Text.Trim()) + "," + Convert.ToDouble(lblTotalExValue.Text.Trim()) + ",'" + iStatus + "','" + txtProject.Text.Replace("'", "''") + "')";
					int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();

					 //insert lineinfo into solqhl for each line
					for (int iLine = 0; iLine < aQoutelines.Length; iLine++)
					{						
						QouteLine qlThisLine = (QouteLine)aQoutelines[iLine];
						if (qlThisLine.txtCode.Text != "" && qlThisLine.txtDescription.Text != "")
						{
							decimal dInclPrice = Convert.ToDecimal(qlThisLine.txtExcPrice.Text) * 115 / 100;
							decimal dTaxAmt = Convert.ToDecimal(qlThisLine.txtExcPrice.Text) * 15 / 100;
							string sSqlHl = "INSERT into SOLQHL";
							sSqlHl += "(DocNumber, ItemCode, CustCode, Multiplier, Qty, UnitPrice, InclPrice, TaxAmt,";
							sSqlHl += " DiscountPercentage, LinkNum, Description, LineTotalExcl, Unit) Values ";
							sSqlHl += "('" + sDocNumber + "','" + qlThisLine.txtCode.Text.Trim().Replace("'","''") + "','" + txtCustomerCode.Text.Trim() + "',1.00";
							sSqlHl += ",'" + Convert.ToDouble(qlThisLine.txtQuantity.Text) + "','" + Convert.ToDouble(qlThisLine.txtExcPrice.Text) + "','" + Convert.ToDouble(dInclPrice.ToString("N2")) + "','" + Convert.ToDouble(dTaxAmt.ToString("N2")) + "'";
							sSqlHl += ",'" + qlThisLine.txtDiscount.Text + "','" + iLine + "','" + qlThisLine.txtDescription.Text.Trim().Replace("'", "''") + "','" + Convert.ToDouble(qlThisLine.txtNet.Text) + "','" + qlThisLine.txtUnit.Text + "')";
							int RetHL = Liquid.Classes.Connect.getDataCommand(sSqlHl, oConn).ExecuteNonQuery();
						}
					}
					txtNumber.Text = sDocNumber;

				}
				else //saved qoute
				{
					//delete previous details.
					cmdAccept.Visible = true;
					cmdReject.Visible = true;
					string delHL = "delete From SOLQHL where DocNumber = '" + txtNumber.Text.Trim() + "'";
					int delRet = Liquid.Classes.Connect.getDataCommand(delHL, oConn).ExecuteNonQuery();
					string delHH = "delete From SOLQHH where DocNumber = '" + txtNumber.Text.Trim() + "'";
					int delRet2 = Liquid.Classes.Connect.getDataCommand(delHH, oConn).ExecuteNonQuery();
					
					//save new details
					int iStatus = 0;
					//status of qoute 1 = new 2 = accepted 3 = rejected
					if (pnlStatus.BackColor == Color.LimeGreen)
					{
						iStatus = 1;
					}
					else if (pnlStatus.BackColor == Color.Red)
					{
						iStatus = 2;
					}
				   

					sDocNumber = txtNumber.Text;
					//insert header info into solqhh
					string sSql = "INSERT into SOLQHH";
					sSql += " (DocNumber, CustCode, DocDate, CustRef, SalesCode, Notes, DelAddress01, DelAddress02, DelAddress03, DelAddress04, DelAddress05";
					sSql += " ,ExpDate, Tel, Fax, Contact, DiscPerc, Total, TotalTax,TotalDiscount, TotalExcl, Status, Project) Values ";
					sSql += "('" + sDocNumber + "','" + txtCustomerCode.Text.Trim().Replace("'", "''") + "','" + dtDate.Value.ToString("yyyy-MM-dd") + "','" + txtCustomerRef.Text.Trim().Replace("'", "''") + "'";
					sSql += ",'" + txtSalesCode.Text.Trim() + "','" + txtNotes.Text.Replace("'", "''") + "','" + txtDelAd1.Text.Trim().Replace("'", "''") + "','" + txtDelAd2.Text.Trim().Replace("'", "''") + "','" + txtDelAd3.Text.Trim().Replace("'", "''") + "'";
					sSql += ",'" + txtDelAd4.Text.Trim().Replace("'", "''") + "','" + txtDelAd5.Text.Trim().Replace("'", "''") + "','" + dtExpiryDate.Value.ToString("yyyy-MM-dd") + "','" + txtTelephone.Text.Trim().Replace("'", "''") + "','" + txtFax.Text.Trim().Replace("'", "''") + "'";
					sSql += ",'" + txtContact.Text.Trim().Replace("'", "''") + "'," + txtDiscount.Text.Trim() + "," + Convert.ToDouble(lblTotalValue.Text.Trim()) + "," + Convert.ToDouble(lblTotalTaxValue.Text.Trim()) + "," + Convert.ToDouble(lblDiscountValue.Text.Trim()) + "," + Convert.ToDouble(lblTotalExValue.Text.Trim()) + ",'" + iStatus + "','" + txtProject.Text + "')";
					int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();

					//insert lineinfo into solqhl for each line
					for (int iLine = 0; iLine < aQoutelines.Length; iLine++)
					{

						QouteLine qlThisLine = (QouteLine)aQoutelines[iLine];
						if (qlThisLine.txtCode.Text != "" && qlThisLine.txtDescription.Text != "")
						{
							decimal dInclPrice = Convert.ToDecimal(qlThisLine.txtExcPrice.Text) * 115 / 100;
							decimal dTaxAmt = Convert.ToDecimal(qlThisLine.txtExcPrice.Text) * 15 / 100;
							if (qlThisLine.txtCode.Text.Trim() == "'")
							{
								string sSqlHl = "INSERT into SOLQHL";
								sSqlHl += "(DocNumber, ItemCode, CustCode, Multiplier, Qty, UnitPrice, InclPrice, TaxAmt,";
								sSqlHl += " DiscountPercentage, LinkNum, Description, LineTotalExcl, Unit) Values ";
								sSqlHl += "('" + sDocNumber + "','''','" + txtCustomerCode.Text.Trim() + "',1.00";
								sSqlHl += ",'" + qlThisLine.txtQuantity.Text + "','" + Convert.ToDouble(qlThisLine.txtExcPrice.Text) + "','" + Convert.ToDouble(dInclPrice.ToString("N2")) + "','" + Convert.ToDouble(dTaxAmt.ToString("N2")) + "'";
								sSqlHl += ",'" + qlThisLine.txtDiscount.Text + "','" + iLine + "','" + qlThisLine.txtDescription.Text.Trim().Replace("'", "''") + "','" + Convert.ToDouble(qlThisLine.txtNet.Text) + "','" + qlThisLine.txtUnit.Text + "')";
								int RetHL = Liquid.Classes.Connect.getDataCommand(sSqlHl, oConn).ExecuteNonQuery();
							}
							else
							{
								string sSqlHl = "INSERT into SOLQHL";
								sSqlHl += "(DocNumber, ItemCode, CustCode, Multiplier, Qty, UnitPrice, InclPrice, TaxAmt,";
								sSqlHl += " DiscountPercentage, LinkNum, Description, LineTotalExcl, Unit) Values ";
								sSqlHl += "('" + sDocNumber + "','" + qlThisLine.txtCode.Text.Trim() + "','" + txtCustomerCode.Text.Trim() + "',1.00";
								sSqlHl += ",'" + qlThisLine.txtQuantity.Text.Replace(",","") + "','" + Convert.ToDouble(qlThisLine.txtExcPrice.Text) + "','" + Convert.ToDouble(dInclPrice.ToString("N2")) + "','" + Convert.ToDouble(dTaxAmt.ToString("N2")) + "'";
								sSqlHl += ",'" + qlThisLine.txtDiscount.Text + "','" + iLine + "','" + qlThisLine.txtDescription.Text.Trim().Replace("'","''") + "','" + Convert.ToDouble(qlThisLine.txtNet.Text) + "','" + qlThisLine.txtUnit.Text + "')";
								int RetHL = Liquid.Classes.Connect.getDataCommand(sSqlHl, oConn).ExecuteNonQuery();
							}
						}
					}

				}
				//save attachments to qoute
				string delQA = "delete From SOLQA where FkDocNumber = '" + txtNumber.Text.Trim() + "'";
				int idel = Liquid.Classes.Connect.getDataCommand(delQA, oConn).ExecuteNonQuery();
				foreach (DataGridViewRow dgRow in dgAttachPicture.Rows)
				{
					if (dgRow.Cells["clFileName"].Value != null)
					{
						string sSqlQa = "Insert into SOLQA (FkDocNumber, Path) Values ('" + txtNumber.Text + "','" + dgRow.Cells["clFileName"].Value + "')";
						int iRetQa = Liquid.Classes.Connect.getDataCommand(sSqlQa, oConn).ExecuteNonQuery();
					}
				}                
				//save note to docnumber
				string delQn = "delete From SOLQN where FkDocNumber = '" + txtNumber.Text.Trim() + "'";
				int idelQn = Liquid.Classes.Connect.getDataCommand(delQn, oConn).ExecuteNonQuery();
				if (txtQouteNotes.Text != "")
				{
					string sSqlQn = "INSERT into SOLQN (FkDocNumber,Note) Values ('" + txtNumber.Text + "','" + txtQouteNotes.Text.Replace("'","''") + "')";
					int RetQn = Liquid.Classes.Connect.getDataCommand(sSqlQn, oConn).ExecuteNonQuery();
				}
				oConn.Dispose();
				loadQoute(txtNumber.Text);
			}        
		}

		private void cmdNewOrder_Click_1(object sender, EventArgs e)
		{
			((Main)this.MdiParent).LoadnewQoute(this);
		}

		private void cmdSearchNumber_Click_1(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.QouteZoom frmQouteZoom = new Finder.QouteZoom())
			{
				if (frmQouteZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmQouteZoom.sResult != "")
					{
						txtNumber.Text = frmQouteZoom.sResult.Trim();
						txtNumber.SelectionStart = 0;
						txtNumber.SelectionLength = txtNumber.Text.Length;
						loadQoute(txtNumber.Text);
						this.ActiveControl = txtNumber;					   
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

	   
		private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
		{
			
		   
		}

		private void txtNotes_KeyDown(object sender, KeyEventArgs e)
		{
			
			if (e.KeyValue == 13)
			{
				// Then Enter key was pressed
				txtNotes.Text = Environment.NewLine;
			}
		}

		private void cmdNewLine_Click_1(object sender, EventArgs e)
		{
			QouteLine qlNewline = new QouteLine();
			AddQouteLine(qlNewline,false);
			qlNewline.bNextLine = true;
			qlNewline.txtCode.Focus();
			qlNewline.bFocusOnNextLine = false;
		}

		private void cmdPrintQoute_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			Liquid.Classes.Generate.PrintQoute(txtNumber.Text,txtPostAd1.Text,txtPostAd2.Text,txtPostAd3.Text,txtPostAd4.Text, txtCustomerDescription.Text);
			Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			addTotals();
		}

		private void rbNew_CheckedChanged(object sender, EventArgs e)
		{
			grpStatus.BackColor = Color.SandyBrown;
		}

		private void rbAccepted_CheckedChanged(object sender, EventArgs e)
		{
			grpStatus.BackColor = Color.LimeGreen;
		}

		private void rbRejected_CheckedChanged(object sender, EventArgs e)
		{
			grpStatus.BackColor = Color.Red;
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will Change the status of this qoute to Accepted Permanently, Continue?","Chagne Status",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{

				using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
				{
					string sSql = "Update SOLQHH set Status =  1 where DocNumber = '" + txtNumber.Text.Trim() + "'";

					int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
					pnlStatus.BackColor = Color.LimeGreen;
					cmdAccept.Visible = false;
					cmdReject.Visible = false;
				}

			}

		   
		}

		private void cmdReject_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will Change the status of this qoute to Rejected Permanently, Continue?", "Change Status", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{

				using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
				{
					string sSql = "Update SOLQHH set Status = 2 where DocNumber = '" + txtNumber.Text.Trim() + "'";

					int Ret = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
					pnlStatus.BackColor = Color.Red;
					cmdAccept.Visible = false;
					cmdReject.Visible = false;
				}

			}
		 
			   
		}

		private void Qoute_Load(object sender, EventArgs e)
		{
			dgAttachPicture.Rows.Add();
		}

		private void dgAttachPicture_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgAttachPicture.Columns[e.ColumnIndex] == clAdd)
			{
				if (dgAttachPicture.Rows[e.RowIndex].Cells[0].Value == null)
				{
					OpenFileDialog ofdAtt = new OpenFileDialog();
					if (ofdAtt.ShowDialog() == DialogResult.OK)
					{
						dgAttachPicture.Rows[e.RowIndex].Cells[0].Value = ofdAtt.FileName;
					}
					dgAttachPicture.Rows.Add();
				}
				else
				{
					OpenFileDialog ofdAtt = new OpenFileDialog();
					if (ofdAtt.ShowDialog() == DialogResult.OK)
					{
						dgAttachPicture.Rows[e.RowIndex].Cells[0].Value = ofdAtt.FileName;
					}
				}
			}
			if (dgAttachPicture.Columns[e.ColumnIndex] == clDelete)
			{
				if (dgAttachPicture.Rows[e.RowIndex].Cells[0].Value != null)
				{
					dgAttachPicture.Rows.Remove(dgAttachPicture.Rows[e.RowIndex]);
				}
			 }

			if (dgAttachPicture.Columns[e.ColumnIndex] == clView)
			{
				if (dgAttachPicture.Rows[e.RowIndex].Cells[0].Value != null)
				{
					Process p = new Process();
					p.StartInfo.FileName = dgAttachPicture.Rows[e.RowIndex].Cells["clFileName"].Value.ToString().Trim();
					p.StartInfo.CreateNoWindow = true;
					p.Start();
				}
			}

			
		}

		private void cmdBrowseProject_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.ProjectZoom frmProjectZoom = new Finder.ProjectZoom())
			{
				if (frmProjectZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmProjectZoom.sResult != "")
					{
						txtProject.Text = frmProjectZoom.sResult.Trim();

					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void cmdSalesPerson_Click_1(object sender, EventArgs e)
		{
			using (Forms.VerifyUser frmVerify = new Liquid.Forms.VerifyUser())
			{
				if (frmVerify.ShowDialog() == DialogResult.OK)
				{
					txtSalesCode.Text = frmVerify.sUserCode;
				}
			}
		}

		private void txtNotes_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void txtQouteNotes_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void picEditAddress_Click(object sender, EventArgs e)
		{

		}

	  
		  
	}
}
