using System;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class RuleZoom : Form
    {
        BindingSource bsRules;
        public string sRuleID = "";
        public string sRuleNameReturn = "";
        public string sRuleUnit = "";

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

        public RuleZoom()
        {
            InitializeComponent();
            LoadDatagridView();
        }

        public void LoadDatagridView()
        {
            dgvAvailableRules.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                string sSql = "SELECT PKiRuleID,sRuleName,sRuleDescription,sRuleUnit FROM SOLRM";

                DataSet dsAvailRules = Connect.getDataSet(sSql, "Rules", oConn);
                bsRules = new BindingSource();
                bsRules.DataSource = dsAvailRules;
                bsRules.DataMember = dsAvailRules.Tables[0].TableName;

                dgvAvailableRules.DataSource = bsRules;
            }
        }

        private void txtSearchFilter_TextChanged(object sender, EventArgs e)
        {
            bsRules.Filter = "sRuleName LIKE '%" + txtSearchFilter.Text + "%'";
        }

        private void btnResetRules_Click(object sender, EventArgs e)
        {
            txtSearchFilter.Text = "";
        }

        private void dgvAvailableRules_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sRuleID = dgvAvailableRules.CurrentRow.Cells[0].Value.ToString();
            sRuleNameReturn = dgvAvailableRules.CurrentRow.Cells[1].Value.ToString();
            sRuleUnit = dgvAvailableRules.CurrentRow.Cells[3].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}