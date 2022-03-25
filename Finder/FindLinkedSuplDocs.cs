using System;
using System.Drawing;
using System.Windows.Forms;
using Pervasive.Data.SqlClient;

namespace Liquid.Finder
{
    public partial class FindLinkedSuplDocs : Form
    {
        private string sSupplierCode = "";
        private string sLinkedDoc = "";
        private string sAvailableLinkedDocs = "";
        

        public string[] aReturn = new string[0];
        public string sDocumentNumber = "";
        public string sParentDocType = "";

        private DataGridViewCellStyle ReadOnlyStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle ErrorStyle = new DataGridViewCellStyle();

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {  
                switch (keyData)
                {
                    case Keys.Tab:
                        manageFrontEnd();
                        bHandled = true;
                        break;
                    case Keys.Enter:
                        manageFrontEnd();
                        bHandled = true;
                        break;
                    case Keys.Escape:
                        this.Close();
                        break;
                }
                
            }
            return bHandled;
        }
        private void HandleGridTab(int iRowIndex)
        {            
            if (iRowIndex < dgLineDetail.Rows.Count - 1)
            {
                if (dgLineDetail.CurrentCell == dgLineDetail.Rows[iRowIndex].Cells["clUseQty"])
                    dgLineDetail.CurrentCell = dgLineDetail.Rows[iRowIndex].Cells["clSelected"];
                else
                    dgLineDetail.CurrentCell = dgLineDetail.Rows[iRowIndex + 1].Cells["clUseQty"];                
            }
            else
            {
                if (dgLineDetail.CurrentCell == dgLineDetail.Rows[iRowIndex].Cells["clUseQty"])
                    dgLineDetail.CurrentCell = dgLineDetail.Rows[iRowIndex].Cells["clSelected"];                
                else 
                    this.ActiveControl = cmdLink;
            }
        }

        private void manageFrontEnd()
        {
            Control cntSelectedControl = this.ActiveControl;
                      
            switch (cntSelectedControl.Name)
            {
                case "txtNumber":
                    if (txtNumber.Text == "")
                    {
                        cmdSearchNumber_Click(null, null);
                    }
                    else if (txtNumber.Text != "")
                    {
                        LoadGridDetail();
                    }
                    this.ActiveControl = dgLineDetail;
                    if (dgLineDetail.Rows.Count > 0)
                    {
                        dgLineDetail.CurrentCell = dgLineDetail.Rows[0].Cells["clUseQty"];                
                    }
                    break;
                case "dgLineDetail":
                    if (dgLineDetail.Rows.Count > 0)
                    {
                        HandleGridTab(((DataGridView)this.ActiveControl).CurrentCell.RowIndex);
                    }
                    else
                    {
                        HandleGridTab(-1);
                    }
                    break;
                                
            }
        }


        public FindLinkedSuplDocs()
        {
            InitializeComponent();
            ReadOnlyStyle.BackColor = Color.AliceBlue;
            ErrorStyle.BackColor = Color.Yellow;

        }
        public DialogResult ShowDialog(string[] aSupplierDetail, string slinkedDocType, string sAvailLinkedDocs)
        {
            sAvailableLinkedDocs = sAvailLinkedDocs;
            sLinkedDoc = slinkedDocType;
            
            txtSupplierDescription.Text = aSupplierDetail[0];
            sSupplierCode = aSupplierDetail[1];
            txtSupplierCode.Text = aSupplierDetail[1];
            txtDelAd1.Text = aSupplierDetail[2];
            txtDelAd2.Text = aSupplierDetail[3];
            txtDelAd3.Text = aSupplierDetail[4];
            txtDelAd4.Text = aSupplierDetail[5];
            txtDelAd5.Text = aSupplierDetail[6];           
            txtPosAd1.Text = aSupplierDetail[7];
            txtPosAd2.Text = aSupplierDetail[8];
            txtPosAd3.Text = aSupplierDetail[9];
            txtPosAd4.Text = aSupplierDetail[10];                        

            return this.ShowDialog();
        }

        private void FindLinkedSuplDocs_Load(object sender, EventArgs e)
        {
            txtDocType.Text = sLinkedDoc;            
        }

