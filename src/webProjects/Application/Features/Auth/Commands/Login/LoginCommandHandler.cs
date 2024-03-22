using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthServices.AuthService;
using Application.Services.AuthServices.UserService;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _businessRules;

    public LoginCommandHandler(IUserService userService, IAuthService authService, AuthBusinessRules businessRules)
    {
        _userService = userService;
        _authService = authService;
        _businessRules = businessRules;
    }

    public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userService.GetByEmail(request.Email);
        await _businessRules.UserShouldBeExists(user);
        await _businessRules.UserPasswordShouldBeMatch(user.Id, request.Password);

        LoggedDto loggedDto = new();

        //if(user.AuthenticatorType is not Core.Security.Enums.AuthenticatorType.None)
        //{
        //    if(request.AuthenticatorCode is null)
        //    {
        //        await _authService.SendAuthenticatorCode(user);
        //        loggedDto.RequiredAuthenticatorType=user.AuthenticatorType;
        //        return loggedDto;
        //    }

        //    await _authService.VerifyAuthenticatorCode(user,request.AuthenticatorCode);
        //}


        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user,request.IPAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        await _authService.DeleteOldRefreshTokens(user.Id);

        loggedDto.AccessToken = createdAccessToken;
        loggedDto.RefreshToken=addedRefreshToken;
        return loggedDto;


    }
}
