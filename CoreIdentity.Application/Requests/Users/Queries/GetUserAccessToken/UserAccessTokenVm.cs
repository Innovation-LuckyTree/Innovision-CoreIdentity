namespace CoreIdentity.Application.Requests.Users.Commands.GetUserAccessToken;

public record UserAccessTokenVm(UserAccessTokenDto AccessToken)
{
    public bool Sucess { get; set; } = true;
}