using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Liquid.Classes;
using Liquid.Domain;
using Liquid.Repository;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
	public partial class Inventory : Form
	{
		BindingSource bsInventory;
		public bool bLinkItem = false;
		public TextBox txtActive;
		
		public string sResult = "";
		public string sDescription = "";
		public string sQuoteNumber = "";
		public string sSelectedStoreCode = "";
		public string sProject = "";
		string sWorkshopAction = "";
		

		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();
		
		const int WM_KEYDOWN = 0x100;
		const int WM_SYSKEYDOWN = 0x104;

        public Inventory()
        {
            InitializeComponent();
            this.ActiveControl = txtCode;
        }

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

		public  DialogResult ShowDialog(string sStoreCode,string sWorkshopAct,string sProj)
		{
			sSelectedStoreCode = sStoreCode;
			sWorkshopAction = sWorkshopAct;
			
			if (sSelectedStoreCode == "")
			{
				sSelectedStoreCode = "All";
			}

			sProject = sProj;
			lblStoreValue.Text = sSelectedStoreCode;
			if (sProject.Trim() == "C")
			{
				cmdAddComment.Visible = true;
				sProject = "";
			}
			else if (sProject != "")
				cmdAddKit.Visible = true;
			
			return (this.ShowDialog());
		}

		

		private void Inventory_Load(object sender, EventArgs e)
		{
			txtActive = txtCode;

			txtCode.CharacterCasing = CharacterCasing.Upper;
			txtDescription.CharacterCasing = CharacterCasing.Upper;

			if (sSelectedStoreCode == "")
			{
				sSelectedStoreCode = "All";
				lblStoreValue.Text = sSelectedStoreCode;
			}

			loadInventoryGrid();			
		}

        

        private void loadInventoryGrid()
		{
           /* var inventoryRepo = new InventoryRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            var inventoryData = inventoryRepo.getInventoryManagerData();
            buildDataGrid(dgInventory, inventoryData);*/

            //dgInventory.Rows.Clear();	
            bool bBlockedCodes = false;
			if (sProject == "")
			{
                //get blocked codes
                string sBlockedCodes = "(";
                try
                {
                    using (PsqlConnection oConnSql = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
                    {
                        String sSql2 = "Select ItemCode From SOLIM";
                        PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql2, oConnSql).ExecuteReader();
                        while (rdReader.Read())
                        {
                            sBlockedCodes += "'" + rdReader["ItemCode"].ToString().Trim() + "',";
                            bBlockedCodes = true;
                        }
                        oConnSql.Dispose();
                    }
                    int iLength = sBlockedCodes.Length;
                    sBlockedCodes = sBlockedCodes.Remove(iLength - 1);
                    sBlockedCodes += ")";
                }
                catch
                {
                    MessageBox.Show("Error Loading Blocked Itemcodes from database, please contact administrator");
                }

                if (bBlockedCodes == false)
                    sBlockedCodes = "('')";

				PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
				oConn.Open();
				string sSql = "SELECT DISTINCT Inventory.ItemCode,IF(LnkCode = '','true','false') 'clKit', Description, UserDefText01, UserDefText02, UserDefText03, LnkCode from Inventory ";
				sSql += " INNER JOIN MultiStoreTrn ON Inventory.ItemCode = MultiStoreTrn.ItemCode ";
				sSql += " LEFT JOIN LinkHeader ON Inventory.ItemCode = LinkHeader.LnkCode ";
				sSql += " WHERE (Inventory.ItemCode Not In " + sBlockedCodes + ") AND (MultiStoreTrn.StoreCode = '" + sSelectedStoreCode + "' OR '" + sSelectedStoreCode + "' = 'All') AND (Inventory.ItemCode LIKE '%" + txtCode.Text + "%' OR '" + txtCode.Text + "' = '') ";
				 sSql += " AND (UPPER(Description) LIKE '%" + txtDescription.Text + "%' OR '" + txtDescription.Text + "' = '') ";

				if (chkKitItem.Checked)
				{
					sSql += " AND(LnkCode != '') ";
				}

				if (sWorkshopAction == "InWorkshop")
				{
					sSql += " AND UserDefNum01 = 1 AND UserDefText01 = ''";
				}

				if (sWorkshopAction == "AssetLocationReport")
				{
					sSql += " AND UserDefNum01 = 1 ";
				}

				if (sWorkshopAction == "OutWorkshop")
				{
					sSql += " AND UserDefText01 = 'WORKSHOP'";
				}

				if (sProject != "")
				{
					if (sProject.Substring(0, 2) == "PS") //picking slip
					{
						sProject = sProject.Remove(0, 2);
						sProject = sProject.Remove(1, 1) + ")";
						string sLinkedItemCodes = "(";
						using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
						{
							string sSqlLiq = "select Itemcode from SOLPDL where DocNumber in " + sProject;
							sSqlLiq += " group by Itemcode";
							PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSqlLiq, oConnLiq).ExecuteReader();
							while (rdReader.Read())
							{
								sLinkedItemCodes += ",'" + rdReader["ItemCode"].ToString().Trim() + "'";
							}
							sLinkedItemCodes = sLinkedItemCodes.Remove(1, 1);
							sLinkedItemCodes = sLinkedItemCodes + ")";
						}
						sSql += "AND Inventory.ItemCode in " + sLinkedItemCodes;

					}
					else if (sProject.Substring(0, 2) == "RN") //retutrn note
					{
						sProject = sProject.Substring(2, 8);
						string sLinkedItemCodes = "(";
						using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
						{
							string sSqlLiq = "select Itemcode from SOLPDL where DocNumber = '" + sProject + "'";
							sSqlLiq += " group by Itemcode";
							PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSqlLiq, oConnLiq).ExecuteReader();
							while (rdReader.Read())
							{
								sLinkedItemCodes += ",'" + rdReader["ItemCode"].ToString().Trim() + "'";
							}
							sLinkedItemCodes = sLinkedItemCodes.Remove(1, 1);
							sLinkedItemCodes = sLinkedItemCodes + ")";
						}
						sSql += "AND Inventory.ItemCode in " + sLinkedItemCodes;
					}
					else //del note
					{
						string sLinkedItemCodes = "(";
						using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
						{
							string sSqlLiq = "select SOLQHL.Itemcode from SOLQHH";
							sSqlLiq += " inner join SOLQHL on SOLQHL.DocNumber = SOLQHH.DocNumber";
							sSqlLiq += " where SOLQHH.Project ='" + sProject + "'";
							sSqlLiq += " group by SOLQHL.Itemcode";
							PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSqlLiq, oConnLiq).ExecuteReader();
							while (rdReader.Read())
							{
								if (rdReader["ItemCode"].ToString().Trim() != "'")
									sLinkedItemCodes += ",'" + rdReader["ItemCode"].ToString().Trim() + "'";
							}
							sLinkedItemCodes = sLinkedItemCodes.Remove(1, 1);
							sLinkedItemCodes = sLinkedItemCodes + ")";
						}
						sSql += "AND Inventory.ItemCode in " + sLinkedItemCodes;
					}
				}
				sSql += " ORDER BY Inventory.ItemCode ";
				dgInventory.AutoGenerateColumns = false;
				DataSet dsAvailInventory = Liquid.Classes.Connect.getDataSet(sSql, "Inventory", oConn);
				bsInventory = new BindingSource();
				bsInventory.DataSource = dsAvailInventory;
				bsInventory.DataMember = dsAvailInventory.Tables[0].TableName;
				dgInventory.DataSource = bsInventory;

				oConn.Dispose();
				dgInventory.Focus();
				//txtCode.Focus();
			}
			else
			{
				using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
				{
					string sSqlLiq = "select SOLQHL.Itemcode,SOLQHL.Description, SOLQHL.DocNumber, IF(Qty = '','false','false') 'clKit' from SOLQHH";
					sSqlLiq += " inner join SOLQHL on SOLQHL.DocNumber = SOLQHH.DocNumber";
					sSqlLiq += " where SOLQHH.Project ='" + sProject + "' AND ItemCode <> ''''";
					
					dgInventory.AutoGenerateColumns = false;
					DataSet dsAvailInventory = Liquid.Classes.Connect.getDataSet(sSqlLiq, "Inventory", oConnLiq);
					bsInventory = new BindingSource();
					bsInventory.DataSource = dsAvailInventory;
					bsInventory.DataMember = dsAvailInventory.Tables[0].TableName;
					dgInventory.DataSource = bsInventory;
					oConnLiq.Dispose();
					txtCode.Focus();
				}              
			}
        }
		
		private void dgInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			sResult = dgInventory.SelectedRows[0].Cells[0].Value.ToString();
			sDescription = dgInventory.SelectedRows[0].Cells[1].Value.ToString();
			//sQuoteNumber = dgInventory.SelectedRows[0].Cells[3].Value.ToString();
			//if (dgInventory.SelectedRows[0].Cells["clKit"].Value.ToString() == "True")
			//{
			//    bLinkItem = true;
			//}
			//else
			//{
			//    bLinkItem = false;
			//}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dgInventory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				//LL Phalaborwa if
				if (dgInventory.Rows.Count > 0)
				{
					sResult = dgInventory.SelectedRows[0].Cells[0].Value.ToString();
					sDescription = dgInventory.SelectedRows[0].Cells[1].Value.ToString();
					//sQuoteNumber = dgInventory.SelectedRows[0].Cells[3].Value.ToString();
					if (dgInventory.SelectedRows[0].Cells["clKit"].Value.ToString() == "True")
					{
						bLinkItem = true;
					}
					else
					{
						bLinkItem = false;
					}
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					
				}
			}			
		}
				
		private void cmdInventorySearch_Click(object sender, EventArgs e)
		{
			loadInventoryGrid();
		}

		private void txtCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadInventoryGrid();
			}

			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				dgInventory.Focus();
			}
			
		}

		private void chkKitItem_KeyDown(object sender, KeyEventArgs e)
		{   
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				loadInventoryGrid();
			}
			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				//dgInventory.Focus();
			}            
		}

		private void dgInventory_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\t' && e.KeyChar != '\b')
				txtActive.Text += e.KeyChar.ToString();

			txtActive.Focus();

			txtActive.SelectionStart = txtCode.Text.Length;
			txtActive.SelectionLength = 0;				
		}

		private void txtCode_TextChanged(object sender, EventArgs e)
		{
            if(txtDescription.Text.Trim() != "")
				bsInventory.Filter = "Description LIKE '%" + txtDescription.Text.Replace("'", "''") + "%' AND ItemCode LIKE '%" + txtCode.Text.Replace("'", "''") + "%'";
			else
				bsInventory.Filter = "ItemCode LIKE '%" + txtCode.Text.Replace("'","''") + "%'";
            }

		private void txtDescription_TextChanged(object sender, EventArgs e)
		{
			if(txtCode.Text.Trim() != "")
				bsInventory.Filter = "ItemCode LIKE '%" + txtCode.Text.Replace("'", "''") + "%' AND Description LIKE '%" + txtDescription.Text.Replace("'", "''") + "%'";
			else
				bsInventory.Filter = "Description LIKE '%" + txtDescription.Text.Replace("'", "''") + "%'";
		}

		private void txtCode_Enter(object sender, EventArgs e)
		{
			txtActive = (TextBox) sender;
		}

		private void cmdAddComment_Click(object sender, EventArgs e)
		{
			sResult = "'";
			sDescription = "";          
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		  
		}

		private void cmdAddKit_Click(object sender, EventArgs e)
		{

		}
	
	}
}