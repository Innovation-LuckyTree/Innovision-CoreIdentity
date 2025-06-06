using CoreIdentity.Application.Common.Exceptions;
using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Notifications.LoginUser;
using CoreIdentity.Application.Requests.Users.Queries.CreateUserJwtToken;
using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreIdentity.Application.Requests.UserDevices.Queries.GetAuthDeviceToken;

public class GetAuthDeviceTokenQueryHandler : IRequestHandler<GetAuthDeviceTokenQuery, UserTokenDto>
{
    public readonly ICoreIdentityDbContext _coreIdentityDbContext;
    private readonly IAppConfig _appConfig;
    private readonly IMediator _mediator;
    private readonly ILogger<GetAuthDeviceTokenQueryHandler> _logger;
    private readonly DateTime _expiryDateTime;

    public GetAuthDeviceTokenQueryHandler(ICoreIdentityDbContext coreIdentityDbContext, IAppConfig appConfig, IMediator mediator, ILogger<GetAuthDeviceTokenQueryHandler> logger)
    {
        _coreIdentityDbContext = coreIdentityDbContext;
        _appConfig = appConfig;
        _mediator = mediator;
        _logger = logger;
        _expiryDateTime = DateTime.UtcNow.AddHours(_appConfig.TokenExpiryHours);
    }

    public async Task<UserTokenDto> Handle(GetAuthDeviceTokenQuery request, CancellationToken cancellationToken)
    {
        var userDeviceToken = await _coreIdentityDbContext.UserDeviceTokens
            .Where(o => o.UserDeviceTokenId == request.TokenId && o.UserId == request.UserId)
            .Include(o => o.User)
                .ThenInclude(u => u.UserRoles)
                    .ThenInclude(ur => ur.Roles)
            .FirstOrDefaultAsync(cancellationToken);

        _ = userDeviceToken ?? throw new EntityNotFoundException("UserDeviceToken", request.TokenId);

        if (request.Key.GetPasswordHash(userDeviceToken.Salt) != userDeviceToken.Key)
            _ = userDeviceToken ?? throw new EntityNotFoundException("UserDeviceToken", request.TokenId);

        var refreshToken = CryptographyExtensions.CreateKey();
        var refreshTokenExpiration = _expiryDateTime.AddMinutes(30).ToUniversalTime();
        var logId = Guid.NewGuid();

        await _mediator.Publish(new LoginUserNotification(userDeviceToken.User.Id, logId, refreshToken, refreshTokenExpiration, request.TenantId, request.IpAddress), cancellationToken);

        return await _mediator.Send(new CreateUserJwtTokenQuery(userDeviceToken.User, request.TenantId, refreshToken, logId), cancellationToken);
    }
}