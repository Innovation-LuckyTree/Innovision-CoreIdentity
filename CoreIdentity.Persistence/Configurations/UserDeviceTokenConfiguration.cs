using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserDeviceTokenConfiguration : IEntityTypeConfiguration<UserDeviceToken>
    {
        public void Configure(EntityTypeBuilder<UserDeviceToken> builder)
        {
            builder.ToTable("UserDeviceToken");
            builder.HasKey(o => o.UserDeviceTokenId);

            builder.Property(o => o.Key)
                .HasMaxLength(100);

            builder.Property(o => o.Salt)
                .HasMaxLength(100);

            builder.Property(o => o.DeviceName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.HasOne(e => e.User)
                .WithMany(f => f.UserDeviceTokens)
                .HasForeignKey(o => o.UserId);
        }
    }
}