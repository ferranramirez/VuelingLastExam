using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Infrastructure.Test.Integration
{
    [TestClass]
    public class RateRepositoryTests
    {
        RateRepository rateRepository;

        [TestInitialize]
        public void SetUp()
        {
            rateRepository = new RateRepository();
        }

        [TestMethod]
        public void ReadAllTest()
        {
            var actual = rateRepository.ReadAll();
            Assert.IsFalse(true);
        }
    }
}
