using Autofac;
using VuelingExam.Common.Mapper;

namespace VuelingExam.Facade.Impl.Api.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mapper>()
                .SingleInstance()
                .AsSelf();

            base.Load(builder);
        }
    }
}
