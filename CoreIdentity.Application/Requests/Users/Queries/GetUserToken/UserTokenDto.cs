using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Requests.Users.Queries.GetUserToken;

public class UserTokenDto
{
    public Guid Id { get; set; }
    public int IdNumber { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string ClientId { get; set; }
    public string Type { get; set; }
    public long ExpirationDate { get; set; }
    public IList<Role> Roles { get; set; }
}

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; }
}