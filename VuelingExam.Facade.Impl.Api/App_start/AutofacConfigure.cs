using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using VuelingExam.Facade.Impl.Api.Modules;

namespace VuelingExam.Facade.Impl.Api.App_start
{
    public class AutofacConfigure
    {
        public static IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApiApplicationModule>();
            builder.RegisterModule<ApiDomainModule>();
            builder.RegisterModule<ApiRepositoryModule>();
            builder.RegisterModule<MapperModule>();

            builder.Populate(services);
            var container = builder.Build();
            return container;
        }
    }
}
