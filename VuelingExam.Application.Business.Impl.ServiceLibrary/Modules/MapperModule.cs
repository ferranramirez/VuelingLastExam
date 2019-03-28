using Autofac;
using VuelingExam.Common.Mapper;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Modules
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
