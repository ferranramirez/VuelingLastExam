using Autofac;
using Autofac.Core;

namespace VuelingExam.Application.Test.Integration.Modules
{
    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private IContainer container;
        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
