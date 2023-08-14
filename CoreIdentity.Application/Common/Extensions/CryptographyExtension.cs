using System.Security.Cryptography;
using CoreIdentity.Application.Common.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CoreIdentity.Application.Common.Extensions;

public static class CryptographyExtensions
{
    private const int keySize = 32;

    public static PasswordHash CreatePassword(string password)
    {
        var salt = CreateKey();
        var passwordHash = password.GetPasswordHash(salt);

        return new PasswordHash(passwordHash, salt);
    }

    public static string GetPasswordHash(this string password, string salt)
    {
        byte[] saltHash = Convert.FromBase64String(salt);

        var hash = KeyDerivation.Pbkdf2(
            password: password!,
            salt: saltHash,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: keySize * 2);

        return Convert.ToBase64String(hash);
    }

    public static string CreateKey()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(keySize)); 
}