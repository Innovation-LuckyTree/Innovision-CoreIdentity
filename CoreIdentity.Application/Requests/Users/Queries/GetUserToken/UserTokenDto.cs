namespace CoreIdentity.Application.Requests.Users.Queries.GetUserToken;

public class UserTokenDto
{
    public Guid Id { get; set; }
    public int IdNumber { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string ClientId { get; set; }
    public string Type { get; set; }
    public bool TemporaryPassword { get; set; }
    public long ExpirationDate { get; set; }
    public string CompanyId { get; set; }
}