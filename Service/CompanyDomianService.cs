using Liquid.Domain;
using Pervasive.Data.SqlClient;

namespace Liquid.Services
{
    public class CompanyDomianService
    {
        public Company GetCompany()
        {
            Company company = new Company();
            string sSql = "Select CompanyName,RegistrationNum, VATNumber,GroupName,Postal1,Postal2,Postal3,Postalzip,TelephoneNumber,FaxNumber";
            sSql += " FROM SOLCS";
            using (PsqlConnection oSConn = new PsqlConnection(Classes.Connect.LiquidConnectionString))
            {
                oSConn.Open();

                using (PsqlDataReader rdReader = Classes.Connect.getDataCommand(sSql, oSConn).ExecuteReader())
                {
                    while (rdReader.Read())
                    {
                        company.CompanyAddress1 = rdReader["Postal1"].ToString();
                        company.CompanyAddress2 = rdReader["Postal2"].ToString();
                        company.CompanyAddress3 = rdReader["Postal3"].ToString();
                        company.CompanyAddress4 = rdReader["PostalZip"].ToString();
                        company.CompanyDescription = rdReader["GroupName"].ToString();
                        company.CompanyFax = rdReader["FaxNumber"].ToString();
                        company.CompanyName = rdReader["CompanyName"].ToString();
                        company.CompanyRegNo = rdReader["RegistrationNum"].ToString();
                        company.CompanyTel = rdReader["TelephoneNumber"].ToString();                     
                        company.CompanyVAT = rdReader["VatNumber"].ToString();
                            

                    }
                    rdReader.Close();
                }
                oSConn.Dispose();
            }
            return company;
        }
        public Company GetDummyCompany()
        {
            Company company = new Company();
            //company.CompanyDescription = "Company NAME";
            //company.CompanyVAT = "Company VAT";
            //company.CompanyRegNo = "Company REG NUMBER";
            //company.CompanyPOBox = "Company PO BOX";
            //company.CompanyStreetName = "Company STREET NAME";
            //company.CompanyTown = "Company TOWN";
            //company.CompanyAreaCode = "Company AREA CODE";

            return company;

        }
    }
}
