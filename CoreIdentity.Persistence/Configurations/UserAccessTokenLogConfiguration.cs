using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreIdentity.Persistence.Configurations;

public class UserAccessTokenLogConfiguration : IEntityTypeConfiguration<UserAccessTokenLog>
{
    public void Configure(EntityTypeBuilder<UserAccessTokenLog> builder)
    {
        builder.ToTable("UserAccessTokenLog");
        builder.HasKey(o => o.UserAccessTokenLogId);

        builder.Property(o => o.UserAccessTokenLogId)
            .UseIdentityColumn();

        builder.HasOne(o => o.UserAccessToken)
            .WithMany(e => e.UserAccessTokenLogs)
            .HasForeignKey(f => f.UserAccessTokenId);
    }
}
