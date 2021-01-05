using System;
using Serilog;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Booth.Management.Api.Infrastructure.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next,
                                   ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var exceptionDetails = new ExceptionDetails(context.Response.StatusCode,
                                                 exception.Message);

            var exceptionDetailsJson = JsonConvert.SerializeObject(exceptionDetails);

            _logger.Error(exceptionDetailsJson);

            return context.Response.WriteAsync(exceptionDetailsJson);
        }
    }

    public struct ExceptionDetails
    {
        private int StatusCode { get; set; }

        private string Message { get; set; }

        public ExceptionDetails(int statusCode,
                                string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
