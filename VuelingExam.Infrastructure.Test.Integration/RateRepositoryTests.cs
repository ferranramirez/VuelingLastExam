using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Test.Integration.Modules;

namespace VuelingExam.Infrastructure.Test.Integration
{
    [TestClass]
    public class RateRepositoryTests : IoCSupportedTest<InfrastructureModule>
    {
        IRateRepository rateRepository;
        List<RateDM> rateDMList, createdRateDMList;

        [TestInitialize]
        public void SetUp()
        {
            ConfigHelper.CleanDatabase();
            rateRepository = Resolve<IRateRepository>();
            createdRateDMList = new List<RateDM>();
            rateDMList = new List<RateDM>
            {
                new RateDM("RBR", "YEN", 15.55m),
                new RateDM("EUR", "PES", 23.32m),
                new RateDM("DOL", "COL", 0.25m)
            };
            createdRateDMList = rateRepository.CreateAll(rateDMList);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            var actual = rateRepository.ReadAll();
            CollectionAssert.AreEqual(rateDMList, actual);
        }

        [TestMethod]
        public void CreateTest()
        {
            CollectionAssert.AreEqual(rateDMList, createdRateDMList);
        }
    }
}
