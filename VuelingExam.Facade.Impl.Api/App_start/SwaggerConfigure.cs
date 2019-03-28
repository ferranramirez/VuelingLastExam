using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelingExam.Facade.Impl.Api.App_start
{
    public class SwaggerConfigure
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "VuelingExamV1",
                    Description = "Vueling Exam v1",
                    TermsOfService = "None"
                });
                c.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "VuelingExamV2",
                    Description = "Vueling Exam v2",
                    TermsOfService = "None"
                });
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var versions = apiDesc.ControllerAttributes()
                    .OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
            });
        }
    }
}
