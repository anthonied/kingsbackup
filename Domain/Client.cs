using System.Collections.Generic;

namespace Liquid.Domain
{
    public class Client
    {
        public List<Transaction> Transactions { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
        public BalanceHistory BalanceHistory { get; set; }
        public string ClientDescription { get; set; }
        public string ClientCode { get; set; }
        public string ClientAddress1 { get; set; }
        public string ClientAddress2 { get; set; }
        public string ClientAddress3 { get; set; }
        public string ClientAddress4 { get; set; }
        public string ClientTelephone { get; set; }
        public string ClientFax { get; set; }
        public string ClientCell { get; set; }
        public string ClientVat { get; set; }  
      
    }
}
