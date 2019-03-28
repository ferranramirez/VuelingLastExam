using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions;
using VuelingExam.Domain.Impl.Services.Exceptions;
using System.Net;
using System;

namespace VuelingExam.Facade.Impl.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode status = new HttpStatusCode();
            Exception exception = context.Exception;
            if (exception is VuelingExamApplicationException)
            {
                context.ExceptionHandled = true;
                if (exception.InnerException is VuelingExamDomainException)
                {
                    status = HttpStatusCode.FailedDependency;
                    SetHttpResponse(context, status);
                }
                else
                {
                    status = HttpStatusCode.ServiceUnavailable;
                    SetHttpResponse(context, status);
                }
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                SetHttpResponse(context, status);
            }
        }

        private static void SetHttpResponse(ExceptionContext context, HttpStatusCode status)
        {
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
        }
    }
}
