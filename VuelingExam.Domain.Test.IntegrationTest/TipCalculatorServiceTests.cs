using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Test.Integration.Modules;

namespace VuelingExam.Domain.Test.Integration
{
    [TestClass]
    public class TipCalculatorServiceTests : IoCSupportedTest<DomainModule>
    {
        ITipCalculatorService tipCalculatorService;
        List<RateBE> rateList;
        List<TransactionBE> transactionList;
        TransactionBE transactionBE;
        BillBE billBE;
        TipBE tipBE;

        [TestInitialize]
        public void SetUp()
        {
            tipCalculatorService = Resolve<ITipCalculatorService>();
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

            transactionList = new List<TransactionBE>
            {
                transactionBE
            };
            tipBE = new TipBE("T001", 10, 0.50m, "EUR");
            List<TipBE> tipList = new List<TipBE>
            {
                tipBE
            };
            billBE = new BillBE(8.70m, "USD", tipList);
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
        public void GetTransactionAmountTest()
        {
            decimal actual = tipCalculatorService.GetTransactionAmount(transactionBE, "USD");
            Assert.AreEqual(8.7m, actual);
        }

        [TestMethod]
        public void GetBillTest()
        {
            BillBE actual = tipCalculatorService.GetBill(rateList,
                transactionList, "USD");
            Assert.AreEqual(billBE, actual);
        }
    }
}
