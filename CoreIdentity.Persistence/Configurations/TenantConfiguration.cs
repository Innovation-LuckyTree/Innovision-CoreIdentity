using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TenantName)
                .HasMaxLength(50);

            builder.Property(o => o.Domain)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(o => o.AppKey)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(o => o.Issuer)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(e => e.CreatedOn)
                .IsRequired();

            builder.HasOne(e => e.AdminUser)
                .WithOne(f => f.TenantAdmin)
                .HasForeignKey<Tenant>(e => e.AdminUserId);
        }
    }
}