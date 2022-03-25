using System;
using System.Drawing;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Forms
{
    public partial class RuleSetup : Form
    {
        public RuleSetup()
        {
            InitializeComponent();
            LoadSpecRules();
        }

        #region LOADS + DEFAULTS

        //Populate Special Rules Dropdown
        public void LoadSpecRules()
        {
            selSpecialRule.Items.Clear();

            selSpecialRule.Items.Add("Weekly");
        }

        public void LoadRule(string sRuleID)
        {
            dgvRuleParameters.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                string sLoadSql = "SELECT * FROM SOLRM WHERE PKiRuleID = '" + sRuleID + "'";

                PsqlDataReader rdReader = Connect.getDataCommand(sLoadSql, oConn).ExecuteReader();

                while (rdReader.Read())
                {
                    txtRuleID.Text = rdReader["PKiRuleID"].ToString();
                    txtRuleName.Text = rdReader["sRuleName"].ToString();
                    txtRuleDesc.Text = rdReader["sRuleDescription"].ToString();
                    txtRuleUnit.Text = rdReader["SRuleUnit"].ToString();

                    if (rdReader["FKiSpecialRule"].ToString() != "")
                    {
                        string sSpecRuleName = rdReader["FKiSpecialRule"].ToString();
                        chkSpecialEvent.Checked = true;
                        selSpecialRule.Text = sSpecRuleName;
                    }
                    else
                    {
                        chkSpecialEvent.Checked = false;
                        selSpecialRule.Text = "";
                    }
                    if (rdReader["bDayOrDate"].ToString() == "1")
                        chkDayOrDate.Checked = true;
                    else
                        chkDayOrDate.Checked = false;
                }

                LoadRulePropertiesDGV(sRuleID);
            }
        }

        public void LoadRulePropertiesDGV(string sRuleID)
        {
            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                string sLoadSql = "SELECT * FROM SOLRP WHERE FKiRuleID = '" + sRuleID + "'";

                PsqlDataReader rdReader = Connect.getDataCommand(sLoadSql, oConn).ExecuteReader();

                while (rdReader.Read())
                {
                    dgvRuleParameters.Rows.Add(rdReader["iBeginVal"].ToString(), "", rdReader["iEndVal"].ToString(), rdReader["dCalcPercentage"].ToString(), rdReader["PKiRParameterID"].ToString(), rdReader["dReturnCalcPercentag"].ToString());
                }
            }
        }


        #endregion

        private void chkSpecialEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialEvent.Checked)
                selSpecialRule.Enabled = true;
            else
                selSpecialRule.Enabled = false;
        }

        
        private void btnAddPropertyRow_Click(object sender, EventArgs e)
        {
            if(ValidateDGV())
                dgvRuleParameters.Rows.Add();            
        }

        private void dgvRuleParameters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dgvRuleParameters_KeyPress);  
        }

        private void dgvRuleParameters_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar.ToString() != "\b" && e.KeyChar != '.')            
                e.Handled = true;

            if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnRemovePropertyRow_Click(object sender, EventArgs e)
        {
            if(dgvRuleParameters.CurrentCell != null)
                dgvRuleParameters.Rows.RemoveAt(dgvRuleParameters.CurrentCell.RowIndex);         
        }

        private void btnSaveRule_Click(object sender, EventArgs e)
        {
            #region VALIDATIONS
            //Do Validations
            if (txtRuleName.Text == String.Empty)
            {
                MessageBox.Show("Please Complete Rule Name");
                txtRuleName.Focus();
                return;
            }
            using (PsqlConnection oConnTest = new PsqlConnection(Connect.LiquidConnectionString))
            {
                oConnTest.Open();
                string sSqlTest = "select * from SOLRM where sRuleName = '" + txtRuleName.Text.Trim() + "'";

                PsqlDataReader rdReaderTest = Liquid.Classes.Connect.getDataCommand(sSqlTest, oConnTest).ExecuteReader();
                int iLineCounter = 0;
                while (rdReaderTest.Read())
                {
                    iLineCounter++;
                }
                rdReaderTest.Close();
                oConnTest.Dispose();

                if (iLineCounter > 0 && txtRuleID.Text == "*NEW*")
                {
                    MessageBox.Show("A rule whith the name '" + txtRuleName.Text + "' already exists. Please ensure that the rule name is unique.");
                    return;

                }
            }

            if (chkSpecialEvent.Checked)
            {
                if (selSpecialRule.SelectedIndex < 0)
                {
                    MessageBox.Show("Please Select Special Rule");
                    selSpecialRule.Focus();
                    return;
                }
            }

            if (dgvRuleParameters.Rows.Count < 1 && !chkSpecialEvent.Checked)
            {
                MessageBox.Show("Please Add Rule Parameters");
                return;
            }

            if (!ValidateDGV())
            {
                return;
            }

            #endregion

            else
            {
                if (txtRuleID.Text == "*NEW*")
                    SaveRule();
                else
                    UpdateRule();
            }
        }

        #region SAVES/UPDATES

        private void SaveRule()
        {
            string sRuleID = "";
            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                string sSql = "INSERT INTO SOLRM (sRuleName,sRuleDescription,FKiSpecialRule,sRuleUnit, bDayOrDate) VALUES ";
                sSql += "('" +txtRuleName.Text.Trim() +"',"; 
                sSql += "'" +txtRuleDesc.Text.Trim() +"',";

                if (chkSpecialEvent.Checked)
                {
                    string sSpecialRuleID = selSpecialRule.SelectedItem.ToString();
                    sSql += "'" + sSpecialRuleID +"'";
                }
                else
                    sSql += "0";

                sSql += ",'" + txtRuleUnit.Text.Trim() + "',";
                if (chkDayOrDate.Checked)                
                    sSql += "1";                
                else
                    sSql += "0";

                sSql += ")";
                
                int iReturn = Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                if (iReturn == 1)
                {
                    sSql = "SELECT @@identity FROM SOLRM";
                    sRuleID = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
                    
                    foreach (DataGridViewRow dgvRow in dgvRuleParameters.Rows)
                    {
                        string sRPSql = "INSERT INTO SOLRP (iBeginVal,iEndVal,dCalcPercentage,dReturnCalcPercentag,FKiRuleID) VALUES ";
                        sRPSql += "(" +dgvRow.Cells["colDayValBegin"].Value +",";
                        sRPSql += dgvRow.Cells["colDayValEnd"].Value +",";
                        sRPSql += dgvRow.Cells["colPMTPercentage"].Value +",";
                        sRPSql += dgvRow.Cells["clReturnPeriod"].Value + ",";
                        sRPSql += sRuleID + ")";

                        int iReturnRP = Connect.getDataCommand(sRPSql, oConn).ExecuteNonQuery();
                    }

                    txtRuleID.Text = sRuleID;
                    MessageBox.Show("Rule Successfuly Added");
                }
            }
        }

        public void UpdateRule()
        {
            string sRuleID = txtRuleID.Text;
            using (PsqlConnection oConn = new PsqlConnection(Connect.LiquidConnectionString))
            {
                string sSql = "UPDATE SOLRM SET sRuleName = '" +txtRuleName.Text.Trim() +"',";
                sSql += " sRuleDescription = '" +txtRuleDesc.Text.Trim() +"'";

                if (chkSpecialEvent.Checked)
                {
                    string sSpecialRuleID = selSpecialRule.SelectedItem.ToString();
                    sSql += ",FKiSpecialRule = '" + sSpecialRuleID + "'";
                }
                else
                {
                    sSql += ",FKiSpecialRule = '' ";
                }
                if (chkDayOrDate.Checked)
                    sSql += ",bDayOrDate = 1";
                else
                    sSql += ",bDayOrDate = 0";

                sSql += ",SRuleUnit = '" + txtRuleUnit.Text + "' ";

                sSql += " WHERE PKiRuleID = " + sRuleID;

                int iReturn = Connect.getDataCommand(sSql, oConn).ExecuteNonQuery();
                if (iReturn == 1)
                {
                    string sDelSql = "DELETE FROM SOLRP WHERE FKiRuleID = " + sRuleID;
                    int iDelReturnRP = Connect.getDataCommand(sDelSql, oConn).ExecuteNonQuery();

                    foreach (DataGridViewRow dgvRow in dgvRuleParameters.Rows)
                    {
                        string sRPSql = "INSERT INTO SOLRP (iBeginVal,iEndVal,dCalcPercentage,dReturnCalcPercentag,FKiRuleID) VALUES ";
                        sRPSql += "(" + dgvRow.Cells["colDayValBegin"].Value + ",";
                        sRPSql += dgvRow.Cells["colDayValEnd"].Value + ",";
                        sRPSql += dgvRow.Cells["colPMTPercentage"].Value + ",";
                        sRPSql += dgvRow.Cells["clReturnPeriod"].Value + ",";
                        sRPSql += sRuleID + ")";


                        int iReturnRP = Connect.getDataCommand(sRPSql, oConn).ExecuteNonQuery();
                    }
                    
                    MessageBox.Show("Rule Successfuly Updated");
                }
            }
        }

        #endregion

        //public string FetchSpecialRuleID(string sRuleName)
        //{
        //    string sSpecRuleID = "";
        //    using (PsqlConnection oConn = new PsqlConnection(Connect.sConnStr))
        //    {
        //        string sSql = "SELECT PKiRuleID FROM SOLRM WHERE sRuleName = '" + sRuleName + "'";
        //        sSpecRuleID = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
        //    }

        //    return sSpecRuleID;
        //}


        //public string FetchSpecialRuleName(string sRuleID)
        //{
        //    string sSpecRuleName = "";
        //    using (PsqlConnection oConn = new PsqlConnection(Connect.sConnStr))
        //    {
        //        string sSql = "SELECT sRuleName FROM SOLRM WHERE PKiRuleID = '" + sRuleID + "'";
        //        sSpecRuleName = Connect.getDataCommand(sSql, oConn).ExecuteScalar().ToString();
        //    }

        //    return sSpecRuleName;
        //}

        public bool ValidateDGV()
        {
            int iBeginVal = 0;
            int iEndVal = 0;

            int iBeginValMatch = 0;
            int iEndValMatch = 0;
            
            //Do Normal Validations
            foreach (DataGridViewRow dgvRow in dgvRuleParameters.Rows)
            {                
                if (dgvRow.Cells[0].Value == null || dgvRow.Cells[2].Value == null || dgvRow.Cells[3].Value == null)
                {
                    MessageBox.Show("Please complete required values");
                    return false;
                }
                
                if (dgvRow.Cells[0].Value != null || dgvRow.Cells[2].Value != null || dgvRow.Cells[3].Value != null)
                {
                    iBeginVal = Convert.ToInt32(dgvRow.Cells[0].Value);
                    iEndVal = Convert.ToInt32(dgvRow.Cells[2].Value);

                    if (iBeginVal > iEndVal)
                    {
                        MessageBox.Show("End Value must be larger than Begin Value");
                        return false;
                    }
                    
                    if(iBeginVal > 31 || iEndVal > 31)
                    {
                        MessageBox.Show("No Value must be larger than 31");
                        return false;
                    }
                }
            }

            //Do Interval Validations
            foreach (DataGridViewRow dgvRowInterval in dgvRuleParameters.Rows)
            {
                iBeginVal = Convert.ToInt32(dgvRowInterval.Cells[0].Value);
                iEndVal = Convert.ToInt32(dgvRowInterval.Cells[2].Value);

                foreach (DataGridViewRow dgvRowIntervalCheck in dgvRuleParameters.Rows)
                {
                    iBeginValMatch = Convert.ToInt32(dgvRowIntervalCheck.Cells[0].Value);
                    iEndValMatch = Convert.ToInt32(dgvRowIntervalCheck.Cells[2].Value);

                    if (((iBeginValMatch >= iBeginVal && iBeginValMatch <= iEndVal) || (iEndValMatch >= iEndVal && iEndValMatch <= iEndVal)) && (dgvRowInterval.Index != dgvRowIntervalCheck.Index))
                    {
                        MessageBox.Show("There are rule parameters which overlap please correct these");
                        dgvRowIntervalCheck.DefaultCellStyle.BackColor = Color.Red;
                        return false;
                    }
                    else
                    {
                        dgvRowIntervalCheck.DefaultCellStyle.BackColor = Color.White;                        
                    }
                }
            }

            return true;
        }

        private void btnSearchRules_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            using (Liquid.Finder.RuleZoom frmRuleZoom = new Liquid.Finder.RuleZoom())
            {
                if (frmRuleZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmRuleZoom.sRuleID != "")
                    {
                        LoadRule(frmRuleZoom.sRuleID);
                    }
                }
            }

            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtRuleID.Text = "*NEW*";
            txtRuleName.Text = "";
            txtRuleDesc.Text = "";
            chkSpecialEvent.Checked = false;

            LoadSpecRules();
            dgvRuleParameters.Rows.Clear();
        }

        
    }
}