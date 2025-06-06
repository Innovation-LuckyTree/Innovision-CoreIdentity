using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using CoreIdentity.Domain.Entity;
using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.CreateUserJwtToken;

public record CreateUserJwtTokenQuery(User User, string TenantId, string RefreshToken, Guid LogId) : IRequest<UserTokenDto>;
