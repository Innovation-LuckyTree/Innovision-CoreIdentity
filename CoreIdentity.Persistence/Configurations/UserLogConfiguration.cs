using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.ToTable("UserLog");
            
            builder.HasKey(o => o.UserLogId);
            builder.Property(o => o.UserLogId)
                .UseIdentityColumn();

            builder.Property(o => o.IpAddress)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.HasOne(o => o.User)
                .WithMany(e => e.UserLogs)
                .HasForeignKey(f => f.UserId);

            builder.HasOne(o => o.Tenant)
                .WithMany(e => e.UserLogs)
                .HasForeignKey(f => f.TenantId);
        }
    }
}