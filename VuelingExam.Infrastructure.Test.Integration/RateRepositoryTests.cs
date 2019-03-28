using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Infrastructure.Test.Integration
{
    [TestClass]
    public class RateRepositoryTests
    {
        RateRepository rateRepository;
        List<RateDM> rateDMList, createdRateDMList;

        [TestInitialize]
        public void SetUp()
        {
            ConfigHelper.CleanDatabase();
            rateRepository = new RateRepository();
            createdRateDMList = new List<RateDM>();
            rateDMList = new List<RateDM>
            {
                new RateDM("RBR", "YEN", 15.55m),
                new RateDM("EUR", "PES", 23.32m),
                new RateDM("DOL", "COL", 0.25m)
            };

            for(int i = 0; i < rateDMList.Count; i++)
            {
                RateDM created = rateRepository.Create(rateDMList[i]);
                createdRateDMList.Add(created);
            }
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

        [TestMethod]
        public void BulkCreateAllTest()
        {
            var actual = rateRepository.CreateAll(rateDMList);
            CollectionAssert.AreEqual(rateDMList, createdRateDMList);
        }
    }
}
