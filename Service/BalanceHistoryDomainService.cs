using System;
using Liquid.Domain;
using Pervasive.Data.SqlClient;


namespace Liquid.Services
{
    public class BalanceHistoryDomainService
    {
        public decimal iCurrentPeriod;
        public decimal i30Period;
        public decimal i60Period;
        public decimal i90Period;
        public decimal i120Period;

        public decimal dCurrentbalance = 0;
        public decimal d30Balance = 0;
        public decimal d60Balance = 0;
        public decimal d90Balance = 0;
        public decimal d120Balance = 0;
           
        public BalanceHistory GetBalanceHistory(string sCustomerCode)
        {
            var balancehistory = new BalanceHistory();
            balancehistory = CalculateBalance(balancehistory,sCustomerCode);                              
            return balancehistory;
        }

        private void GetValidPeriods(int iCurrentPeriod)
        {
            if (iCurrentPeriod == 1)
            {
                i30Period = -12;
                i60Period = -11;
                i90Period = -10;
                i120Period = -9;

            }
            else if (iCurrentPeriod == 2)
            {
                i30Period = 1;
                i60Period = -12;
                i90Period = -11;
                i120Period = -10;
            }
            else if (iCurrentPeriod == 3)
            {
                i30Period = 2;
                i60Period = 1;
                i90Period = -12;
                i120Period = -11;
            }
            else if (iCurrentPeriod == 4)
            {
                i30Period = 3;
                i60Period = 2;
                i90Period = 1;
                i120Period = -12;
            }
            else if (iCurrentPeriod == 5)
            {
                i30Period = 4;
                i60Period = 3;
                i90Period = 2;
                i120Period = 1;
            }
            else if (iCurrentPeriod == 6)
            {
                i30Period = 5;
                i60Period = 4;
                i90Period = 3;
                i120Period = 2;
            }
            else if (iCurrentPeriod == 7)
            {
                i30Period = 6;
                i60Period = 5;
                i90Period = 4;
                i120Period = 3;
            }
            else if (iCurrentPeriod == 8)
            {
                i30Period = 7;
                i60Period = 6;
                i90Period = 5;
                i120Period = 4;
            }
            else if (iCurrentPeriod == 9)
            {
                i30Period = 8;
                i60Period = 7;
                i90Period = 6;
                i120Period = 5;
            }
            else if (iCurrentPeriod == 10)
            {
                i30Period = 9;
                i60Period = 8;
                i90Period = 7;
                i120Period = 6;
            }
            else if (iCurrentPeriod == 11)
            {
                i30Period = 10;
                i60Period = 9;
                i90Period = 8;
                i120Period = 7;
            }
            else if (iCurrentPeriod == 12)
            {
                i30Period = 11;
                i60Period = 10;
                i90Period = 9;
                i120Period = 8;
            }

        }

