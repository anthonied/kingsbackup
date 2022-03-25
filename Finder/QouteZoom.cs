using System;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class QouteZoom : Form
    {
        public string sResult = "";
        public TextBox txtActive;

        public QouteZoom()
        {
            InitializeComponent();
        }

        private void QouteZoom_Load(object sender, EventArgs e)
        {
            txtActive = txtCustomerCode;
            txtQouteNumber.CharacterCasing = CharacterCasing.Upper;
            txtCustomerCode.CharacterCasing = CharacterCasing.Upper;  
            loadQouteGrid();
        }


        private void loadQouteGrid()
        {
            dgQouteZoom.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Classes.Connect.LiquidConnectionString))
            {
                string sSql = "Select DocNumber, CustCode, DocDate From SOLQHH where DocNumber like '%" + txtQouteNumber.Text + "%' AND CustCode like '%" + txtCustomerCode.Text + "%' order by DocNumber desc";
                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgQouteZoom.Rows.Add();
                    dgQouteZoom.Rows[n].Cells[0].Value = rdReader["DocNumber"].ToString();
                    dgQouteZoom.Rows[n].Cells[1].Value = rdReader["CustCode"].ToString();
                    dgQouteZoom.Rows[n].Cells[2].Value = Convert.ToDateTime(rdReader["DocDate"].ToString()).ToString("MM/dd/yyyy");
                }
                oConn.Dispose();
                rdReader.Close();

            }
            dgQouteZoom.Focus();
        }

        private void dgQouteZoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sResult = dgQouteZoom.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void txtQouteNumber_TextChanged(object sender, EventArgs e)
        {
            loadQouteGrid();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            loadQouteGrid();
        }

        private void txtQouteNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadQouteGrid();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dgQouteZoom.Focus();
            }
        }

        private void dgQouteZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //LL Phalaborwa if
                if (dgQouteZoom.Rows.Count > 0)
                {
                    sResult = dgQouteZoom.SelectedRows[0].Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void txtQouteNumber_Enter(object sender, EventArgs e)
        {           
			txtActive = (TextBox) sender;		
        }

        private void dgQouteZoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\t' && e.KeyChar != '\b')
                txtActive.Text += e.KeyChar.ToString();

            txtActive.Focus();

            txtActive.SelectionStart = txtCustomerCode.Text.Length;
            txtActive.SelectionLength = 0;	
        }

        

       
    }
}
