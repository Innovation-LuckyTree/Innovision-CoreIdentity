using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public class LoginUserNotificationHandler(ICoreIdentityDbContext dbContext) : INotificationHandler<LoginUserNotification>
{
    private readonly ICoreIdentityDbContext _dbContext = dbContext;

    public async Task Handle(LoginUserNotification notification, CancellationToken cancellationToken)
    {
        _ = Guid.TryParse(notification.TenantId, out Guid tenantId);

        var userLog = new UserLog
        {
            UserId = notification.UserId,
            IpAddress = notification.IpAddress,
            TenantId = tenantId,
            RefreshToken = notification.RefreshToken,
            ExpiryTime = notification.RefreshTokenExpiry
        };

        _dbContext.UserLogs.Add(userLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
