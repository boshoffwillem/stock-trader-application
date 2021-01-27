using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradingApplication.FinancialModellingPrepApi
{
    public class FinancialApiHttpClient : HttpClient
    {
        public FinancialApiHttpClient()
        {
            BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
            
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var responseMessage = await GetAsync(uri);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var dd = JsonConvert.DeserializeObject<T>(jsonResponse);
            return dd;
        }
    }
}
