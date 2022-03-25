using System;
using Liquid.Services;
using System.Data;
using Liquid.Domain;


namespace Liquid.ViewModel
{
    public class MonthEndStatementViewModel
    {
        StatementDomainService StatementService = new StatementDomainService();

        public MonthEndStatementViewModel()
        {

            //GetStatementFromDummy();
            //StatementService.GetStatementFromPastel();
        }

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

        public decimal Days120 { get; set; }
        public decimal Days90 { get; set; }
        public decimal Days60 { get; set; }
        public decimal Days30 { get; set; }
        public decimal DaysCurrent { get; set; }

        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }

        public string CompanyDescription { get; set; }
        public string CompanyVAT { get; set; }
        public string CompanyRegNo { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyAddress3 { get; set; }
        public string CompanyAddress4 { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyFax { get; set; }

        public DataSet ViewTransactions { get; set; }
        public DataSet ViewTransactionHistory { get; set; }

        public void GetStatementFromPastel(string sCustomerFrom, string sCustomerTo, DateTime dtDateFrom, DateTime dtDateTo)
        {          
            
            var StatementService = new StatementDomainService();                       
            Statement DomainStatement = StatementService.GetPastelStatement(sCustomerFrom,sCustomerTo,dtDateFrom,dtDateTo);
     
            ViewTransactions = new Datasets.dsMonthEndStatement();
            ViewTransactionHistory = new Datasets.dsMonthEndStatementSubReport();           
            CompanyDescription = DomainStatement.Company.CompanyDescription;
            CompanyVAT = DomainStatement.Company.CompanyVAT;
            CompanyRegNo = DomainStatement.Company.CompanyRegNo;
            CompanyAddress1 = DomainStatement.Company.CompanyAddress1;
            CompanyAddress2 = DomainStatement.Company.CompanyAddress2;
            CompanyAddress3 = DomainStatement.Company.CompanyAddress3;
            CompanyAddress4 = DomainStatement.Company.CompanyAddress4;
            CompanyName = DomainStatement.Company.CompanyName;
            CompanyTel = DomainStatement.Company.CompanyTel;
            CompanyFax = DomainStatement.Company.CompanyFax;        
            foreach (var Client in DomainStatement.Clients)
            {                
                foreach (var Trans in Client.Transactions)
                {
                    var myRow = ViewTransactions.Tables["dtMonthEndStatement"].NewRow();
                    myRow["Date"] = Trans.TransDate;
                    myRow["Reference"] = Trans.Reference;
                    myRow["Description"] = Trans.Description;
                    myRow["Debit"] = Trans.DebitValue;
                    myRow["Credit"] = Trans.CreditValue;
                    myRow["Balance"] = Trans.Balance;

                    myRow["Address1"] = Client.ClientAddress1;
                    myRow["Address2"] = Client.ClientAddress2 ;
                    myRow["Address3"] = Client.ClientAddress3;
                    myRow["Address4"] = Client.ClientAddress4;
                    myRow["Vat"] = Client.ClientVat;
                    //myRow["RegNo"] = Client.;
                    myRow["Days120"] = Client.BalanceHistory.Days120;
                    myRow["Days90"] = Client.BalanceHistory.Days90;
                    myRow["Days60"] = Client.BalanceHistory.Days60;
                    myRow["Days30"] = Client.BalanceHistory.Days30;
                    myRow["DaysCurrent"] = Client.BalanceHistory.Current;
                    myRow["Cell"] = Client.ClientCell;
                    myRow["Fax"] = Client.ClientFax;
                    myRow["Telephone"] = Client.ClientTelephone;
                    myRow["ClientCode"] = Client.ClientCode;
                    myRow["ClientDescription"] = Client.ClientDescription;                   
                    myRow["AmountDue"] = Client.BalanceHistory.AmountDue;
                    ViewTransactions.Tables["dtMonthEndStatement"].Rows.Add(myRow);
                }
                foreach (var TransHist in Client.TransactionHistory)
                {
                    var myRow = ViewTransactionHistory.Tables["dtMonthEndStatementSubReport"].NewRow();
                    myRow["Date"] = TransHist.TransDate;
                    myRow["Reference"] = TransHist.Reference;
                    myRow["Description"] = TransHist.Description;
                    myRow["Amount"] = TransHist.Value;
                    myRow["ClientCode"] = TransHist.ClientCode;
                    ViewTransactionHistory.Tables["dtMonthEndStatementSubReport"].Rows.Add(myRow);
                }
                          
            }

            


        }
    }
}
