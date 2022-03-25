using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Liquid.Classes
{
    public class BlackListApiClient
    {

       HttpClient client = new HttpClient();

        public Fraudster GetPossibleBlackListRecord( string zaId)
        {
            try
            {

                var _task = Task.Run(() => this.GetPossibleBlackListRecordAsync(zaId));
                _task.Wait();
                return _task.Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       public  async Task<Fraudster> GetPossibleBlackListRecordAsync(string zaId)
        {
            string baseAddress = ConfigurationManager.AppSettings["KingsFraudAPI"];
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Fraudster fraudster = null;
          
            HttpResponseMessage response = await client.GetAsync($"fraudster/za_id/{zaId}");
            if (response.IsSuccessStatusCode)
            {
                fraudster = await response.Content.ReadAsAsync<Fraudster>();
            }
            return fraudster;
        }

    }

    public class Fraudster
    {
        public int Id { get; set; }
        public string ZaId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
