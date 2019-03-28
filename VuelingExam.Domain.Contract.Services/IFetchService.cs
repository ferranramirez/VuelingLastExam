using System;
using System.Collections.Generic;
using System.Text;
using VuelingExam.Domain.BusinessEntities;

namespace VuelingExam.Domain.Contract.Services
{
    public interface IFetchService
    {

        List<RateBE> FetchRates();

        List<TransactionBE> FetchTransactions();
    }
}
