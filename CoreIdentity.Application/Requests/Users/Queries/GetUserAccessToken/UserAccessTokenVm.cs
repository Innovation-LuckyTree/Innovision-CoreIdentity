namespace CoreIdentity.Application.Requests.Users.Commands.GetUserAccessToken;

public record UserAccessTokenVm(UserAccessTokenDto Data)
{
    public bool Sucess { get; set; } = true;
}