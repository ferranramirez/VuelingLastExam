using Autofac;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary;
using VuelingExam.Application.DTO;

namespace VuelingExam.Facade.Impl.Api.Modules
{
    public class ApiApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FetchServiceApplication>()
                .As<IFetchServiceApplication>();

            builder
                .RegisterType<RateApplication>()
                .As<IApplication<RateDTO>>();

            builder
                .RegisterType<TransactionApplication>()
                .As<IApplication<TransactionDTO>>();

            builder
                .RegisterType<TipCalculatorServiceApplication>()
                .As<ITipCalculatorServiceApplication>();

            base.Load(builder);
        }
    }
}
