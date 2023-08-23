using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserPassword;

public record UpdateUserPasswordCommand(Guid UserId, string CurrentPassword, string NewPassword, string ConfirmNewPassword) : IRequest<Unit>
{
}
