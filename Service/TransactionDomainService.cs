using System;
using System.Collections.Generic;
using Liquid.Domain;
using Pervasive.Data.SqlClient;

namespace Liquid.Services
{
    public  class TransactionDomainService
    {
        public static string sExceptionList = "";

        public  List<Transaction> lsGetTransactions(string sCustomerCode, DateTime dtDateFrom,DateTime dtDateTo)
        {
            sExceptionList = "(";
            List<Transaction> TempTransList = GetPeriodTransactionList(sCustomerCode, dtDateFrom, dtDateTo);
            List<Transaction> lsTransactionList = new List<Transaction>();
            Service.StatementOpenItemDomainService OpenItemService = new Service.StatementOpenItemDomainService();
            List<StatementOpenItem> OpenItemList = OpenItemService.GetStatementOpenItems(dtDateFrom, dtDateTo, sCustomerCode,sExceptionList);
                     
            foreach (var OpenItem in OpenItemList)
            {
                if (OpenItem.Balance != 0) //unmatched then show all transactions linked to that invoice
                {
                    foreach (var DebitTrans in OpenItem.Debit)
                    {
                        lsTransactionList.Add(DebitTrans);
                    }
                    foreach (var CreditTrans in OpenItem.Credit)
                    {
                        lsTransactionList.Add(CreditTrans);
                    }
                }
            }
            
            foreach (var Trans in TempTransList)
            {
                lsTransactionList.Add(Trans);
            }
            return lsTransactionList;    
        }

        private static List<Transaction> GetPeriodTransactionList(string sCustomer,DateTime dtDateFrom, DateTime dtDateTo)
        {
            var lsTransactionList = new List<Transaction>();
            string sOldInvoice = "1";
            string sActiveInvoice = "1";
            string sSql = "select MatchRef,Original,SUM(Amount) As Amount,Description,DDate,Ref";
            sSql += String.Format(" from OpenItem where(CSCode = '{0}' AND Original = 1 AND DDate between '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}')", sCustomer, dtDateFrom, dtDateTo);
            sSql += String.Format(" or (CSCode = '{0}' AND Original = 5 AND DDate < '{1:yyyy-MM-dd}')", sCustomer, dtDateTo);
            sSql += " group by MatchRef,Original,Description,DDate,Ref";
            sSql += " order by MatchRef,Original";

            
            using (PsqlConnection oSConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                oSConn.Open();
                using (PsqlDataReader rdReader2 = Classes.Connect.getDataCommand(sSql, oSConn).ExecuteReader())
                {
                    while (rdReader2.Read())
                    {
                        string sNewInvoice = rdReader2["MatchRef"].ToString().Trim();                    

                        if (rdReader2["Original"].ToString() == "1")
                        {
                            sActiveInvoice = "";
                            sExceptionList += String.Format("'{0}',", sNewInvoice); 
                            if (rdReader2["Amount"].ToString().Substring(0, 1) != "-")  //debitTransaction
                            {
                                var NewDebitTransaction = new DebitTransaction();
                                NewDebitTransaction.Reference = rdReader2["MatchRef"].ToString().Trim();
                                NewDebitTransaction.Description = rdReader2["Description"].ToString().Trim();
                                NewDebitTransaction.Value = Convert.ToDecimal(rdReader2["Amount"].ToString());
                                NewDebitTransaction.TransDate = Convert.ToDateTime(rdReader2["DDate"].ToString());
                                sActiveInvoice = rdReader2["MatchRef"].ToString().Trim();
                                lsTransactionList.Add(NewDebitTransaction);
                            }
                            else //credit transaction
                            {
                                var NewCreditTransaction = new CreditTransaction();
                                NewCreditTransaction.Reference = rdReader2["Ref"].ToString().Trim(); ;
                                NewCreditTransaction.Description = rdReader2["Description"].ToString().Trim();
                                NewCreditTransaction.Value = Convert.ToDecimal(rdReader2["Amount"].ToString().Replace("-", ""));
                                NewCreditTransaction.TransDate = Convert.ToDateTime(rdReader2["DDate"].ToString());
                                sActiveInvoice = rdReader2["MatchRef"].ToString().Trim();
                                lsTransactionList.Add(NewCreditTransaction);
                            }
                        }
                        else if (sActiveInvoice == sNewInvoice)
                        {
                                                       
                            if (rdReader2["Amount"].ToString().Substring(0, 1) != "-")  //debitTransaction
                            {
                                var NewDebitTransaction = new DebitTransaction();
                                NewDebitTransaction.Reference = rdReader2["MatchRef"].ToString().Trim();
                                NewDebitTransaction.Description = rdReader2["Description"].ToString().Trim();
                                NewDebitTransaction.Value = Convert.ToDecimal(rdReader2["Amount"].ToString());
                                NewDebitTransaction.TransDate = Convert.ToDateTime(rdReader2["DDate"].ToString());
                                sActiveInvoice = rdReader2["MatchRef"].ToString().Trim();
                                lsTransactionList.Add(NewDebitTransaction);
                            }
                            else //debit transaction
                            {
                                var NewCreditTransaction = new CreditTransaction();
                                NewCreditTransaction.Reference = rdReader2["Ref"].ToString().Trim(); ;
                                NewCreditTransaction.Description = rdReader2["Description"].ToString().Trim();
                                NewCreditTransaction.Value = Convert.ToDecimal(rdReader2["Amount"].ToString().Replace("-", ""));
                                NewCreditTransaction.TransDate = Convert.ToDateTime(rdReader2["DDate"].ToString());
                                sActiveInvoice = rdReader2["MatchRef"].ToString().Trim();
                                lsTransactionList.Add(NewCreditTransaction);
                            }
                        }
                        sOldInvoice = sNewInvoice;
                    }
                    rdReader2.Close();
                }
                oSConn.Dispose();
            }
            int iLength = sExceptionList.Length - 1;
            sExceptionList = sExceptionList.Remove(iLength);
            sExceptionList += ")";

            return lsTransactionList;
        }
        public List<Transaction> lsGetTransactionHistory(string sCustomerCode, DateTime dtDateFrom, DateTime dtDateTo)
        {
            var lsTransactionList = new List<Transaction>();
            string sSql = String.Format("Select Top 6 AccNumber,DDate,Amount,Description,Refrence From LedgerTransactions where Amount < 0 AND AccNumber = '{0}' AND DDate <= '{1:yyyy-MM-dd}' order by DDate desc", sCustomerCode, dtDateTo);
            using (PsqlConnection oSConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                oSConn.Open();
                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oSConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        if (rdReader["Amount"].ToString().Substring(0, 1) == "-")  //creditTransaction
                        {
                            var NewCreditTransaction = new CreditTransaction();
                            NewCreditTransaction.Reference = rdReader["Refrence"].ToString().Trim();
                            NewCreditTransaction.Description = rdReader["Description"].ToString().Trim();
                            NewCreditTransaction.Value = Convert.ToDecimal(rdReader["Amount"].ToString());
                            // NewCreditTransaction.Balance = 1532.57m;
                            NewCreditTransaction.TransDate = Convert.ToDateTime(rdReader["DDate"].ToString());
                            NewCreditTransaction.ClientCode = rdReader["AccNumber"].ToString();
                            lsTransactionList.Add(NewCreditTransaction);
                        }                      
                    }
                    rdReader.Close();
                }
                oSConn.Dispose();
            }
            return lsTransactionList;
        }       
    }
}
