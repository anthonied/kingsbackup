using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class ReturnNoteZoom : Form
    {
        public ReturnNoteZoom()
        {
            InitializeComponent();
        }

        public string sResult = "";

        private void DeliveryZoom_Load(object sender, EventArgs e)
        {
            txtDeliveryNote.CharacterCasing = CharacterCasing.Upper;
            txtCustomerCode.CharacterCasing = CharacterCasing.Upper;
            loadDeliveryNoteGrid();
        }
        private void loadDeliveryNoteGrid()
        {
            dgReturnZoom.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Classes.Connect.LiquidConnectionString))
            {
                string sSql = "Select DocNumber, CustCode, DocDate From SOLPRH where DocNumber like '%" + txtDeliveryNote.Text + "%' AND CustCode like '%" + txtCustomerCode.Text + "%' order by DocNumber desc";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgReturnZoom.Rows.Add();
                    dgReturnZoom.Rows[n].Cells[0].Value = rdReader["DocNumber"].ToString();
                    dgReturnZoom.Rows[n].Cells[1].Value = rdReader["CustCode"].ToString();
                    dgReturnZoom.Rows[n].Cells[2].Value = Convert.ToDateTime(rdReader["DocDate"].ToString()).ToString("MM/dd/yyyy");
                }
                oConn.Dispose();
                rdReader.Close();
            }
        }

        private void dgDeliveryZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgReturnZoom.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDeliveryNote_TextChanged(object sender, EventArgs e)
        {
            loadDeliveryNoteGrid();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            loadDeliveryNoteGrid();
        }

        private void txtDeliveryNote_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgReturnZoom.Focus();
            }
        }

        private void dgReturnZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgReturnZoom.Rows.Count > 0)
                {
                    sResult = dgReturnZoom.SelectedRows[0].Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
