using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public class LoginUserNotificationHandler : INotificationHandler<LoginUserNotification>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public LoginUserNotificationHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(LoginUserNotification notification, CancellationToken cancellationToken)
    {
        Guid.TryParse(notification.TenantId, out Guid tenantId);

        var userLog = new UserLog
        {
            UserId = notification.UserId,
            IpAddress = notification.IpAddress,
            TenantId = tenantId
        };

        _dbContext.UserLogs.Add(userLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
