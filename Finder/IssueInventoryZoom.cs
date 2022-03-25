using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class IssueInventoryZoom : Form
    {
        BindingSource bsIssueInventory;
        public TextBox txtActive;

        public string sDocumentNumber = "";
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

        public IssueInventoryZoom()
        {
            InitializeComponent();
        }

        private void IssueInventoryZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtDocNumber;

            LoadGridDetail();
            //this.ActiveControl = txtDocNumber;
        }

        private void LoadGridDetail()
        {
            //dgIssueInventory.Rows.Clear();

            PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString);
            oConn.Open();

            string sSql = "SELECT DocNumber, AssetNumber, Reference FROM SOLAH ";
            sSql += "WHERE (DocNumber like '%" + txtDocNumber.Text.Trim() + "%' or '' = '" + txtDocNumber.Text.Trim() + "') ";
            sSql += "AND (AssetNumber like '%" + txtAssetNumber.Text.Trim() + "%' or '' = '" + txtAssetNumber.Text.Trim() + "') ";
            sSql += "AND (Reference like '%" + txtReference.Text.Trim() + "%' or '' = '" + txtReference.Text.Trim() + "') ";
            sSql += "ORDER BY DocNumber Desc";

            dgIssueInventory.AutoGenerateColumns = false;

            DataSet dsIssueInventory = Liquid.Classes.Connect.getDataSet(sSql, "IssueInventory", oConn);

            bsIssueInventory = new BindingSource();
            bsIssueInventory.DataSource = dsIssueInventory;
            bsIssueInventory.DataMember = dsIssueInventory.Tables["IssueInventory"].TableName;

            dgIssueInventory.DataSource = bsIssueInventory;

            /*PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
            while (rdReader.Read())
            {
                int n = dgIssueInventory.Rows.Add();

                dgIssueInventory.Rows[n].Cells["clDocumentNumber"].Value = rdReader["DocNumber"].ToString().Trim();
                dgIssueInventory.Rows[n].Cells["clAssetNumber"].Value = rdReader["AssetNumber"].ToString().Trim();
                dgIssueInventory.Rows[n].Cells["clReference"].Value = rdReader["Reference"].ToString().Trim();
                
            }*/

            oConn.Dispose();
            dgIssueInventory.Focus();


        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            LoadGridDetail();
        }

        private void dgIssueInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sDocumentNumber = dgIssueInventory.Rows[e.RowIndex].Cells["clDocumentNumber"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgIssueInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgIssueInventory.Rows.Count > 0)
                {
                    e.SuppressKeyPress = true;
                    sDocumentNumber = dgIssueInventory.SelectedRows[0].Cells["clDocumentNumber"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                //if (e.KeyValue > 40)
                //{
                //    e.SuppressKeyPress = true;
                //    txtDocNumber.Text += char.ConvertFromUtf32(e.KeyValue).ToString();
                //    txtDocNumber.Focus();
                //    txtDocNumber.SelectionStart = txtDocNumber.Text.Length;
                //    txtDocNumber.SelectionLength = 0;
                //}

            }
        }

        private void txtDocNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGridDetail();
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgIssueInventory.Focus();
            }
        }

        private void txtReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGridDetail();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgIssueInventory.Focus();
            }
        }

        private void txtAssetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGridDetail();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgIssueInventory.Focus();
            }
        }

        private void cmdFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGridDetail();
            }
        }

        private void dgIssueInventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();
            txtActive.SelectionStart = txtActive.Text.Length;
            txtActive.SelectionLength = 0;
        }

        private void txtDocNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtReference.Text.Trim() != "")
            {
                if (txtAssetNumber.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //DocNumber and Reference
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
            }
            else if (txtAssetNumber.Text.Trim() != "")
            {
                if (txtReference.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //DocNumber and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%'";
            }  
            else //DocNumber
                bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%'";
        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {
            if (txtDocNumber.Text.Trim() != "")
            {
                if (txtAssetNumber.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //DocNumber and Reference
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
            }
            else if (txtAssetNumber.Text.Trim() != "")
            {
                if (txtDocNumber.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //Reference and Asset
                    bsIssueInventory.Filter = "Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%'";
            }
            else //Reference
                bsIssueInventory.Filter = "Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
        }

        private void txtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtDocNumber.Text.Trim() != "")
            {
                if (txtReference.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //DocNumber and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%'";
            }
            else if (txtReference.Text.Trim() != "")
            {
                if (txtDocNumber.Text.Trim() != "") //DocNumber,Ref and Asset
                    bsIssueInventory.Filter = "DocNumber LIKE '%" + txtDocNumber.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%' AND Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%'";
                else //Reference and Asset
                    bsIssueInventory.Filter = "Reference LIKE '%" + txtReference.Text.Replace("'", "''") + "%' AND AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%'";
            }
            else //Reference
                bsIssueInventory.Filter = "AssetNumber LIKE '%" + txtAssetNumber.Text.Replace("'", "''") + "%'";
        }

        private void txtDocNumber_Enter(object sender, EventArgs e)
        {
            txtActive = (TextBox)sender;
        }

       
    }
}