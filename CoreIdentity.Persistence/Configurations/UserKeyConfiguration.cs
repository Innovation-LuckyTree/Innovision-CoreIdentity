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

            builder.HasOne(e => e.User)
                .WithMany(f => f.UserKeys)
                .HasForeignKey(e => e.UserId);
        }
    }
}