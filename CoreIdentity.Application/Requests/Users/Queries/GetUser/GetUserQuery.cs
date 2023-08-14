using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<UserDto>
{
}
