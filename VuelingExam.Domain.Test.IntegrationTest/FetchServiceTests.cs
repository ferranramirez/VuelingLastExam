using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Domain.Test.IntegrationTest
{

    [TestClass]
    public class FetchServiceTests
    {
        FetchService fetchService;
        
        [TestInitialize]
        public void SetUp()
        {
            fetchService = new FetchService();
        }

        [TestMethod]
        public void FetchRatesTest()
        {
            fetchService.FetchRates();
            Assert.IsFalse(true);
        }

    }
}
