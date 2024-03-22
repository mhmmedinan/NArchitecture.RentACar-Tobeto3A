using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthServices.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IAuthService authService, IUserRepository userRepository)
    {
        _authBusinessRules = authBusinessRules;
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

        byte[] passwordHash, passwordSalt;  //in
        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

        User user = new()
        {
            Email = request.UserForRegisterDto.Email,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        User createdUser = await _userRepository.AddAsync(user);
        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser,request.IPAddress);

        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
        RegisteredDto registeredDto = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return registeredDto;

    }
}



