using System;
using Liquid.Domain;

namespace Liquid.Services
{
    public class StatementDomainService
    {
        public void GetStatementFromPastel()
        {
            Statement statement = new Statement();
            //var ClientService = new ClientDomainService();
            //statement.Client = ClientService.GetClient(); 
        }
                
        public Statement GetPastelStatement(string sCustomerFrom, string sCustomerTo, DateTime dtDateFrom, DateTime dtDateTo)
        {
            Statement statement = new Statement();           
            var ClientService = new ClientDomainService();
            statement.Clients = ClientService.GetClientInfo(sCustomerFrom, sCustomerTo, dtDateFrom,dtDateTo);
                   
            var CompanyService = new CompanyDomianService();
            statement.Company = CompanyService.GetCompany();          
                        
            return statement;
        }

        
    }
}
