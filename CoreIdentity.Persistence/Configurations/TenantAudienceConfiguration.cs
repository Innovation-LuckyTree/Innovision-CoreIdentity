using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class TenantAudienceConfiguration : IEntityTypeConfiguration<TenantAudience>
    {
        public void Configure(EntityTypeBuilder<TenantAudience> builder)
        {
            builder.ToTable("TenantAudience");
            builder.HasKey(o => new { o.TenantId, o.AudienceId});

            builder.HasOne(e => e.Audience)
                .WithMany(f => f.TenantAudiences)
                .HasForeignKey(e => e.AudienceId);
        }
    }
}