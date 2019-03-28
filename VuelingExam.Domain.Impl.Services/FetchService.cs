using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services.Resources;

namespace VuelingExam.Domain.Impl.Services
{
    public class FetchService : IFetchService
    {
        public List<RateBE> FetchRates()
        {
            List<RateBE> rateList;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(StringResources.UriApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponse = httpClient.GetAsync(StringResources.RatesUri).Result;
                string result = httpResponse.Content.ReadAsStringAsync().Result;
                
                rateList = JsonConvert.DeserializeObject<List<RateBE>>(result.ToString());
            }
            return rateList;
        }

        public List<TransactionBE> FetchTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
