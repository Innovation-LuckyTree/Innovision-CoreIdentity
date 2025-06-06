using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations;

public class UserAccessTokenConfiguration : IEntityTypeConfiguration<UserAccessToken>
{
    public void Configure(EntityTypeBuilder<UserAccessToken> builder)
    {
        builder.ToTable("UserAccessToken");
        builder.HasKey(o => o.UserAccessTokenId);

        builder.Property(o => o.UserAccessTokenId)
            .UseIdentityColumn();

        builder.HasOne(o => o.User)
            .WithMany(e => e.UserAccessTokens)
            .HasForeignKey(f => f.UserId);

        builder.HasOne(o => o.User)
            .WithMany(e => e.UserAccessTokens)
            .HasForeignKey(f => f.UserId);

        builder.HasOne(o => o.UserLog)
            .WithOne(e => e.UserAccessTokens)
            .HasForeignKey<UserAccessToken>(f => f.UserLogId);
    }
}
