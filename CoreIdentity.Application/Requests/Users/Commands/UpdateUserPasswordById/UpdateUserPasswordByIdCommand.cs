using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserPasswordById;

public record UpdateUserPasswordByIdCommand(Guid UserId, string NewPassword, string ConfirmNewPassword) : IRequest<Unit>
{
}
