namespace CoreIdentity.Application.Common.Models;

public record PasswordHash(string Password, string Salt)
{
}