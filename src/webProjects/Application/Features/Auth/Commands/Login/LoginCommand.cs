using Amazon.Runtime.Internal;
using Application.Features.Auth.Dtos;
using Core.Application.Pipelines.Logging;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>, ILoggableLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string IPAddress { get; set; }
    public string OperatingSystem { get; set; }
    public string? AuthenticatorCode { get; set; }

}
