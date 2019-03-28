using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Domain.Test.Integration
{
    [TestClass]
    public class TipCalculatorServiceTests
    {
        TipCalculatorService tipCalculatorService;
        List<RateBE> rateList;
        TransactionBE transactionBE;

        [TestInitialize]
        public void SetUp()
        {
            tipCalculatorService = new TipCalculatorService();
            rateList = new List<RateBE>
            {
                new RateBE("EUR", "USD", 0.87m),
                new RateBE("USD", "EUR", 1.15m),
                new RateBE("EUR", "CAD", 0.73m),
                new RateBE("CAD", "EUR", 1.37m),
                new RateBE("USD", "AUD", 1.37m),
                new RateBE("AUD", "USD", 0.73m)
            };
            tipCalculatorService.GenerateGraph(rateList);
            transactionBE = new TransactionBE("T001", 10, "EUR");
        }
        
        [DataTestMethod]
        [DataRow("EUR", "USD", "0.87")]
        [DataRow("USD", "EUR", "1.15")]
        [DataRow("EUR", "CAD", "0.73")]
        [DataRow("CAD", "EUR", "1.37")]
        [DataRow("CAD", "EUR", "1.37")]
        [DataRow("AUD", "USD", "0.73")]
        [DataRow("EUR", "AUD", "1.19")]
        public void DFSAlgorythmTest(string from, string to, string rate)
        {
            decimal actual = tipCalculatorService.RecursiveDFS(from, to);
            Assert.AreEqual(Decimal.Parse(rate), actual);
        }
        
        [TestMethod]
        public void GetTipTest()
        {
            decimal actual = tipCalculatorService.GetTip(rateList, transactionBE, "USD");
            Assert.AreEqual(8.7m, actual);
        }
    }
}
