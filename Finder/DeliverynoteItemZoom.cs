using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class DeliverynoteItemZoom : Form
    {
        public DeliverynoteItemZoom()
        {
            InitializeComponent();
        }

        BindingSource bsItems;
        public List<string> ItemList = new List<string>();
        public string sProject = "";
      
        public DialogResult ShowDialog(string sProj)
        {
            sProject = sProj;
            return (this.ShowDialog());
        }
        
        private void DeliverynoteItemZoom_Load(object sender, EventArgs e)
        {
            txtCode.CharacterCasing = CharacterCasing.Upper;
            txtDescription.CharacterCasing = CharacterCasing.Upper;  
            loadItemGrid();
          
        }

        private void loadItemGrid ()
        {
            dgInventory.Rows.Clear();
            using (PsqlConnection oConnLiq = new PsqlConnection(Liquid.Classes.Connect.LiquidConnectionString))
            {
                string sSqlLiq = "select SOLQHL.Itemcode,SOLQHL.Description, SOLQHL.DocNumber, SOLQHL.Qty , SOLQHL.Unit, IF(Qty = '','false','false') 'clKit' from SOLQHH";
                sSqlLiq += " inner join SOLQHL on SOLQHL.DocNumber = SOLQHH.DocNumber";
                sSqlLiq += " where SOLQHH.Project ='" + sProject + "' AND ItemCode <> '''' AND ItemCode like '%" + txtCode.Text.Trim() + "%' AND Description like '%" + txtDescription.Text.Trim()  + "%'";

                dgInventory.AutoGenerateColumns = false;
                DataSet dsAvailInventory = Liquid.Classes.Connect.getDataSet(sSqlLiq, "Inventory", oConnLiq);
                bsItems = new BindingSource();
                bsItems.DataSource = dsAvailInventory;
                bsItems.DataMember = dsAvailInventory.Tables[0].TableName;
                dgInventory.DataSource = bsItems;
                oConnLiq.Dispose();
               
            }        

        }

        private void dgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgInventory.Columns[e.ColumnIndex].Name == "clKit")
            {
                if (dgInventory.Rows[e.RowIndex].Cells["clKit"].Value.ToString() == "false")
                {
                    ItemList.Add(dgInventory.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[5].Value.ToString().Trim());
                    dgInventory.Rows[e.RowIndex].Cells["clKit"].Value = clKit.TrueValue;
                }
                else
                {
                    ItemList.Remove(dgInventory.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() + "|" + dgInventory.Rows[e.RowIndex].Cells[5].Value.ToString().Trim());
                    dgInventory.Rows[e.RowIndex].Cells["clKit"].Value = "false";
                }
            }
        }

        private void dgInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemList.Add(dgInventory.SelectedRows[0].Cells[0].Value + "|" + dgInventory.SelectedRows[0].Cells[1].Value + "|" + dgInventory.SelectedRows[0].Cells[3].Value + "|" + dgInventory.SelectedRows[0].Cells[5].Value);           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdAddKit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
           
            loadItemGrid();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
           
            loadItemGrid();
        }

        private void dgInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ItemList.Add(dgInventory.SelectedRows[0].Cells[0].Value + "|" + dgInventory.SelectedRows[0].Cells[1].Value + "|" + dgInventory.SelectedRows[0].Cells[3].Value + "|" + dgInventory.SelectedRows[0].Cells[5].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }		
        }
    }
}
