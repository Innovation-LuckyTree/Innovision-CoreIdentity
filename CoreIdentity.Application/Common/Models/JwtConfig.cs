namespace CoreIdentity.Application.Common.Models;

public record JwtConfig(string Key, string Issuer, string Audience)
{
}