        private static decimal CalculateBalanceThis(string sCustomer, string sInvoice,string sPeriod)
        {
            decimal dBalance = 0;          
            using (PsqlConnection oPasConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
               string sSqlMatch = "Select Original,MatchRef,sum(Amount) Amount";
                        sSqlMatch += String.Format(" from OpenItem where CSCode = '{0}' AND Original = 5", sCustomer);
                        sSqlMatch += String.Format(" AND ltrim(rtrim(MatchRef)) = '{0}'", sInvoice);
                        sSqlMatch += " group by  MatchRef,Original";

                        using (PsqlDataReader rdReaderMatch = Classes.Connect.getDataCommand(sSqlMatch, oPasConn).ExecuteReader())
                        {
                            while (rdReaderMatch.Read())
                            {
                                dBalance += Convert.ToDecimal(rdReaderMatch["Amount"].ToString());                            
                            }                         
                            rdReaderMatch.Close();
                        }
                oPasConn.Dispose();            
            }

          
            return dBalance;
        }
        private static decimal CalculateUnReferencedBalances(string sCustomer)
        {
            decimal dBalance = 0;
            //check for unrefrenced balances in period
            using (PsqlConnection oPasConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                string sSql = String.Format("select Original, PPeriod, MatchRef ,Amount from OpenItem where CSCode = '{0}'", sCustomer);
                sSql += " AND Original = 5 AND MatchRef = ''";
                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oPasConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        dBalance += Convert.ToDecimal(rdReader["Amount"].ToString());
                    }
                    rdReader.Close();
                }
                oPasConn.Dispose();
            }
            return dBalance;
        }
        private BalanceHistory CalculateBalance( BalanceHistory balancehistory, string sCustomer)
        {         
            int iCurrentPeriod = 0;
            dCurrentbalance = 0;
            d30Balance = 0;
            d60Balance = 0;
            d90Balance = 0;
            d120Balance = 0;
          
            using (PsqlConnection oPasConn = new PsqlConnection(Classes.Connect.PastelConnectionString))
            {
                oPasConn.Open();
                string sSql = "Select CurrentPeriod From LedgerParameters";
                iCurrentPeriod = Convert.ToInt32(Classes.Connect.getDataCommand(sSql, oPasConn).ExecuteScalar().ToString());
                
                GetValidPeriods(iCurrentPeriod);

                sSql = "select Original, PPeriod, MatchRef ,sum(Amount) Amount ";
                sSql += "from OpenItem ";
                sSql += String.Format("where CSCode = '{0}'  AND Original = 1", sCustomer);
                sSql += String.Format(" and PPeriod <= {0} ", iCurrentPeriod); 
                sSql += "group by Original, PPeriod, MatchRef order by PPeriod desc";
                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oPasConn).ExecuteReader())
                {
                    decimal dPeriodBalance = 0;
                    string sOldPeriod = "";
                    dPeriodBalance = CalculateUnReferencedBalances(sCustomer);
                    while (rdReader.Read())
                    {
                        string sThisPeriod = rdReader["PPeriod"].ToString().Trim();
                        string sInvoice = rdReader["MatchRef"].ToString().Trim();                      
                                             
                        if (sThisPeriod != sOldPeriod) //calculate balance for new/next period
                        {
                            if (iCurrentPeriod.ToString() == sOldPeriod)
                            {
                                dCurrentbalance = dPeriodBalance;

                            }
                            else if (i30Period.ToString() == sOldPeriod)
                            {
                                d30Balance = dPeriodBalance;
                            }
                            else if (i60Period.ToString() == sOldPeriod)
                            {
                                d60Balance = dPeriodBalance;
                            }
                            else if (i90Period.ToString() == sOldPeriod)
                            {
                                d90Balance = dPeriodBalance;
                            }
                            else 
                            {
                                d120Balance += dPeriodBalance;
                            }
                            dPeriodBalance = 0;
                        }
                        dPeriodBalance += Convert.ToDecimal(rdReader["Amount"].ToString());
                        dPeriodBalance += CalculateBalanceThis(sCustomer, sInvoice,sThisPeriod);
                      
                        sOldPeriod = sThisPeriod;
                    }
                    //insert last period details
                            if (iCurrentPeriod.ToString() == sOldPeriod)
                            {
                                dCurrentbalance = dPeriodBalance;
                            }
                            else if (i30Period.ToString() == sOldPeriod)
                            {
                                d30Balance = dPeriodBalance;
                            }
                            else if (i60Period.ToString() == sOldPeriod)
                            {
                                d60Balance = dPeriodBalance;
                            }
                            else if (i90Period.ToString() == sOldPeriod)
                            {
                                d90Balance = dPeriodBalance;
                            }
                            else 
                            {
                                d120Balance += dPeriodBalance;
                            }
                    
                    rdReader.Close();
                }
                oPasConn.Dispose();
            }
            balancehistory.Current = dCurrentbalance;
            balancehistory.Days120 = d120Balance;
            balancehistory.Days90 = d90Balance;
            balancehistory.Days60 = d60Balance;
            balancehistory.Days30 = d30Balance;
            balancehistory.AmountDue = dCurrentbalance + d120Balance + d90Balance + d60Balance + d30Balance;
            return balancehistory;
        }
    }
}
