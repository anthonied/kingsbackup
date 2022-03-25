using System;
using System.Collections.Generic;
using Pervasive.Data.SqlClient;
using Liquid.Domain;

namespace Liquid.Service
{
    public class StatementOpenItemDomainService
    {
        public List<StatementOpenItem> GetStatementOpenItems(DateTime dtFromDate,DateTime dtTodate,string sCustomer, string sExceptions)
        {
            List<StatementOpenItem> OpenItemList = new List<StatementOpenItem>();
            using (PsqlConnection oConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                if (sExceptions == ")")
                {
                    sExceptions = "('')";
                        
                }
                oConn.Open();
                string sSql = "select MatchRef,Original,Description,Amount,Description,DDate,Ref";
                      sSql += " from OpenItem";
                      sSql += String.Format(" where CSCode = '{0}' AND ltrim(rtrim(MatchRef)) NOT IN " + sExceptions + "", sCustomer, dtFromDate.ToString("yyyy-MM-dd"), dtTodate.ToString("yyyy-MM-dd"));
                      sSql += " order by MatchRef,Original";

                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oConn).ExecuteReader())
                {                                     
                    StatementOpenItem OpenItemTransaction = new StatementOpenItem();
                    List<DebitTransaction> DebitList = new List<DebitTransaction>();
                    List<CreditTransaction> CreditList = new List<CreditTransaction>();
                    string sOldInvoice = "1";
                    while (rdReader.Read())
                    {
                        string sNewInvoice = rdReader["MatchRef"].ToString().Trim();

                        if (sNewInvoice != sOldInvoice && sOldInvoice != "1") //new invoice
                        {
                            OpenItemTransaction.Debit = DebitList;
                            OpenItemTransaction.Credit = CreditList;
                            OpenItemList.Add(OpenItemTransaction);

                            OpenItemTransaction = new StatementOpenItem();
                            DebitList = new List<DebitTransaction>();
                            CreditList = new List<CreditTransaction>();
                            OpenItemTransaction.MatchRef = sNewInvoice;
                        }
                        else if (sOldInvoice == "1")
                        {
                            OpenItemTransaction.MatchRef = sNewInvoice;
                        }

                        if (rdReader["Amount"].ToString().Substring(0, 1) != "-")  //debit
                        {
                            var NewDebitTransaction = new DebitTransaction();                          
                            NewDebitTransaction.Value = Convert.ToDecimal(rdReader["Amount"].ToString());
                            NewDebitTransaction.Description = rdReader["Description"].ToString().Trim();
                            NewDebitTransaction.TransDate = Convert.ToDateTime(rdReader["DDate"].ToString());
                            NewDebitTransaction.Reference = rdReader["Ref"].ToString().Trim();
                            DebitList.Add(NewDebitTransaction);
                           
                        }
                        else  //credit
                        {
                            var NewCreditTransaction = new CreditTransaction();
                            NewCreditTransaction.Value = Convert.ToDecimal(rdReader["Amount"].ToString().Replace("-",""));
                            NewCreditTransaction.Description = rdReader["Description"].ToString().Trim();
                            NewCreditTransaction.TransDate = Convert.ToDateTime(rdReader["DDate"].ToString());
                            NewCreditTransaction.Reference = rdReader["Ref"].ToString().Trim();
                            CreditList.Add(NewCreditTransaction);
                        }
                        OpenItemTransaction.Balance += Convert.ToDecimal(rdReader["Amount"].ToString());

                        sOldInvoice = sNewInvoice;
                    }
                    //put in last row
                    OpenItemTransaction.Debit = DebitList;
                    OpenItemTransaction.Credit = CreditList;
                    OpenItemList.Add(OpenItemTransaction);

                    rdReader.Close();
                }
                oConn.Dispose();
            }

            return OpenItemList;
        }
    }
}
