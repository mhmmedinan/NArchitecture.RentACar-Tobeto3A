using Microsoft.AspNetCore.Builder;

namespace Core.CrossCutting.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void
        ConfigureCustomExceptionMiddleware
        (this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}
