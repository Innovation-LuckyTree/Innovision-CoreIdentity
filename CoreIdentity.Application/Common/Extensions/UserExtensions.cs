using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Common.Extensions;

public static class UserExtensions
{
    public static string GetUserName(this User user) =>
        user?.UserName ?? "";
}