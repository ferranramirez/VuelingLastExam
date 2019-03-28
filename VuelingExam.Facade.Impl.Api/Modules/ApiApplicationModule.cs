using Autofac;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary;
using VuelingExam.Application.DTO;
using VuelingExam.Facade.Impl.Api.App_start;

namespace VuelingExam.Facade.Impl.Api.Modules
{
    public class ApiApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FetchServiceApplication>()
                .As<IFetchServiceApplication>()
                .AutoActivate();

            builder
                .RegisterType<RateApplication>()
                .As<IApplication<RateDTO>>();

            builder
                .RegisterType<TransactionApplication>()
                .As<IApplication<TransactionDTO>>();

            builder
                .RegisterType<TipCalculatorServiceApplication>()
                .As<ITipCalculatorServiceApplication>();

            builder
               .RegisterType<FetchConfigureStart>()
               .AsSelf()
               .AutoActivate();

            base.Load(builder);
        }
    }
}
