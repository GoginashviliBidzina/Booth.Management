using Microsoft.AspNetCore.Builder;

namespace Booth.Management.Api.Infrastructure.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionLoggingMiddleware>();
    }
}
