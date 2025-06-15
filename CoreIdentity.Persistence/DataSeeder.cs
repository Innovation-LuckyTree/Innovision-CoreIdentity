using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Persistence;

public static class DataSeeder
{
    public static async Task SeedAsync(CoreIdentityDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        // add default usertypes
        var userTypeCount = await context.Roles.CountAsync();
        if (userTypeCount == 0)
        {
            List<Roles> usertypes = new List<Roles>();

            usertypes.Add(new Roles { Id = 1, RoleName = "Super Admin", CreatedOn = DateTime.UtcNow });
            usertypes.Add(new Roles { Id = 2, RoleName = "Operator", CreatedOn = DateTime.UtcNow });
            usertypes.Add(new Roles { Id = 3, RoleName = "Game Site Manager", CreatedOn = DateTime.UtcNow });
            usertypes.Add(new Roles { Id = 4, RoleName = "Recruiter", CreatedOn = DateTime.UtcNow });
            usertypes.Add(new Roles { Id = 5, RoleName = "Player", CreatedOn = DateTime.UtcNow });
            usertypes.Add(new Roles { Id = 6, RoleName = "NewRegister", CreatedOn = DateTime.UtcNow });

            context.Roles.AddRange(usertypes);
            await context.SaveChangesAsync();
        }

        // create default admin user
        var userAdminCount = await context.Users.Where(m => m.Id == Guid.Parse("75CF0EB4-7FE5-48C4-C343-08DC3D184E4B")).CountAsync();
        if (userAdminCount == 0) {
            context.Users.Add(new User
            {
                Id = Guid.Parse("75CF0EB4-7FE5-48C4-C343-08DC3D184E4B"),
                UserName = "Test",
                Email = "Test@gmail.com",
                MobileNumber = "10000000002",
                Password = "fsL5m1q9RMYhhof2Z9sGqkFCvePCug5TgbxH+/DAYTMO6QdNhW3EWUIwSQeFVl0fKU6fGyP5hkestyFiDvm9Qg==",
                PasswordSalt = "xWsc4tyB2w4JkMRdV4qtvU8P7XIF+YW1Q+RMKqfonsU=",
                ChangePassword = false,
                EmailConfirmed = true,
                MobilePrimary = true,
                Attempts = 0,
                Locked = false,
                CreatedOn = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
        }

        // add default tenants
        var tenantCount = await context.Tenants.CountAsync();
        if (tenantCount == 0)
        {
            context.Tenants.Add(new Tenant
            {
                Id = Guid.Parse("1E276E2B-97D5-4B4A-9E34-DBCA1EED437E"),
                TenantName = "happy-play-main",
                AdminUserId = Guid.Parse("75CF0EB4-7FE5-48C4-C343-08DC3D184E4B"),
                Type = 2,
                DefaultPassword = "test@123",
                AppKey = "54/Mnoi4GJxAr5hIWXYjlhPF/JLgE1OLv/",
                Issuer = "https://localhost:7077/",
                Domain = "https://localhost:7077/",
                CreatedOn = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
        }
    }
}