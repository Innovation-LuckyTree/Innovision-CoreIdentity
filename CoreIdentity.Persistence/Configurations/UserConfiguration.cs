using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.IdNumber)
                .UseIdentityColumn();

            builder.Property(o => o.UserName)
                .HasMaxLength(50);

            builder.Property(o => o.Email)
                .HasMaxLength(50);

            builder.Property(o => o.MobileNumber)
                .HasMaxLength(20);

            builder.Property(o => o.Password)
                .HasMaxLength(200);

            builder.Property(o => o.PasswordSalt)
                .HasMaxLength(100);
        }
    }
}