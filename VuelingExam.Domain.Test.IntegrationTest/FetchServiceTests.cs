using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Test.Integration.Modules;

namespace VuelingExam.Domain.Test.Integration
{

    [TestClass]
    public class FetchServiceTests : IoCSupportedTest<DomainModule>
    {
        IFetchService fetchService;
        List<RateBE> fetchedRates;
        List<TransactionBE> fetchedTransactions;

        [TestInitialize]
        public void SetUp()
        {
            fetchService = Resolve<IFetchService>();
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
