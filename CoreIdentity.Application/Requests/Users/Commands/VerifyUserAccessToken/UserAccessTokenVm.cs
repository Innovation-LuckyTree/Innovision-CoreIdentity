using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;

namespace CoreIdentity.Application.Requests.Users.Commands.VerifyUserAccessToken;

public record UserAccessTokenVm(UserTokenDto UserToken)
{
    public Guid UserId { get; set; }
    public bool Used { get; set; } = false;
    public string CurrentGameAccess { get; set; }
    public string PreviousGameAccess { get; set; }
}