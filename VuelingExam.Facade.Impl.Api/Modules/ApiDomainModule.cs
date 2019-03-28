using Autofac;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Facade.Impl.Api.Modules
{
    public class ApiDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FetchService>()
                .As<IFetchService>();

            builder
                .RegisterType<TipCalculatorService>()
                .As<ITipCalculatorService>();

            base.Load(builder);
        }
    }
}
