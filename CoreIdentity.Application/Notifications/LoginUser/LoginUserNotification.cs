using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public record LoginUserNotification(Guid UserId, string RefreshToken, DateTime RefreshTokenExpiry, string TenantId, string IpAddress) : INotification
{
}
