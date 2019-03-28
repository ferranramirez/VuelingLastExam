using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Test.Integration.Modules;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;

namespace VuelingExam.Application.Test.Integration
{
    [TestClass]
    public class FetchServiceApplicationTests : IoCSupportedTest<ApplicationModule>
    {
        IFetchServiceApplication fetchService;

        [TestInitialize]
        public void SetUp()
        {
            ConfigHelper.CleanDatabase();
            fetchService = Resolve<IFetchServiceApplication>();
        }

        [TestMethod]
        public void FetchAndStoreTest()
        {
            Assert.IsTrue(fetchService.FetchAndStore());
        }
    }
}
