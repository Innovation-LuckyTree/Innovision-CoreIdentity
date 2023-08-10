using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.ToTable("TenantUser");
            builder.HasKey(o => new { o.UserId, o.TenantId });

            builder.HasOne(e => e.Tenant)
                .WithMany(f => f.TenantUsers)
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.User)
                .WithMany(f => f.TenantUsers)
                .HasForeignKey(e => e.UserId);
        }
    }
}