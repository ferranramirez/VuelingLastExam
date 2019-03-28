using Autofac;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Modules
{
    public class DomainApplicationModule : Module
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
