using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands.ResetUserPassword;

public record ResetUserPasswordCommand(string UserName) : IRequest<Unit>;
