using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(o => new { o.UserId, o.RoleId });

            builder.HasOne(e => e.Roles)
                .WithMany(f => f.UserRoles)
                .HasForeignKey(e => e.RoleId);

            builder.HasOne(e => e.User)
                .WithMany(f => f.UserRoles)
                .HasForeignKey(e => e.UserId);

            builder.HasData(DataSeeder.GetUserRoles());
        }
    }
}