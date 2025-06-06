using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public record LoginUserNotification(Guid UserId, Guid LogId, string RefreshToken, DateTime RefreshTokenExpiry, string TenantId, string IpAddress) : INotification
{
}
