using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository;
using VuelingExam.Infrastructure.Test.Integration.Modules;

namespace VuelingExam.Infrastructure.Test.Integration
{
    [TestClass]
    public class TransactionRepositoryTests : IoCSupportedTest<InfrastructureModule>
    {
        ITransactionRepository transactionRepository;
        List<TransactionDM> transactionDMList, createdTransactionDMList, sameSkuTransactionDMList;
        TransactionDM transactionDM0, transactionDM1;

        [TestInitialize]
        public void SetUp()
        {
            ConfigHelper.CleanDatabase();
            transactionRepository = Resolve<ITransactionRepository>();

            createdTransactionDMList = new List<TransactionDM>();
            transactionDM0 = new TransactionDM("T001", 12.34m, "EUR");
            transactionDM1 = new TransactionDM("T001", 15.23m, "USD");

            sameSkuTransactionDMList = new List<TransactionDM>
            {
                transactionDM0,
                transactionDM1
            };

            transactionDMList = new List<TransactionDM>
            {
                transactionDM0,
                transactionDM1,
                new TransactionDM("T002", 15.54m, "EUR"),
                new TransactionDM("T003", 2.04m, "DOL")
            };
            createdTransactionDMList = transactionRepository.CreateAll(transactionDMList);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            var actual = transactionRepository.ReadAll();
            CollectionAssert.AreEqual(transactionDMList, actual);
        }

        [TestMethod]
        public void CreateTest()
        {
            CollectionAssert.AreEqual(transactionDMList, createdTransactionDMList);
        }

        [TestMethod]
        public void ReadBySkuTest()
        {
            var actual = transactionRepository.ReadBySku("T001");
            CollectionAssert.AreEqual(sameSkuTransactionDMList, actual);
        }
    }
}
