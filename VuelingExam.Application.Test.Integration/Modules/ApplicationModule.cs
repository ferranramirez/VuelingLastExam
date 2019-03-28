using Autofac;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary;
using VuelingExam.Common.Mapper;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Application.Test.Integration.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FetchServiceApplication>()
                .As<IFetchServiceApplication>();

            builder
                .RegisterType<FetchService>()
                .As<IFetchService>();

            builder
                .RegisterType<TipCalculatorService>()
                .As<ITipCalculatorService>();

            builder
                .RegisterType<Mapper>()
                .SingleInstance()
                .AsSelf();

            builder
                .RegisterType<RateRepository>()
                .As<IRateRepository>();

            builder
                .RegisterType<TransactionRepository>()
                .As<ITransactionRepository>();

            base.Load(builder);
        }
    }
}
