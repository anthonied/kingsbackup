using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Liquid.Classes;
using Liquid.Models;
using Liquid.Repository;

namespace Liquid.Forms
{
    public partial class SpecialCustomerNotes : Form
    {
        public SpecialCustomerNotes()
        {
            InitializeComponent();
        }

        private CustomerRepository _customerRepo;
        private SpecialPriceListEntryRepository _specialPriceListRepo;
        private List<SpecialPriceListEntryModel> _filterModel;

        public bool LoadCustomerNotes(string customerName)
        {
            _customerRepo = new CustomerRepository(Connect.LiquidConnectionString, Connect.PastelConnectionString);
            _specialPriceListRepo = new SpecialPriceListEntryRepository(Connect.LiquidConnectionString,
                Connect.PastelConnectionString, _customerRepo);

            var entries = _specialPriceListRepo.GetMany();
            _filterModel =
                entries.Select(SpecialPriceListEntryModel.FromDomain)
                    .Where(x => x.CustomerCode == customerName)
                    .ToList();
            dgCustomerSalesOrderNotes.DataSource = _filterModel;
            if (_filterModel.Count != 0)
            {
                Show(SpecialCustomerNotes.ActiveForm);
                return true;
            }
            return false;
        }


    }
}
