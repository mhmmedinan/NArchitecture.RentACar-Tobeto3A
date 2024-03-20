using Application.Services.Repositories;
using Core.CrossCutting.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;

namespace Application.Features.Auth.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user == null)
            throw new BusinessException("User don't exists.");
        return Task.CompletedTask;
    }

    public Task UserShouldNotBeHaveAuthenticator(User user)
    {
        if (user.AuthenticatorType != AuthenticatorType.None)
            throw new BusinessException("User have already a authenticator");
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
    {
        if (refreshToken == null)
            throw new BusinessException("Refresh don't exists.");
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
    {
        if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires)
            throw new BusinessException("Invalid refresh token.");
        return Task.CompletedTask;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(predicate: u => u.Email == email);
        if (user != null)
            throw new BusinessException("User mail already exists");
    }

    public async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await _userRepository.GetAsync(predicate: u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Password don't match.");
    }
}
