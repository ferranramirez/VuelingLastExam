using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Domain.Test.Integration
{

    [TestClass]
    public class FetchServiceTests
    {
        FetchService fetchService;
        List<RateBE> fetchedRates;
        List<TransactionBE> fetchedTransactions;

        [TestInitialize]
        public void SetUp()
        {
            fetchService = new FetchService();
            fetchedRates = new List<RateBE>();
            fetchedTransactions = new List<TransactionBE>();
        }

        [TestMethod]
        public void FetchRatesTest()
        {
            Assert.AreEqual(fetchedRates.GetType(),
                fetchService.FetchRates().GetType());
        }

        [TestMethod]
        public void FetchTransactionsTest()
        {
            Assert.AreEqual(fetchedTransactions.GetType(),
                fetchService.FetchTransactions().GetType());
        }

    }
}
