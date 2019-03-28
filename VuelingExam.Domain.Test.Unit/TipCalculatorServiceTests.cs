using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Domain.Test.Unit
{
    [TestClass]
    public class TipCalculatorServiceTests
    {
        TipCalculatorService tipCalculatorService;
        List<RateBE> rateList;
        List<TransactionBE> transactionList;
        TransactionBE transactionBE;
        BillBE billBE;
        TipBE tipBE;

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

            transactionList = new List<TransactionBE>
            {
                transactionBE
            };
            tipBE = new TipBE("T001", 10, 0.50m, "EUR");
            List<TipBE> tipList = new List<TipBE>
            {
                tipBE
            };
            billBE = new BillBE(0.50m, "USD", tipList);
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
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITipCalculatorService>().Setup(x =>
                    x.RecursiveDFS(from, to)).Returns(Decimal.Parse(rate));
                var sut = mock.Create<ITipCalculatorService>();

                var actual = sut.RecursiveDFS(from, to);
                mock.Mock<ITipCalculatorService>().Verify(x =>
                    x.RecursiveDFS(from, to));
                Assert.AreEqual(Decimal.Parse(rate), actual);
            }
        }

        [TestMethod]
        public void GetTransactionAmountTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITipCalculatorService>().Setup(x =>
                    x.GetTransactionAmount(transactionBE, "USD")).Returns(0.50m);
                var sut = mock.Create<ITipCalculatorService>();

                var actual = sut.GetTransactionAmount(transactionBE, "USD");
                mock.Mock<ITipCalculatorService>().Verify(x =>
                    x.GetTransactionAmount(transactionBE, "USD"));
                Assert.AreEqual(0.50m, actual);
            }
        }

        [TestMethod]
        public void GetBillTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITipCalculatorService>().Setup(x =>
                    x.GetBill(rateList, transactionList, "USD")).Returns(billBE);
                var sut = mock.Create<ITipCalculatorService>();

                var actual = sut.GetBill(rateList, transactionList, "USD");
                mock.Mock<ITipCalculatorService>().Verify(x =>
                    x.GetBill(rateList, transactionList, "USD"));
                Assert.AreEqual(billBE, actual);
            }
        }
    }
}
