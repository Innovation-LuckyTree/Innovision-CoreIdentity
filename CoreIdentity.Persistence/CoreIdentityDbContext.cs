namespace CoreIdentity.Persistence;

using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;

public class CoreIdentityDbContext : DbContext, ICoreIdentityDbContext
{
    public CoreIdentityDbContext()
    {
    }

    public CoreIdentityDbContext(DbContextOptions<CoreIdentityDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Claims> Claims { get; set; }
    public virtual DbSet<Roles> Roles { get; set; }
    public virtual DbSet<Tenant> Tenants { get; set; }
    public virtual DbSet<TenantUser> TenantUsers { get; set; }
    public virtual DbSet<TenantKey> TenantKeys { get; set; }
    public virtual DbSet<UserClaims> UserClaims { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserKey> UserKeys { get; set; }
    public virtual DbSet<UserLog> UserLogs { get; set; }
    public virtual DbSet<UserRoles> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "1.1.1-servicing");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreIdentityDbContext).Assembly);
    }
}
