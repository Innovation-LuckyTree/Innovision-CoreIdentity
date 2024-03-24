using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreIdentity.Application.Common.Exceptions;
using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Notifications.LoginUser;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CoreIdentity.Application.Requests.UserDevices.Queries.GetAuthDeviceToken;

public class GetAuthDeviceTokenQueryHandler : IRequestHandler<GetAuthDeviceTokenQuery, DeviceTokenDto>
{
    public readonly ICoreIdentityDbContext _coreIdentityDbContext;
    private readonly IAppConfig _appConfig;
    private readonly IMediator _mediator;
    private readonly ILogger<GetAuthDeviceTokenQueryHandler> _logger;

    public GetAuthDeviceTokenQueryHandler(ICoreIdentityDbContext coreIdentityDbContext, IAppConfig appConfig, IMediator mediator, ILogger<GetAuthDeviceTokenQueryHandler> logger)
    {
        _coreIdentityDbContext = coreIdentityDbContext;
        _appConfig = appConfig;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<DeviceTokenDto> Handle(GetAuthDeviceTokenQuery request, CancellationToken cancellationToken)
    {
        var userDeviceToken = await _coreIdentityDbContext.UserDeviceTokens
            .Where(o => o.UserDeviceTokenId == request.TokenId && o.UserId == request.UserId)
            .Include(o => o.User)
            .FirstOrDefaultAsync(cancellationToken);

        _ = userDeviceToken ?? throw new EntityNotFoundException("UserDeviceToken", request.TokenId);

        if (request.Key.GetPasswordHash(userDeviceToken.Salt) != userDeviceToken.Key)
            _ = userDeviceToken ?? throw new EntityNotFoundException("UserDeviceToken", request.TokenId);

        var token = await GenerateToken(userDeviceToken.User, request.TenantId, cancellationToken);

        await _mediator.Publish(new LoginUserNotification(userDeviceToken.User.Id, request.TenantId, request.IpAddress));

        return new DeviceTokenDto
        {
            Id = userDeviceToken.User.Id,
            IdNumber = userDeviceToken.User.IdNumber,
            UserName = userDeviceToken.User.UserName,
            ClientId = request.TenantId,
            Type = "Bearer",
            ExpirationDate = new DateTimeOffset(DateTime.UtcNow.AddHours(2)).ToUnixTimeSeconds(),
            Token = token,
            TemporaryPassword = userDeviceToken.User.ChangePassword,
            CompanyId = userDeviceToken.User.CompanyId
        };
    }

    private async Task<string> GenerateToken(User user, string tenantId, CancellationToken cancellationToken)
    {
        var key = _appConfig.JwtConfig.Key;
        var issuer = _appConfig.JwtConfig.Issuer;
        var audience = _appConfig.JwtConfig.Audience;

        var claims = new List<Claim>();

        if (Guid.TryParse(tenantId, out Guid result))
        {
            (key, issuer, audience, claims) = await GetJwtInfoAsync(result, cancellationToken);
        }

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
        claims.Add(new Claim("tenantId", tenantId.ToString() ?? ""));
        claims.Add(new Claim("companyId", user.CompanyId?.ToString() ?? ""));
        claims.Add(new Claim("token_type", "access"));
        claims.Add(new Claim("user_id", user.Id.ToString()));
        claims.Add(new Claim("jti", Guid.NewGuid().ToString()));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        foreach (var role in user.UserRoles)
        {
            claims.Add(new Claim("RoleId", role.Roles.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, role.Roles.RoleName));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private async Task<(string Key, string Issuer, string Audience, List<Claim> Claims)> GetJwtInfoAsync(Guid tenantId, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>();

        var tenant = await _coreIdentityDbContext.Tenants.Where(o => o.Id.Equals(tenantId))
            .Include(o => o.TenantAudiences)
            .FirstOrDefaultAsync(cancellationToken);

        var key = tenant?.AppKey ?? _appConfig.JwtConfig.Key;
        var issuer = tenant?.Issuer ?? _appConfig.JwtConfig.Issuer;
        var audience = _appConfig.JwtConfig.Audience;

        if ((tenant?.TenantAudiences?.Count ?? 0) != 0)
        {
            foreach (var tenantAudience in tenant.TenantAudiences)
                claims.Add(new Claim(JwtRegisteredClaimNames.Aud, tenantAudience.Audience.Issuer));
        }

        return (key, issuer, audience, claims);
    }
}