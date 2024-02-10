using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreIdentity.Application.Common.Exceptions;
using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetAuthToken;

public class GetAuthTokenQueryHandler : IRequestHandler<GetAuthTokenQuery, TenantTokenDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IAppConfig _appConfig;


    public GetAuthTokenQueryHandler(ICoreIdentityDbContext dbContext, IAppConfig appConfig)
    {
        _dbContext = dbContext;
        _appConfig = appConfig;
    }

    public async Task<TenantTokenDto> Handle(GetAuthTokenQuery request, CancellationToken cancellationToken)
    {
        var test = await _dbContext.TenantKeys.Where(o => o.TenantKeyId == request.ResourceId).FirstOrDefaultAsync(cancellationToken);

        var tenantKey = await _dbContext.TenantKeys
            .Where(o => o.TenantKeyId == request.ResourceId)
            .Include(o => o.Tenant)
                .ThenInclude(o => o.AdminUser)
                    .ThenInclude(o => o.UserRoles)
                    .ThenInclude(o => o.Roles)
            .FirstOrDefaultAsync(cancellationToken);

        _ = tenantKey ?? throw new EntityNotFoundException("TenantKey", request.ResourceId);

        if (!(tenantKey.TenantId == request.ClientId && tenantKey.TenantId == request.ClientId))
        {
            _ = tenantKey ?? throw new Exception($"Unable to find resource for ClientId : {request.ClientId}");
        }

        if (request.Key.GetPasswordHash(tenantKey.Salt) != tenantKey.Key)
        {
            _ = tenantKey ?? throw new Exception($"Unable to authenticate ClientId : {request.ClientId} with resourceId {request.ResourceId}");
        }

        var adminUser = tenantKey.Tenant.AdminUser;

        return await CreateTenantToken(adminUser, request, cancellationToken);
    }

    private async Task<TenantTokenDto> CreateTenantToken(User user, GetAuthTokenQuery request, CancellationToken cancellationToken)
    {
        var token = await GenerateToken(user, request.ClientId, cancellationToken);

        return new TenantTokenDto
        {
            Id = user.Id,
            UserName = user.UserName,
            ClientId = request.ClientId.ToString(),
            Type = "Bearer",
            ExpirationDate = new DateTimeOffset(DateTime.UtcNow.AddMinutes(30)).ToUnixTimeSeconds(),
            Token = token
        };
    }


    private async Task<string> GenerateToken(User user, Guid tenantId, CancellationToken cancellationToken)
    {
        string? key, issuer, audience;
        var claims = new List<Claim>();

        (key, issuer, audience, claims) = await GetJwtInfoAsync(tenantId, cancellationToken);

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
        claims.Add(new Claim("tenantId", tenantId.ToString() ?? ""));
        claims.Add(new Claim("companyId", user.CompanyId ?? ""));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        foreach (var role in user.UserRoles)
            claims.Add(new Claim(ClaimTypes.Role, role.Roles.RoleName));

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
        var tenant1 = await _dbContext.Tenants.Where(o => o.Id.Equals(tenantId))
            .Include(o => o.TenantAudiences)
            .ToListAsync(cancellationToken);

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