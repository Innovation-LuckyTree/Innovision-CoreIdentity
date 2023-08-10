using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class ClaimsConfiguration : IEntityTypeConfiguration<Claims>
    {
        public void Configure(EntityTypeBuilder<Claims> builder)
        {
            builder.ToTable("Claims");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(50);

            builder.Property(e => e.CreatedOn).IsRequired();
        }
    }
}