using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands.GetUserAccessToken;

public record GetUserAccessTokenQuery(Guid UserId, Guid LogId) : IRequest<UserAccessTokenVm>;
