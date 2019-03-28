using Autofac;
using Autofac.Integration.WebApi;
using AutofacSerilogIntegration;
using Serilog;
using System.Reflection;
using VuelingExam.Common.Logic.Helpers;

namespace VuelingExam.Facade.Impl.Api.Modules
{
    public class LoggerApiModule : Autofac.Module
    {
        public static string LogPath = ConfigHelper.AppSettings["SeriLogPath"];
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterLogger(
                new LoggerConfiguration()
                    .WriteTo.File(LogPath)
                    .WriteTo.Console()
                    .MinimumLevel.Debug()
                    .CreateLogger()
                    );

            base.Load(builder);
        }
    }
}
