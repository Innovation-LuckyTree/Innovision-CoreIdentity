using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Notifications.LoginUser;

public class LoginUserNotificationHandler(ICoreIdentityDbContext dbContext) : INotificationHandler<LoginUserNotification>
{
    private readonly ICoreIdentityDbContext _dbContext = dbContext;

    public async Task Handle(LoginUserNotification notification, CancellationToken cancellationToken)
    {
        _ = Guid.TryParse(notification.TenantId, out Guid tenantId);

        var user = await _dbContext.Users.FirstOrDefaultAsync(o => o.Id == notification.UserId, cancellationToken);

        if (user.Attempts > 0)
        {
            user.Attempts = 0;
            _dbContext.Users.Update(user);
        }

        var userLog = new UserLog
        {
            UserId = notification.UserId,
            LogId = notification.LogId,
            IpAddress = notification.IpAddress,
            TenantId = tenantId,
            RefreshToken = notification.RefreshToken,
            ExpiryTime = notification.RefreshTokenExpiry
            // UserAccessTokens =
            //     new UserAccessToken
            //     {
            //         UserId = notification.UserId,
            //         AccessToken = token.Password,
            //         AccessTokenKey = token.Salt
            //     }
        };

        _dbContext.UserLogs.Add(userLog);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
