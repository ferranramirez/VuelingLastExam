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
        List<TransactionDM> transactionDMList, createdTransactionDMList;

        [TestInitialize]
        public void SetUp()
        {
            ConfigHelper.CleanDatabase();
            transactionRepository = Resolve<ITransactionRepository>();

            createdTransactionDMList = new List<TransactionDM>();
            transactionDMList = new List<TransactionDM>
            {
                new TransactionDM("T001", 12.34m, "EUR"),
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
    }
}
