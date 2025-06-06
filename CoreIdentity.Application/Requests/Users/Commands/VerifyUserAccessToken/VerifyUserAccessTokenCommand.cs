using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands.VerifyUserAccessToken;

public record VerifyUserAccessTokenCommand(Guid LogId, string AccessToken, string GameName) : IRequest<UserAccessTokenVm>
{
}
