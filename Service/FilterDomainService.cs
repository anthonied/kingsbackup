using System;
using System.Collections.Generic;
using System.Text;
using Pervasive.Data.SqlClient;

namespace Solsage_Process_Management_System.Service
{
    public class FilterDomainService
    {
        public List<string> GetFilterCustomerList(string sCustomerFrom,string sCustomerTo)
        {
            List<string> CustomerList = new List<string>();
            string sSql = "Select CustomerCode FROM CustomerMaster where CustomerCode > '" + sCustomerFrom + "' ANS CustomerCode < '" + sCustomerTo + "'";         
            using (PsqlConnection oSConn = new PsqlConnection(Classes.Connect.sConnStr))
            {
                oSConn.Open();
                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oSConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        CustomerList.Add(rdReader["CustomerCode"].ToString());
                    }
                    rdReader.Close();
                }
                oSConn.Dispose();
            }
            return CustomerList;
        }
    }
}
