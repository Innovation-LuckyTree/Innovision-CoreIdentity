using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.RoleName)
                .HasMaxLength(50);

            builder.Property(e => e.CreatedOn).IsRequired();

            // Data seeder
            builder.HasData(
                new Roles { Id=1, RoleName = "Super Admin", CreatedOn = DateTime.Now }, // 1
                new Roles { Id=2, RoleName = "Operator", CreatedOn = DateTime.Now }, // 2
                new Roles { Id=3, RoleName = "Master Agent", CreatedOn = DateTime.Now }, // 3
                new Roles { Id=4, RoleName = "Agent", CreatedOn = DateTime.Now }, // 4
                new Roles { Id=5, RoleName = "Player", CreatedOn = DateTime.Now } // 5
            );
        }
    }
}