using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services.Exceptions;
using VuelingExam.Domain.Impl.Services.Resources;

namespace VuelingExam.Domain.Impl.Services
{
    public class FetchService : IFetchService
    {
        public List<RateBE> FetchRates()
        {
            List<RateBE> rateList;
            try
            {
                rateList = HttpRequest<RateBE>(StringResources.RatesUri);
            }
            #region Exceptions
            catch (ArgumentNullException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (HttpRequestException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return rateList;
        }

        public List<TransactionBE> FetchTransactions()
        {
            List<TransactionBE> transactionList;
            try
            {
                transactionList = HttpRequest<TransactionBE>(StringResources.TransactionsUri);
            }
            #region Exceptions
            catch (ArgumentNullException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (HttpRequestException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return transactionList;
        }

        private static List<T> HttpRequest<T>(string FileUri)
        {
            List<T> resultList;
            try
            {
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
            }
            #region Exceptions
            catch (ArgumentNullException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            catch (HttpRequestException e)
            {
                throw new VuelingExamDomainException(e.Message, e.InnerException);
            }
            #endregion
            return resultList;
        }
    }
}
