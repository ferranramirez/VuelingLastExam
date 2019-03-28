using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Infrastructure.Test.Unit
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        TransactionRepository transactionRepository;
        List<TransactionDM> transactionDMList;

        [TestInitialize]
        public void SetUp()
        {
            transactionRepository = new TransactionRepository(null);
            transactionDMList = new List<TransactionDM>
            {
                new TransactionDM("T001", 12.34m, "EUR"),
                new TransactionDM("T002", 15.54m, "EUR"),
                new TransactionDM("T003", 2.04m, "DOL")
            };
        }

        [TestMethod]
        public void ReadAllTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionRepository>().Setup(x => x.ReadAll()).Returns(transactionDMList);
                var sut = mock.Create<ITransactionRepository>();

                var actual = sut.ReadAll();
                mock.Mock<ITransactionRepository>().Verify(x => x.ReadAll());
                Assert.AreEqual(transactionDMList, actual);
            }
        }

        [TestMethod]
        public void CreateTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ITransactionRepository>().Setup(x =>
                    x.CreateAll(transactionDMList)).Returns(transactionDMList);
                var sut = mock.Create<ITransactionRepository>();

                var actual = sut.CreateAll(transactionDMList);
                mock.Mock<ITransactionRepository>().Verify(x =>
                    x.CreateAll(transactionDMList));
                Assert.AreEqual(transactionDMList, actual);
            }
        }
    }
}
