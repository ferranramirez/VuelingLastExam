using Autofac;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Domain.Test.Integration.Modules
{
    public class DomainModule : Module
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
