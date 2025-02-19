using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.GetLockedUsers;

public record GetLockedUsersQuery(Guid CompanyObjectId, int? PageNumber = null, int? PageSize = null) : IRequest<LockedUserVm>;
