using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Notifications.LoginUser;
using CoreIdentity.Application.Requests.Users.Queries.CreateUserJwtToken;
using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Queries.GetRefreshToken;

public record GetRefreshTokenQuery(string Token, string RefreshToken) : IRequest<UserTokenDto>;

public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQuery, UserTokenDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IAppConfig _appConfig;
    private readonly IMediator _mediator;
    private readonly DateTime _expiryDateTime;

    public GetRefreshTokenQueryHandler(ICoreIdentityDbContext dbContext, IAppConfig appConfig, IMediator mediator)
    {
        _dbContext = dbContext;
        _appConfig = appConfig;
        _mediator = mediator;
        _expiryDateTime = DateTime.UtcNow.AddHours(_appConfig.TokenExpiryHours);
    }

    public async Task<UserTokenDto> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        Guid userId;

        var handler = new JwtSecurityTokenHandler();
        try
        {
            var jwtSecurityToken = handler.ReadJwtToken(request.Token);

            var nameIdentifier = jwtSecurityToken.Claims.First(o => o.Type == "nameid").Value;

            if (!Guid.TryParse(nameIdentifier, out userId))
            {
                throw new Exception("Unable to parse UserId");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to parse jwt user token!");
        }

        var userLog = await _dbContext.UserLogs.Where(o => o.UserId == userId && o.RefreshToken == request.RefreshToken)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
        _ = userLog ?? throw new Exception("Unable to find refresh token!");

        if (DateTime.UtcNow > userLog.ExpiryTime)
            throw new Exception("Refresh Token is already expire!");

        var user = await _dbContext.Users.Where(o => o.Id == userId)
            .Include(o => o.TenantUsers)
            .Include(o => o.UserRoles)
                .ThenInclude(e => e.Roles)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        var refreshToken = CryptographyExtensions.CreateKey();
        var refreshTokenExpiration = _expiryDateTime.AddMinutes(30).ToUniversalTime();

        await _mediator.Publish(new LoginUserNotification(user.Id, refreshToken, refreshTokenExpiration, userLog.TenantId.ToString(), userLog.IpAddress), cancellationToken);

        return await _mediator.Send(new CreateUserJwtTokenQuery(user, userLog.TenantId.ToString(), refreshToken), cancellationToken);
    }
}