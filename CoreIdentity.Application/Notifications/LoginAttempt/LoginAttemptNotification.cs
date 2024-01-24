using MediatR;

namespace CoreIdentity.Application.Notifications.LoginUser;

public record LoginAttemptNotification(Guid UserId, int Attempts) : INotification
{
}
