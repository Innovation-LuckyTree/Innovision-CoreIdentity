using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserInfo;

public class UpdateUserInfoCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
}
