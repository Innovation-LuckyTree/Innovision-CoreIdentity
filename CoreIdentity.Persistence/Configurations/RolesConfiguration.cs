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
        }
    }
}