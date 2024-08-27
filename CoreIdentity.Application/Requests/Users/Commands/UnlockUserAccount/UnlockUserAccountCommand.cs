using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands.UnlockUserAccount;

public record UnlockUserAccountCommand(Guid AccountId) : IRequest<Unit>;
