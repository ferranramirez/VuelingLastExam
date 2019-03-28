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
            rateList = HttpRequest<RateBE>(StringResources.RatesUri);
            return rateList;
        }

        public List<TransactionBE> FetchTransactions()
        {
            List<TransactionBE> transactionList;
            transactionList = HttpRequest<TransactionBE>(StringResources.TransactionsUri);
            return transactionList;
        }

        private static List<T> HttpRequest<T>(string FileUri)
        {
            List<T> resultList;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(StringResources.UriApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponse = httpClient.GetAsync(FileUri).Result;
                string result = httpResponse.Content.ReadAsStringAsync().Result;

                resultList = JsonConvert.DeserializeObject<List<T>>(result.ToString());
            }

            return resultList;
        }
    }
}
