using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.GetUserToken;

public record GetUserTokenQuery(string UserName, string Password, string TenantId) : IRequest<UserTokenDto>
{
    public string IpAddress { get; set; }
}
