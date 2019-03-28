using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VuelingExam.Facade.Impl.Api.App_start;
using VuelingExam.Facade.Impl.Api.Filters;

namespace VuelingExam.Facade.Impl.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                private static IServiceProvider AutofacService(IServiceCollection services)
        {
            var container = AutofacConfigure.Configure(services);
            return new AutofacServiceProvider(container);
        }

        private static void AddFilter(Microsoft.AspNetCore.Mvc.MvcOptions config)
        {
            config.Filters.Add(new CustomExceptionFilterAttribute());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                config =>
                {
                    AddFilter(config);
                });

            SwaggerConfigure.Configure(services);
            return AutofacService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VuelingLastExam");
            });
        }
    }
}
