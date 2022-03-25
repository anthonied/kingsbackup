using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;
using Liquid.Repository;
using Liquid.Domain;

namespace Liquid.Forms
{

	
	public partial class ContactDetails : Form
	{
		public string sCustomerKey = "";

		public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();

		public DialogResult ShowDialog(string sCustomerCode, string sCustomerName, string DelAd1, string DelAd2, string DelAd3, string DelAd4)
		{
			lblHeading.Text = sCustomerCode + " - " + sCustomerName;
			sCustomerKey = sCustomerCode;
			txtAd1.Text = DelAd1.Trim();
			txtAd2.Text = DelAd2.Trim();
			txtAd3.Text = DelAd3.Trim();
			txtAd4.Text = DelAd4.Trim();
		    //selAddresses.SelectedIndex = 0;
			return this.ShowDialog();
		}
		public ContactDetails()
		{
			InitializeComponent();
		}

		//LL Phalaborwa
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
				case "txtDescription":
					txtAd1.Focus();
					break;
				case "txtAd1":
					txtAd2.Focus();
					break;
				case "txtAd2":
					txtAd3.Focus();
					break;
				case "txtAd3":
					txtAd4.Focus();
					break;
				case "txtAd4":
					txtAd5.Focus();
					break;
				case "txtAd5":
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
					cmdSave.Focus();
					break;
				case "cmdSave":
					cmdSave_Click(null,null);
					break;
			}
		}
		//LL

		private void ContactDetails_Load(object sender, EventArgs e)
		{
		    using (var repo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
		    {
		        var custAddressHeaders = repo.GetByCustomerCode(sCustomerKey.Trim());
                custAddressHeaders.ForEach(custAddressHeader =>
                {
                    string sAddressLine = custAddressHeader.AddressHeader;
                    if (sAddressLine == "")
                    {
                        sAddressLine = "Main [" + custAddressHeader.CustDelivCode + "]";
                    }
                    else
                    {
                        sAddressLine += " [" + custAddressHeader.CustDelivCode + "]";
                    }
                    selAddresses.Items.Add(sAddressLine);
                });
		    }
		    
            /*
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConn.Open();
			string sSql = "select * from DeliveryAddresses ";
			sSql += "where CustomerCode = '" + sCustomerKey.Trim() +"'";
			sSql += " and  ltrim(rtrim(CustDelivCode)) <> ''";
			sSql += " order by CustDelivCode ";
			selAddresses.SelectedIndex = 0;
			PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
			while (rdReader.Read())
			{
				string sAddressLine = rdReader["Spare"].ToString().Trim();
				if (sAddressLine == "")
				{
					sAddressLine = "Main [" + rdReader["CustDelivCode"].ToString().Trim() + "]";

				}
				else
				{
					sAddressLine += " [" + rdReader["CustDelivCode"].ToString().Trim() + "]";
				}
				selAddresses.Items.Add(sAddressLine);				
			}
			rdReader.Close();
			oConn.Dispose();
            */

		   


			this.selAddresses.SelectedIndexChanged += new System.EventHandler(this.selAddresses_SelectedIndexChanged);
            selAddresses.SelectedIndex = 0;
        }

		private void selAddresses_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtMarketer.Text = "";
			txtCategory.Text = "";
			txtCommissionFloor.Text = "";
			if (selAddresses.Text != "* NEW *")
			{
				string sCode = selAddresses.Text.Substring(selAddresses.Text.IndexOf("[") + 1, selAddresses.Text.Length - (selAddresses.Text.IndexOf("[") + 1)).Replace("]", "");
				//get sales name
				string[] aKeyValuesAdd = new string[5];
				aKeyValuesAdd[0] = sCustomerKey;
				aKeyValuesAdd[1] = sCode;
				string[] aAddressInfo = clsSDK.Read_Record("ACCDELIV", 4, 0, aKeyValuesAdd,Global.sDataPath).Split("|".ToCharArray());
				txtContact.Text = aAddressInfo[4].Trim().Replace("~", "'");
				txtTelephone.Text = aAddressInfo[5].Trim();
				txtMobile.Text = aAddressInfo[6].Trim();
				txtFax.Text = aAddressInfo[7].Trim();
				txtAd1.Text = aAddressInfo[8].Trim().Replace("~", "'");
				txtAd2.Text = aAddressInfo[9].Trim().Replace("~", "'");
				txtAd3.Text = aAddressInfo[10].Trim().Replace("~", "'");
				txtAd4.Text = aAddressInfo[11].Trim().Replace("~", "'");
				txtAd5.Text = aAddressInfo[12].Trim().Replace("~", "'");
				txtEmail.Text = aAddressInfo[13].Trim();

			    using (var repo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
			    {
			        var header = repo.GetByCustomerCodeAndDelivCode(sCustomerKey , sCode);
                    if (header.AddressHeader.Trim() == "")
                    {
                        txtDescription.Text = "Main" + header.AddressHeader.Trim().Replace("|", "'");
                    }
                    else
                    {
                        txtDescription.Text = header.AddressHeader.Trim().Replace("|", "'");
                    }
                }

                /*
				if (aAddressInfo[14].Trim() == "")
				{
					txtDescription.Text = "Main" + aAddressInfo[2].Trim().Replace("|", "'");
				}
				else
				{
					txtDescription.Text = aAddressInfo[14].Trim().Replace("|", "'");
				}*/
				txtAddNumber.Text = aAddressInfo[2].Trim();

				//get marketing details
				using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
				{
					oConnLiq.Open();
					String sSqlLiq = "Select Marketer,CommissionFloor, MarketingCategory From SOLMARKCUSTDET where CustomerCode = '" + lblHeading.Text.Trim().Substring(0, 6) + "' AND SiteName = '" + selAddresses.Text.Trim() + "'";
					PsqlDataReader rdReaderLiq = Liquid.Classes.Connect.getDataCommand(sSqlLiq, oConnLiq).ExecuteReader();
					while (rdReaderLiq.Read())
					{
						txtMarketer.Text = rdReaderLiq[0].ToString();
						txtCommissionFloor.Text = rdReaderLiq[1].ToString();
						txtCategory.Text = rdReaderLiq[2].ToString();
					}
					rdReaderLiq.Dispose();
					oConnLiq.Dispose();
				}
			}
			else
			{
			    clearForm();
			}
			//if (selAddresses.Items[0].ToString() == "* NEW *")
			//{
			//    selAddresses.Items.RemoveAt(0);
			//}			
			
		}

		private void txtAd1_TextChanged(object sender, EventArgs e)
		{
			cmdSave.Enabled = true;
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{

			if (txtDescription.Text == "")
			{
				MessageBox.Show("Please supply a description for this contact info.", "No Description Provided", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString);
			oConn.Open();
			string sSql = "";

            var deliveryAddress = new DeliveryAddress
            {
                CustomerCode = sCustomerKey,
                SalesmanCode = "",
                Contact = txtContact.Text.Replace("'", "~"),
                Telephone = txtTelephone.Text,
                Cell = txtMobile.Text,
                Fax = txtFax.Text.Replace("'", "~"),
                DelAddress01 = txtAd1.Text.Replace("'", "~"),
                DelAddress02 = txtAd2.Text.Replace("'", "~"),
                DelAddress03 = txtAd3.Text.Replace("'", "~"),
                DelAddress04 = txtAd4.Text.Replace("'", "~"),
                DelAddress05 = txtAd5.Text.Replace("'", "~"),
                EmailAddress = txtEmail.Text,
                ContactDocs = "",
                ContactStatement = "",
                EmailStatement = ""
            };

            var success = false;

            if (selAddresses.Text.Trim() == "* NEW *") //insert
			{
				sSql = "select max(CAST(CustDelivCode as integer)) from DeliveryAddresses ";
				sSql += " where CustomerCode = '"+ sCustomerKey +"' ";
				string sRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
				if (sRet.Trim() == "")
				{
					sRet = "1";
				}
				else
				{
					sRet = (Convert.ToInt32(sRet) + 1).ToString();
				}
                /*
				sSql = "INSERT into DeliveryAddresses ";
				sSql += "(CustomerCode, CustDelivCode, SalesmanCode, Contact, Telephone, Cell, Fax,DelAddress01, DelAddress02, DelAddress03,DelAddress04,DelAddress05, Email, Spare)";
				sSql += " VALUES ";
				sSql += "(";
				sSql +=  "'" + sCustomerKey + "'";
				sSql += ",'" + sRet+ "'";
				sSql += ",''"; //Salemanscode
				sSql += ",'" + txtContact.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtTelephone.Text + "'";
				sSql += ",'" + txtMobile.Text + "'";
				sSql += ",'" + txtFax.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtAd1.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtAd2.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtAd3.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtAd4.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtAd5.Text.Replace("'", "~") + "'";
				sSql += ",'" + txtEmail.Text + "'";
				sSql += ",'" + txtDescription.Text.Replace("'", "~") + "'";
				sSql += ")";
                */
                
                using (var deliveryAddressRepo = new DeliveryAddressesRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                using (var custAddressHeaderRepo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                {
                    deliveryAddress.CustDelivCode = int.Parse(sRet);

                    success = deliveryAddressRepo.Create(deliveryAddress);

                    if (success)
                    {
                        var addressHeader = new CustomerAddressHeader
                        {
                            CustomerCode = deliveryAddress.CustomerCode,
                            CustDelivCode = deliveryAddress.CustDelivCode,
                            AddressHeader = txtDescription.Text.Replace("'", "~")
                        };

                        success = custAddressHeaderRepo.Create(addressHeader);
                    }


                }
                txtAddNumber.Text = sRet;
				
			}
			else
			{
                /*
				sSql = "UPDATE DeliveryAddresses SET ";
				sSql += " Contact = '" + txtContact.Text.Replace("'", "~") + "'";
				sSql += ", Telephone = '" + txtTelephone.Text + "'";
				sSql += ", Cell = '" + txtMobile.Text + "'";
				sSql += ", Fax = '" + txtFax.Text + "'";
				sSql += ", DelAddress01 = '" + txtAd1.Text.Replace("'","~") + "'";
				sSql += ", DelAddress02 = '" + txtAd2.Text.Replace("'", "~") + "'";
				sSql += ", DelAddress03 = '" + txtAd3.Text.Replace("'", "~") + "'";
				sSql += ", DelAddress04 = '" + txtAd4.Text.Replace("'", "~") + "'";
				sSql += ", DelAddress05 = '" + txtAd5.Text.Replace("'", "~") + "'";
				sSql += ", Email = '" + txtEmail.Text + "'";
				sSql += ", Spare = '" + txtDescription.Text.Replace("'", "~") + "'";
				sSql += " WHERE CustomerCode = '" + sCustomerKey + "'";
				sSql += " and CustDelivCode = '" + txtAddNumber.Text + "'";*/
                using (var deliveryAddressRepo = new DeliveryAddressesRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                using (var custAddressHeaderRepo = new CustAddressHeaderRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString))
                {
                    deliveryAddress.CustDelivCode = int.Parse(txtAddNumber.Text);
                    success = deliveryAddressRepo.Update(deliveryAddress);

                    if (success)
                    {
                        var addressHeader = new CustomerAddressHeader
                        {
                            CustomerCode = deliveryAddress.CustomerCode,
                            CustDelivCode = deliveryAddress.CustDelivCode,
                            AddressHeader = txtDescription.Text.Replace("'", "~")
                        };
                        success = custAddressHeaderRepo.Update(addressHeader);
                    }
                }


            }

            if(success)
            {
                cmdSave.Enabled = false;
            }
            else
            {
                throw new Exception("An error occured saving this record");
            }
			/*int iRet = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
			if (iRet == 1)
			{
				cmdSave.Enabled = false;
			}
			else
			{
				throw new Exception("An error occured saving this record");
			}*/
			

			oConn.Dispose();
			//save marketer details
			using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
			{
				//oConnLiq.Open();
				//string sMarketingCategory = "";
				//string sCommissionFloor = txtCommissionFloor.Text.Trim();
				//String sSqlGetDet = "Select MarketingCategory,CommissionFloor From SOLMARKCUSTDET where CustomerCode = '" + lblHeading.Text.Trim().Substring(0, 6) + "'";
				//PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSqlGetDet, oConnLiq).ExecuteReader();
				//while (rdReader.Read())
				//{
				//    sMarketingCategory = rdReader[0].ToString();
				//    if (sCommissionFloor == "")
				//        sCommissionFloor = rdReader[1].ToString();
				//}
				//rdReader.Dispose();				
				string delSql = "delete From SOLMARKCUSTDET where SiteName  = '" + selAddresses.Text.Trim() + "'";
				int delRet = Liquid.Classes.Connect.getDataCommand(delSql, oConnLiq).ExecuteNonQuery();

				string sSqlLiq = "Insert Into SOLMARKCUSTDET (CustomerCode,MarketingCategory,CommissionFloor,Marketer,SiteName)";
				sSqlLiq += " Values ('" + lblHeading.Text.Trim().Substring(0, 6) + "','" + txtCategory.Text.Trim() + "','" + txtCommissionFloor.Text.Trim().Replace(",","") + "','" + txtMarketer.Text.Trim() + "','" + selAddresses.Text.Trim() + "')";

				int iReturn = Liquid.Classes.Connect.getDataCommand(sSqlLiq, oConnLiq).ExecuteNonQuery();
				oConnLiq.Dispose();
				
			}


			this.Close();
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{
			clearForm();
			
		}

		private void clearForm()
		{
			txtAddNumber.Text = "";
			txtDescription.Text = "";
			txtAd1.Text = "";
			txtAd2.Text = "";
			txtAd3.Text = "";
			txtAd4.Text = "";
			txtAd5.Text = "";
			txtContact.Text = "";
			txtTelephone.Text = "";
			txtFax.Text = "";
			txtMobile.Text = "";
			txtEmail.Text = "";
			cmdSave.Enabled = false;
			selAddresses.SelectedIndex = 0;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdMarketerSearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.MarketerZoom frmMarkZoom = new Finder.MarketerZoom())
			{
				if (frmMarkZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmMarkZoom.sMarketerCode != "")
					{
						txtMarketer.Text = frmMarkZoom.sMarketerCode.Trim();

					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

		private void txtCommissionFloor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				txtCommissionFloor.Text = Convert.ToDecimal(txtCommissionFloor.Text).ToString("N2");

			}
			catch
			{
				MessageBox.Show("CommissionPercentage Floor input not correct, Please specify Floor Amount");
			}
		}

		private void cmdCategorySearch_Click(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.WaitCursor;
			using (Finder.MarketingCategoryZoom frmMarkCatZoom = new Finder.MarketingCategoryZoom())
			{
				if (frmMarkCatZoom.ShowDialog() == DialogResult.OK)
				{
					if (frmMarkCatZoom.sResult != "")
					{
						txtCategory.Text = frmMarkCatZoom.sResult.Trim();
					}
				}
				Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

  
		
			 
	 
}
}