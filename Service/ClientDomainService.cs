using System;
using System.Collections.Generic;
using Liquid.Domain;
using Pervasive.Data.SqlClient;

namespace Liquid.Services
{
    public class ClientDomainService
    {

        public List<Client> GetClientInfo(string sCustomerFrom, string sCustomerTo, DateTime dtDateFrom, DateTime dtDateTo)
        {
            string sCustomer = "";
            var clientlist = new List<Client>();
         
            string sSql = "Select CustomerMaster.CustomerCode,CustomerDesc,PostAddress01,PostAddress02,PostAddress03,PostAddress04, Telephone,Cell,Fax,ExemptRef";
            sSql += String.Format(" FROM CustomerMaster inner join DeliveryAddresses on CustomerMaster.CustomerCode = DeliveryAddresses.CustomerCode AND DeliveryAddresses.CustDelivCode = '' where CustomerMaster.CustomerCode >= '{0}' AND CustomerMaster.CustomerCode <= '{1}'", sCustomerFrom, sCustomerTo);
            using (PsqlConnection oPasConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                oPasConn.Open();
                              
                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oPasConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        if (sCustomer != rdReader["CustomerCode"].ToString())
                        {
                            var client = new Client();
                            client.ClientAddress1 = rdReader["PostAddress01"].ToString();
                            client.ClientAddress2 = rdReader["PostAddress02"].ToString();
                            client.ClientAddress3 = rdReader["PostAddress03"].ToString();
                            client.ClientAddress4 = rdReader["PostAddress04"].ToString();
                            client.ClientCell = rdReader["Cell"].ToString();
                            client.ClientCode = rdReader["CustomerCode"].ToString();
                            client.ClientTelephone = rdReader["Telephone"].ToString();
                            client.ClientVat = rdReader["ExemptRef"].ToString();
                            client.ClientDescription = rdReader["CustomerDesc"].ToString();
                            BalanceHistoryDomainService balanceHistoryService = new BalanceHistoryDomainService();
                            client.BalanceHistory = balanceHistoryService.GetBalanceHistory(client.ClientCode);
                            var TransactionService = new TransactionDomainService();
                            client.Transactions = TransactionService.lsGetTransactions(client.ClientCode, dtDateFrom, dtDateTo);
                            client.TransactionHistory = TransactionService.lsGetTransactionHistory(client.ClientCode, dtDateFrom, dtDateTo);
                            clientlist.Add(client);
                            sCustomer = rdReader["CustomerCode"].ToString();
                        }
                    }
                    rdReader.Close();
                }
                oPasConn.Dispose();              
            }    
           return clientlist;
        }        
    }
}
