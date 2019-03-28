using Autofac;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.Impl.Repository;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Modules
{
    public class RepositoryApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
