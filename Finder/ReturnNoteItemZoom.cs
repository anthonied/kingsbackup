using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class ReturnNoteItemZoom : Form
    {
        public ReturnNoteItemZoom()
        {
            InitializeComponent();
        }

        BindingSource bsItems;
        public List<string> ItemList = new List<string>();
        public string sDelNote = "";

        public DialogResult ShowDialog(string sDeliveryNote)
        {
            sDelNote = sDeliveryNote;
                
            return (this.ShowDialog());
        }

        private void ReturnNoteItemZoom_Load(object sender, EventArgs e)
        {
            txtDescription.CharacterCasing = CharacterCasing.Upper;
            txtCode.CharacterCasing = CharacterCasing.Lower;
            loadItemGrid();
        }

        private void loadItemGrid()
        {
            dgInventory.Rows.Clear();
            using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                string sSqlLiq = "select Itemcode,Description, Qty,Unit, IF(Qty = '','false','false') 'clKit' from SOLPDL";
                sSqlLiq += " where DocNumber = '" + sDelNote + "' AND ItemCode <> '''' AND ItemCode like '%" + txtCode.Text.Trim() + "%' AND Description like '%" + txtDescription.Text.Trim() + "%'";

                dgInventory.AutoGenerateColumns = false;
                DataSet dsAvailInventory = Liquid.Classes.Connect.getDataSet(sSqlLiq, "Inventory", oConnLiq);
                bsItems = new BindingSource();
                bsItems.DataSource = dsAvailInventory;
                bsItems.DataMember = dsAvailInventory.Tables[0].TableName;
                dgInventory.DataSource = bsItems;
                oConnLiq.Dispose();
              
            }

        }


        private void dgInventory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgInventory.Columns[e.ColumnIndex].Name == "clKit")
            {
                if (dgInventory.Rows[e.RowIndex].Cells["clKit"].Value.ToString() == "false")
                {
                    ItemList.Add(dgInventory.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[2].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                    dgInventory.Rows[e.RowIndex].Cells["clKit"].Value = clKit.TrueValue;
                }
                else
                {
                    ItemList.Remove(dgInventory.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[2].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());
                    dgInventory.Rows[e.RowIndex].Cells["clKit"].Value = "false";
                }
            }          
        }

        private void dgInventory_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ItemList.Add(dgInventory.SelectedRows[0].Cells[0].Value + "|" + dgInventory.SelectedRows[0].Cells[1].Value + "|" + dgInventory.SelectedRows[0].Cells[2].Value + "|" + dgInventory.SelectedRows[0].Cells[4].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdAddKit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            loadItemGrid();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            loadItemGrid();
        }

        private void dgInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ItemList.Add(dgInventory.SelectedRows[0].Cells[0].Value + "|" + dgInventory.SelectedRows[0].Cells[1].Value + "|" + dgInventory.SelectedRows[0].Cells[2].Value + "|" + dgInventory.SelectedRows[0].Cells[4].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }		
        }

      
    }
}
