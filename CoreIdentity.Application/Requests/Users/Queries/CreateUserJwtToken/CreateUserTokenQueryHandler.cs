using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CoreIdentity.Application.Requests.Users.Queries.CreateUserJwtToken;

public class CreateUserJwtTokenQueryHandler : IRequestHandler<CreateUserJwtTokenQuery, UserTokenDto>
{
    private readonly IAppConfig _appConfig;
    private readonly DateTime _expiryDateTime;
    private readonly ICoreIdentityDbContext _dbContext;

    public CreateUserJwtTokenQueryHandler(IAppConfig appConfig, ICoreIdentityDbContext dbContext)
    {
        _appConfig = appConfig;
        _expiryDateTime = DateTime.UtcNow.AddHours(_appConfig.TokenExpiryHours);
        _dbContext = dbContext;
    }

    public async Task<UserTokenDto> Handle(CreateUserJwtTokenQuery request, CancellationToken cancellationToken)
    {
        var token = await GenerateToken(request.User, request.TenantId, request.LogId, cancellationToken);

        return new UserTokenDto
        {
            Id = request.User.Id,
            IdNumber = request.User.IdNumber,
            UserName = request.User.UserName,
            ClientId = request.TenantId,
            Type = "Bearer",
            ExpirationDate = new DateTimeOffset(_expiryDateTime).ToUnixTimeSeconds(),
            Token = token,
            TemporaryPassword = request.User.ChangePassword,
            CompanyId = request.User.CompanyId,
            RefreshToken = request.RefreshToken
        };
    }
    private async Task<string> GenerateToken(User user, string tenantId, Guid logId, CancellationToken cancellationToken)
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
        claims.Add(new Claim("token_type", "access"));
        claims.Add(new Claim("companyId", user.CompanyId?.ToString() ?? ""));
        claims.Add(new Claim("user_id", user.Id.ToString()));
        claims.Add(new Claim("log_id", logId.ToString()));
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
            Expires = _expiryDateTime,
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

        var tenant = await _dbContext.Tenants.Where(o => o.Id.Equals(tenantId))
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