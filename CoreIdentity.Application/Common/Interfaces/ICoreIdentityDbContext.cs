using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CoreIdentity.Application.Common.Interfaces;

public interface ICoreIdentityDbContext
{
    DbSet<Claims> Claims { get; set; }
    DbSet<Roles> Roles { get; set; }
    DbSet<Tenant> Tenants { get; set; }
    DbSet<TenantUser> TenantUsers { get; set; }
    DbSet<TenantKey> TenantKeys { get; set; }
    DbSet<UserClaims> UserClaims { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserKey> UserKeys { get; set; }
    DbSet<UserLog> UserLogs { get; set; }
    DbSet<UserRoles> UserRoles { get; set; }
    DbSet<UserDeviceToken> UserDeviceTokens { get; set; }
    DatabaseFacade Database { get; }
    
    Task<int> SaveChangesAsync(CancellationToken canellationToken = default);
}
