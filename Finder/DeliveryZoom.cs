using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class DeliveryZoom : Form
    {
        public DeliveryZoom()
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
            dgDeliveryZoom.Rows.Clear();   
            using (PsqlConnection oConn = new PsqlConnection(Classes.Connect.LiquidConnectionString))
            {
                string sSql = "Select DocNumber, CustCode, DocDate From SOLPDH where DocNumber like '%" + txtDeliveryNote.Text + "%' AND CustCode like '%" + txtCustomerCode.Text + "%' order by DocNumber desc";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgDeliveryZoom.Rows.Add();
                    dgDeliveryZoom.Rows[n].Cells[0].Value = rdReader["DocNumber"].ToString();
                    dgDeliveryZoom.Rows[n].Cells[1].Value = rdReader["CustCode"].ToString();
                    dgDeliveryZoom.Rows[n].Cells[2].Value = Convert.ToDateTime(rdReader["DocDate"].ToString()).ToString("MM/dd/yyyy");
                }
                oConn.Dispose();
                rdReader.Close();

            }
        }

        private void dgDeliveryZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgDeliveryZoom.SelectedRows[0].Cells[0].Value.ToString();
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
                dgDeliveryZoom.Focus();
            }
        }

        private void dgDeliveryZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgDeliveryZoom.Rows.Count > 0)
                {
                    sResult = dgDeliveryZoom.SelectedRows[0].Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
