using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.Getusers;

public record GetUsersQuery : IRequest<UserVm>;
