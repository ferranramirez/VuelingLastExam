using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Infrastructure.Test.Unit
{
    [TestClass]
    public class RateRepositoryTests
    {
        RateRepository rateRepository;
        List<RateDM> rateDMList;

        [TestInitialize]
        public void SetUp()
        {
            rateRepository = new RateRepository();
            rateDMList = new List<RateDM>
            {
                new RateDM("RBR", "YEN", 15.55m),
                new RateDM("EUR", "PES", 23.32m),
                new RateDM("DOL", "COL", 0.25m)
            };
        }

        [TestMethod]
        public void ReadAllTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRateRepository>().Setup(x => x.ReadAll()).Returns(rateDMList);
                var sut = mock.Create<IRateRepository>();

                var actual = sut.ReadAll();
                mock.Mock<IRateRepository>().Verify(x => x.ReadAll());
                Assert.AreEqual(rateDMList, actual);
            }
        }

        [TestMethod]
        public void CreateTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRateRepository>().Setup(x => x.CreateAll(rateDMList)).Returns(rateDMList);
                var sut = mock.Create<IRateRepository>();

                var actual = sut.CreateAll(rateDMList);
                mock.Mock<IRateRepository>().Verify(x => x.CreateAll(rateDMList));
                Assert.AreEqual(rateDMList, actual);
            }
        }
    }
}
