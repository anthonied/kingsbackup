using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Liquid.Classes;

namespace Liquid.Finder
{
    public partial class PrintersZoom : Form
    {        
        public TextBox txtActive;

        public string sSelectedPrinterName = "";

        public Solsage_Pastel_API.solPastelSDK clsSDK = new Solsage_Pastel_API.solPastelSDK();        

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

        public PrintersZoom()
        {
            InitializeComponent();
        }

        private void PrintersZoom_Load(object sender, EventArgs e)
        {
            //txtActive = txtPrinterName;

            //txtPrinterName.CharacterCasing = CharacterCasing.Upper;
            loadPrintersGrid();
        }

        public DialogResult ShowDialog(string sPrinterName)
        {
            sSelectedPrinterName = sPrinterName;

            return (this.ShowDialog());
        }

        private void loadPrintersGrid()
        {                           
            dgvPrinters.Rows.Clear();
            dgvPrinters.AutoGenerateColumns = false;
           
            List<Win32_Printer> printerList = Win32_Printer.GetList();

            foreach (Win32_Printer printer in printerList)
            {
                string sName = printer.Name;
                string sPort = printer.PortName;
                string sDriverName = printer.DriverName;

                int n = dgvPrinters.Rows.Add();
                dgvPrinters.Rows[n].Cells["clPrinterName"].Value = sName;                
            }
                                                  
            dgvPrinters.Focus();
        }

        private void dgvPrinters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sSelectedPrinterName = dgvPrinters.SelectedRows[0].Cells["clPrinterName"].Value.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvPrinters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvPrinters.Rows.Count > 0)
                {
                    sSelectedPrinterName = dgvPrinters.SelectedRows[0].Cells["clPrinterName"].Value.ToString();
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }	
        }
    }
}