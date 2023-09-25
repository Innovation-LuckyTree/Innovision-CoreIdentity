using CoreIdentity.Domain.Entity;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

namespace CoreIdentity.Persistence;

public static class DataSeeder
{
    static Guid adminUserId = Guid.NewGuid();
    static Guid operatorUserId = Guid.NewGuid();
    static Guid masterAgentUserId = Guid.NewGuid();
    static Guid agentUserId = Guid.NewGuid();
    static Guid playerUserId = Guid.NewGuid();

    public static IEnumerable<UserRoles> GetUserRoles()
    {
        return new[] {
            new UserRoles
            {
                UserId = adminUserId,
                RoleId = 1
            },
             new UserRoles
             {
                 UserId = operatorUserId,
                 RoleId = 2
             },
            new UserRoles
            {
                UserId = masterAgentUserId,
                RoleId = 3
            },
            new UserRoles
            {

                RoleId = 4
            },
            new UserRoles
            {
                UserId = playerUserId,
                RoleId = 5
            }
        };
    }
    
    public static IEnumerable<User> GetUserList()
    {

        return new[] {
            new User
            {
                Id = adminUserId,
                UserName = "juanTmadAdmin",
                Email = "juanTmadAdmin@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt
            },
            new User
            {
                Id = operatorUserId,
                UserName = "juanTmadOperator",
                Email = "juanTmadOperator@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt
            },
            new User
            {
                Id = masterAgentUserId,
                UserName = "juanTmadMasterAgent",
                Email = "juanTmadMasterAgent@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt
            },
            new User
            {
                Id = agentUserId,
                UserName = "juanTmadAgent",
                Email = "juanTmadAgent@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt
            },
            new User
            {
                Id = playerUserId,
                UserName = "juanTmadPlayer",
                Email = "juanTmadPlayer@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt
            }
        };
    }
}