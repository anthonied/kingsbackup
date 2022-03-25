using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Liquid.Classes;
using Liquid.Domain;
using Liquid.Finder;
using Liquid.Models;
using Liquid.Repository;

namespace Liquid.Forms
{
    public partial class SpecialPriceListSetup : Form
    {
        private readonly CustomerRepository _customerRepo;
        private readonly SpecialPriceListEntryRepository _specialPriceListRepo;
        private List<SpecialPriceListEntryModel> _model;
        private List<SpecialPriceListEntryModel> _filterModel;
   
        public SpecialPriceListSetup()
        {
            InitializeComponent();
            _customerRepo = new CustomerRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            _specialPriceListRepo = new SpecialPriceListEntryRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString, _customerRepo);
        }

        private void SpecialPriceListSetup_Load(object sender, System.EventArgs e)
        {
            var entries = _specialPriceListRepo.GetMany();
            _model = entries.Select(SpecialPriceListEntryModel.FromDomain).ToList();
            _filterModel = _model;
            dgSpecialPriceList.DataSource = _filterModel;
        }

        private void cmdSearchCustomer_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (var frmCustomerZoom = new CustomerZoom())
            {
                if (frmCustomerZoom.ShowDialog() == DialogResult.OK)
                {
                    if (frmCustomerZoom.CustomerCode != "")
                    {
                        txtCustomerCode.Text = frmCustomerZoom.CustomerCode;
                        txtCustomerDescription.Text = frmCustomerZoom.CustomerDescription;
                        cmdSave.Enabled = true;
                        txtItemService.Focus();
                    }
                }
                _filterModel = _model.Where(x => x.CustomerCode == frmCustomerZoom.CustomerCode).ToList();
                dgSpecialPriceList.DataSource = _filterModel;
                Cursor = Cursors.Default;
            }
        }

        private void cmdSave_Click(object sender, System.EventArgs e)
        {
            if (txtPriceExVat.Text == "")
                txtPriceExVat.Text = "0";

            if (txtSettlement.Text == "")
                txtSettlement.Text = "0";

            if (!isNewEntryValidated()) return;

            var specialPriceListEntry = getDomainFromGui();

            if (txtCurrentId.Text == "" || txtCurrentId.Text == "0")
            {
                var didCreate = _specialPriceListRepo.Create(specialPriceListEntry);
                if (!didCreate) return;

                var newEntryModel = SpecialPriceListEntryModel.FromDomain(specialPriceListEntry);
                
                _model.Add(newEntryModel);
                _filterModel = _model.Where(x => x.CustomerCode == txtCustomerCode.Text).ToList();
               
                var tempModel = new List<SpecialPriceListEntryModel>(_filterModel);
                dgSpecialPriceList.DataSource = tempModel;
            }
            else
            {
                var didUpdate = _specialPriceListRepo.Update(specialPriceListEntry);
                var tempModel = new List<SpecialPriceListEntryModel>(_filterModel);
                
                updateModelWithUpdatedValues(tempModel, specialPriceListEntry);

                dgSpecialPriceList.DataSource = tempModel;
            }
            clearFormKeepCustomer();
        }

        private void updateModelWithUpdatedValues(List<SpecialPriceListEntryModel> tempModel, SpecialPriceListEntry updatedEntry)
        {
            var updatedModel = SpecialPriceListEntryModel.FromDomain(updatedEntry);
            var entryToChange = tempModel.First(x => x.Id == updatedEntry.Id);
            entryToChange.CustomerName = updatedModel.CustomerName;
            entryToChange.CustomerCode = updatedModel.CustomerCode;
            entryToChange.Description = updatedModel.Description;
            entryToChange.PriceExVat = updatedModel.PriceExVat;
            entryToChange.Note = updatedModel.Note;
            entryToChange.CollectionDeliveryNote = updatedModel.CollectionDeliveryNote;
            entryToChange.Settlement = updatedModel.Settlement;
        }


        private bool isNewEntryValidated()
        {
            var testedValue = 0m;
           
            if (txtCustomerCode.Text == "")
            {
                MessageBox.Show("Please select a customer", "No Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPriceExVat.Text, out testedValue))
            {
                MessageBox.Show("Please provide a numeric Price Ex Vat", "Incorrect Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPriceExVat.Focus();
                return false;
            }
            if (!decimal.TryParse(txtSettlement.Text, out testedValue))
            {
                MessageBox.Show("Please provide a numeric Settlement", "Incorrect Settlement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSettlement.Focus();
                return false;
            }

            return true;
        }

        private SpecialPriceListEntry getDomainFromGui()
        {
            return new SpecialPriceListEntry
            {
                Id = txtCurrentId.Text == "" ? 0 : int.Parse(txtCurrentId.Text),
                Customer = new Customer
                {
                    CustomerCode = txtCustomerCode.Text,
                    Description = txtCustomerDescription.Text
                },
                Description = txtItemService.Text,
                PriceExVat = decimal.Parse(txtPriceExVat.Text),
                Note = txtNote.Text,
                CollectionDeliveryNote = txtDeliveryCollection.Text,
                Settlement = decimal.Parse(txtSettlement.Text)
            };
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("You will lose all current values in this form, are you sure?", "Clear Form",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            
            clearForm();
            dgSpecialPriceList.DataSource = _model;
        }

        private void clearForm()
        {
            txtCustomerCode.Text = "";
            txtCustomerDescription.Text = "";
            clearFormKeepCustomer();
        }

        private void clearFormKeepCustomer()
        {
            txtItemService.Text = "";
            txtNote.Text = "";
            txtPriceExVat.Text = "";
            txtSettlement.Text = "";
            txtDeliveryCollection.Text = "";
            txtCurrentId.Text = "";
        }

        private void dgSpecialPriceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) 
                return;

            if (isEditButtonClicked(e))
            {
                cmdSave.Enabled = true;
                fillEditForm(e);
            }

            if (isRemoveButtonClicked(e))
            {
                removeEntry(e);
            }
        }

        private void removeEntry(DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("This entry will permanently be removed.  Are you sure ?", "Remove Entry",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question) != DialogResult.Yes) return;

            var rowToEdit = dgSpecialPriceList.Rows[e.RowIndex];
            var id = int.Parse(rowToEdit.Cells["clId"].Value.ToString());
            _specialPriceListRepo.Delete(id);
            var tempModel = new List<SpecialPriceListEntryModel>(_filterModel);
            var recordToRemove = tempModel.First(x => x.Id == id);
            tempModel.Remove(recordToRemove);
            _filterModel.Remove(recordToRemove);
            _model.Remove(recordToRemove);
            dgSpecialPriceList.DataSource = tempModel;

        }


        private void fillEditForm(DataGridViewCellEventArgs e)
        {
            var rowToEdit = dgSpecialPriceList.Rows[e.RowIndex];
            txtCurrentId.Text = rowToEdit.Cells["clId"].Value.ToString();
            txtCustomerCode.Text = rowToEdit.Cells["clCustomerCode"].Value.ToString();
            txtCustomerDescription.Text = rowToEdit.Cells["clCustomerName"].Value.ToString();
            txtItemService.Text = rowToEdit.Cells["clItem"].Value.ToString();
            txtNote.Text = rowToEdit.Cells["clNotes"].Value.ToString();
            txtPriceExVat.Text = rowToEdit.Cells["clPrice"].Value.ToString();
            txtSettlement.Text = rowToEdit.Cells["clSettlement"].Value.ToString();
            txtDeliveryCollection.Text = rowToEdit.Cells["clDeliveryCollection"].Value.ToString();
        }

        private static bool isEditButtonClicked(DataGridViewCellEventArgs e)
        {
            return e.ColumnIndex == 8;
        }

        private bool isRemoveButtonClicked(DataGridViewCellEventArgs e)
        {
            return e.ColumnIndex == 9;
        }
    }
     
}
