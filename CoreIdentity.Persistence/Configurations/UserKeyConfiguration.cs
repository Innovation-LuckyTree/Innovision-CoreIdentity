using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserKeyConfiguration : IEntityTypeConfiguration<UserKey>
    {
        public void Configure(EntityTypeBuilder<UserKey> builder)
        {
            builder.ToTable("UserKey");

            builder.HasKey(o => o.UserKeyId);

            builder.Property(o => o.Key)
                .HasMaxLength(50);

            builder.HasOne(e => e.User)
                .WithMany(f => f.UserKeys)
                .HasForeignKey(e => e.UserId);
        }
    }
}