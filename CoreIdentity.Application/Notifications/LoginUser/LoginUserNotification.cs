using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public record LoginUserNotification(Guid UserId, string TenantId, string IpAddress) : INotification
{
}
