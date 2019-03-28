using Autofac;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Common.Logic.Helpers;

namespace VuelingExam.Facade.Impl.Api.App_start
{
    public class FetchConfigureStart : IStartable
    {
        IFetchServiceApplication FetchServiceApplication;
        public FetchConfigureStart(IFetchServiceApplication fetchServiceApplication)
        {
            FetchServiceApplication = fetchServiceApplication;
            Start();
        }
        public void Start()
        {
            ConfigHelper.CleanDatabase();
            FetchServiceApplication.FetchAndStore();
        }
    }
}
