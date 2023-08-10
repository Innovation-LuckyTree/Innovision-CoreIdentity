using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.ToTable("UserClaims");
            builder.HasKey(o => new { o.UserId, o.ClaimId });

            builder.HasOne(e => e.Claims)
                .WithMany(f => f.UserClaims)
                .HasForeignKey(e => e.ClaimId);

            builder.HasOne(e => e.User)
                .WithMany(f => f.UserClaims)
                .HasForeignKey(e => e.UserId);
        }
    }
}