        private void LoadGridDetail()
        {
            dgLineDetail.Rows.Clear();
            using (PsqlConnection oConn = new PsqlConnection(Liquid.Classes.Connect.PastelConnectionString))
            {
                oConn.Open();

                string sSql = "Select ItemCode, MultiStore, Description, UnitPrice, Qty, QtyLeft,GRNQty, LinkNum from HistoryLines where DocumentNumber = '" + txtNumber.Text.Trim() + "'";

                PsqlDataReader rdReader = Liquid.Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader();
                while (rdReader.Read())
                {
                    int n = dgLineDetail.Rows.Add();

                    dgLineDetail.Rows[n].Cells["clCode"].Value = rdReader["ItemCode"].ToString().Trim();
                    dgLineDetail.Rows[n].Cells["clStore"].Value = rdReader["MultiStore"].ToString().Trim();
                    dgLineDetail.Rows[n].Cells["clDescription"].Value = rdReader["Description"].ToString().Trim();
                    dgLineDetail.Rows[n].Cells["clUnitPrice"].Value = rdReader["UnitPrice"].ToString().Trim();
                    if (txtDocType.Text == "Link GRN")
                    {
                        dgLineDetail.Rows[n].Cells["clLineQty"].Value = rdReader["GRNQty"].ToString().Trim();
                        dgLineDetail.Rows[n].Cells["clUseQty"].Value = rdReader["GRNQty"].ToString().Trim();
                    }
                    else
                    {
                        dgLineDetail.Rows[n].Cells["clLineQty"].Value = rdReader["QtyLeft"].ToString().Trim();
                        dgLineDetail.Rows[n].Cells["clUseQty"].Value = rdReader["QtyLeft"].ToString().Trim();
                    }
                    dgLineDetail.Rows[n].Cells["clSelected"].Value = clSelected.TrueValue;

                    dgLineDetail.Rows[n].Cells["clCode"].Style = ReadOnlyStyle;
                    dgLineDetail.Rows[n].Cells["clStore"].Style = ReadOnlyStyle;
                    dgLineDetail.Rows[n].Cells["clDescription"].Style = ReadOnlyStyle;
                    dgLineDetail.Rows[n].Cells["clUnitPrice"].Style = ReadOnlyStyle;
                    dgLineDetail.Rows[n].Cells["clLineQty"].Style = ReadOnlyStyle;

                    this.dgLineDetail.Columns["clUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgLineDetail.Columns["clLineQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgLineDetail.Columns["clUseQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgLineDetail.Rows[n].Cells["clLinkNum"].Value = rdReader["LinkNum"].ToString().Trim(); 


                }
                rdReader.Close();
                oConn.Dispose();
            }

        }

        private void cmdSearchNumber_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            using (Liquid.Finder.SupplierDocumentZoom frmSupplDocZoom = new Liquid.Finder.SupplierDocumentZoom())
            {
                string sBatchDocType = "";
                string sNormalDocType = "";
                                
                if (txtDocType.Text == "Link Purchase Order")
                {
                    sBatchDocType = "106";
                    sNormalDocType = "6";
                }
                else if (txtDocType.Text == "Link GRN")
                {
                    sBatchDocType = "107";
                    sNormalDocType = "7";
                }

                //JR Available Parent Docs
                if (frmSupplDocZoom.ShowDialog(sBatchDocType, sNormalDocType, txtSupplierCode.Text,sAvailableLinkedDocs) == DialogResult.OK)
                {
                    if (frmSupplDocZoom.sResult != "")
                    {
                        txtNumber.Text = frmSupplDocZoom.sResult;
                        sParentDocType = frmSupplDocZoom.sDocumentType;

                        LoadGridDetail();
                    }
                }
            }

            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void cmdReject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLink_Click(object sender, EventArgs e)
        {
            bool bErrors = false;
            if (txtNumber.Text == "")
            {
                bErrors = true;
                MessageBox.Show("You have to select a Number if you want to link the document", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dgLineDetail.Rows.Count > 0)
            {
                for (int i = 0; i < dgLineDetail.Rows.Count; i++)
                {
                    if (dgLineDetail.Rows[i].Cells["clSelected"].Value == clSelected.TrueValue)
                    {
                        if (dgLineDetail.Rows[i].Cells["clUseQty"].Value == "" || dgLineDetail.Rows[i].Cells["clUseQty"].Value == null)
                        {
                            dgLineDetail.Rows[i].Cells["clUseQty"].Style = ErrorStyle;
                            bErrors = true;
                            MessageBox.Show("The Use Qty may not be blank", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Convert.ToDouble(dgLineDetail.Rows[i].Cells["clLineQty"].Value) < Convert.ToDouble(dgLineDetail.Rows[i].Cells["clUseQty"].Value))
                        {
                            dgLineDetail.Rows[i].Cells["clUseQty"].Style = ErrorStyle;
                            bErrors = true;
                            MessageBox.Show("The Use Qty may not be more than the Line Qty", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Convert.ToDouble(dgLineDetail.Rows[i].Cells["clUseQty"].Value) != 0)
                            {
                                double dQtyBalance = Convert.ToDouble(dgLineDetail.Rows[i].Cells["clLineQty"].Value) - Convert.ToDouble(dgLineDetail.Rows[i].Cells["clUseQty"].Value);
                                Array.Resize<string>(ref aReturn, aReturn.Length + 1);
                                aReturn[aReturn.Length - 1] = dgLineDetail.Rows[i].Cells["clCode"].Value + "|" + dgLineDetail.Rows[i].Cells["clUseQty"].Value + "|" + dQtyBalance +"|" + dgLineDetail.Rows[i].Cells["clLinkNum"].Value;
                            }

                        }
                    }
                }


            }

            if (bErrors)
            {
                MessageBox.Show("Please resolve the Error and try then linking", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sDocumentNumber = txtNumber.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}