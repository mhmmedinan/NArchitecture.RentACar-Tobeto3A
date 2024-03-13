using Core.CrossCutting.Logging;
using Core.CrossCutting.Logging.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Application.Pipelines.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ILoggableRequest
{
    private readonly LoggerServiceBase _loggerServiceBase;
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggingBehavior(LoggerServiceBase loggerServiceBase, IHttpContextAccessor contextAccessor)
    {
        _loggerServiceBase = loggerServiceBase;
        _contextAccessor = contextAccessor;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters = new();
        logParameters.Add(new LogParameter() { Value = request ,Type=request.GetType().Name});

        LogDetail logDetail = new()
        {
            MethodName = next.Method.Name,
            Parameters = logParameters,
            User = _contextAccessor.HttpContext == null || _contextAccessor.HttpContext.User.Identity.Name == null ? "?" : _contextAccessor.HttpContext.User.Identity.Name
        };
        _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
        return next();
    }


}
