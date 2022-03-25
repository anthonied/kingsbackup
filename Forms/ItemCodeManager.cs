using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Forms
{
    public partial class ItemCodeManager : Form
    {
        public ItemCodeManager()
        {
            InitializeComponent();
        }

        private void ItemCodeManager_Load(object sender, EventArgs e)
        {         
            LoadBlockedCodes();
            LoadActiveCodes();
        }

        private void LoadActiveCodes()
        {
            //get blocked codes
            lbBlockedItems.Items.Clear();
            lbBlockedItems.ItemHeight = 200;
            string sBlockedCodes = "(";

            using (PsqlConnection oConnSql = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                String sSql = String.Format("Select ItemCode From SOLIM where ItemCode like '%{0}%'", txtFilterBlockedCodes.Text.Trim());
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConnSql).ExecuteReader();
                while (rdReader.Read())
                {
                    lbBlockedItems.Items.Add(rdReader["ItemCode"].ToString().Trim());
                    sBlockedCodes += String.Format("'{0}',", rdReader["ItemCode"].ToString().Trim());
                }
                oConnSql.Dispose();
            }
            int iLength = sBlockedCodes.Length;
            sBlockedCodes = sBlockedCodes.Remove(iLength - 1);
            sBlockedCodes += ")";
            if (sBlockedCodes.Substring(0, 1) == ")")
            {
                sBlockedCodes = "('')";
            }
           lbActiveItems.Items.Clear();   
            lbActiveItems.ItemHeight = 200;

            using (PsqlConnection oConnPas = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                String sSql = "Select ItemCode From Inventory where ItemCode like '%" + txtFilterActiveCodes.Text.Trim() + "%' AND ItemCode not in " + sBlockedCodes;
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConnPas).ExecuteReader();
                while (rdReader.Read())
                {
                    lbActiveItems.Items.Add(rdReader["ItemCode"].ToString());
                }
                oConnPas.Dispose();
            }
            
        }

        private void LoadBlockedCodes()
        {
            
           
        }

        private void txtFilterActiveCodes_TextChanged(object sender, EventArgs e)
        {
            LoadActiveCodes();
        }

        private void txtFilterBlockedCodes_TextChanged(object sender, EventArgs e)
        {
            LoadActiveCodes();
        }

        private void lbActiveItems_DoubleClick(object sender, EventArgs e)
        {
            lbBlockedItems.Items.Add(lbActiveItems.SelectedItem);
            
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                //insert item into SOLIM
                string sSql = "Insert into SOLIM (ItemCode) Values ('" + lbActiveItems.SelectedItem.ToString().Trim() + "')";
                int iRet2 = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                oConn.Dispose();
            }
            lbActiveItems.Items.Remove(lbActiveItems.SelectedItem);
           
        }

        private void ConsolidateBoxes()
        {
            foreach (string item in lbActiveItems.Items)
            {
                foreach (string itemBlocked in lbBlockedItems.Items)
                {
                    if (item == itemBlocked)
                    {
                        lbActiveItems.Items.Remove(item);

                    }
                }
            }

        }

        private void lbBlockedItems_DoubleClick(object sender, EventArgs e)
        {
            lbActiveItems.Items.Add(lbBlockedItems.SelectedItem);

            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                oConn.Open();
                //insert item into SOLIM
                string sSql = "Delete from SOLIM where ItemCode = '" + lbBlockedItems.SelectedItem.ToString().Trim() + "'";
                int iRet2 = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                oConn.Dispose();
            }
            lbBlockedItems.Items.Remove(lbBlockedItems.SelectedItem);
        }
    }


}
