using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CoreIdentity.Application.Common.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreIdentity.Application.Notifications.LoginUser;
using System.Diagnostics.CodeAnalysis;

namespace CoreIdentity.Application.Requests.Users.Queries.GetUserToken;

public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, UserTokenDto>
{
    private readonly ILogger<GetUserTokenQueryHandler> _logger;
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IAppConfig _appConfig;
    private readonly IMediator _mediator;

    public GetUserTokenQueryHandler(ILogger<GetUserTokenQueryHandler> logger, ICoreIdentityDbContext dbContext,
        IAppConfig appConfig, IMediator mediator)
    {
        _logger = logger;
        _dbContext = dbContext;
        _appConfig = appConfig;
        _mediator = mediator;
    }

    public async Task<UserTokenDto> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(o => o.UserName.Equals(request.UserName))
            .Include(o => o.TenantUsers)
            .Include(o => o.UserRoles)
                .ThenInclude(e => e.Roles)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            return null;
        }

        if (!await ValidateUser(request, user))
        {
            return null;
        }

        await _mediator.Publish(new LoginUserNotification(user.Id, request.TenantId, request.IpAddress));

        return await CreateUserToken(user, request, cancellationToken);
    }

    private async Task<UserTokenDto> CreateUserToken(User user, GetUserTokenQuery request, CancellationToken cancellationToken)
    {
        var token = await GenerateToken(user, request.TenantId, cancellationToken);

        return new UserTokenDto
        {
            Id = user.Id,
            IdNumber = user.IdNumber,
            UserName = user.UserName,
            ClientId = request.TenantId,
            Type = "Bearer",
            ExpirationDate = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30)).ToUnixTimeSeconds(),
            Token = token,
            TemporaryPassword = user.ChangePassword,
            CompanyId = user.CompanyId
        };
    }

    private async Task<bool> ValidateUser(GetUserTokenQuery request, User user)
    {
        if (string.IsNullOrEmpty(request.TenantId))
        {
            var isTenantUser = user.TenantUsers
                .Any(o => o.TenantId.ToString() == request.TenantId);

            if (!isTenantUser)
            {
                return false;
            }
        }

        if (request.Password.GetPasswordHash(user.PasswordSalt) != user.Password)
        {
            await _mediator.Publish(new LoginAttemptNotification(user.Id, user.Attempts));

            return false;
        }

        return true;
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
        claims.Add(new Claim("token_type", "access"));
        claims.Add(new Claim("companyId", user.CompanyId?.ToString() ?? ""));
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
