using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using MediatR;

namespace CoreIdentity.Application.Requests.UserDevices.Queries.GetAuthDeviceToken;

public class GetAuthDeviceTokenQuery : IRequest<UserTokenDto>
{
    public Guid UserId { get; set; }
    public Guid TokenId { get; set; }
    public string Key { get; set; }
    public string TenantId { get; set; }
    public string IpAddress { get; set; }
}
