
using Liquid.Services;
using System.Collections.Generic;
using System.Linq;
using Liquid.Domain;

namespace Liquid.Finder
{
    public class FinderViewModel
    {
        CustomerDomainService _customerService = new CustomerDomainService();
        public Customer SelectedCustomer { get; set; }
        public List<Customer> AllCustomers { get; set; }

        private Customer _startCustomer { get; set; }
        private string _connectionString;

        public FinderViewModel(string connectionString, Customer startCustomer)
        {
            _connectionString = connectionString;
            _startCustomer = startCustomer;
            GetAllCustomers();
        }

        public void GetAllCustomers()
        {
            AllCustomers =  _customerService.GetAllCustomers(_connectionString);

            if (_startCustomer == null)
                return;

            AllCustomers = AllCustomers.Where(customer => customer.CustomerCode.CompareTo(_startCustomer.CustomerCode) >= 0).ToList<Customer>();
        }

        public void SetSelectedCustomer(Customer customer)
        {
            SelectedCustomer = customer;
        }

    }
}
