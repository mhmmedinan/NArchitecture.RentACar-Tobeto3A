using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using Core.CrossCutting.Logging.Serilog;
using Core.CrossCutting.Logging.Serilog.Loggers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<Stopwatch>();

        services.AddSingleton<LoggerServiceBase, MongoDbLogger>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(PerformanceBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(CacheRemovingBehavior<,>));
        return services;
    }
}
