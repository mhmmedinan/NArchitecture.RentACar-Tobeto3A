using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthServices.AuthService;

public class AuthManager : IAuthService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public AuthManager(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, TokenOptions tokenOptions, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _tokenOptions = tokenOptions;
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimRepository
            .Query()
            .AsNoTracking()
            .Where(p => p.UserId == user.Id)
            .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
            .ToListAsync();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task DeleteOldRefreshTokens(Guid userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenRepository
             .Query()
             .AsNoTracking()
             .Where(r =>
                        r.UserId == userId && r.Revoked == null && r.Expires >= DateTime.UtcNow && r.CreatedDate.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow).ToListAsync();
        foreach(RefreshToken refreshToken in refreshTokens) { await _refreshTokenRepository.DeleteAsync(refreshToken); }
    }

    public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(r => r.Token == token);
        return refreshToken;
    }

    public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken childToken = await _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken);

        if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(childToken, ipAddress, reason);
    }

    public async Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp= ipAddress;
        token.ReasonRevoked= reason;
        token.ReplacedByToken= replacedByToken;
        await _refreshTokenRepository.UpdateAsync(token);
    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }
}
