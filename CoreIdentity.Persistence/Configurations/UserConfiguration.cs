using Azure.Core;
using CoreIdentity.Application.Common.Models;
using CoreIdentity.Application.Requests.Users.Queries.GetUserToken;
using CoreIdentity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

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

            // Data Seeder
            builder.HasData(new User {
                UserName = "juanTmadAdmin",
                Email = "juanTmadAdmin@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt,
                UserRoles = new[] { new UserRoles
                    {
                        RoleId = 1
                    }
                }
            },
            new User
            {
                UserName = "juanTmadOperator",
                Email = "juanTmadOperator@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt,
                UserRoles = new[] { new UserRoles
                    {
                        RoleId = 2
                    }
                }
            },
            new User
            {
                UserName = "juanTmadMasterAgent",
                Email = "juanTmadMasterAgent@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt,
                UserRoles = new[] { new UserRoles
                    {
                        RoleId = 3
                    }
                }
            },
            new User
            {
                UserName = "juanTmadAgent",
                Email = "juanTmadAgent@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt,
                UserRoles = new[] { new UserRoles
                    {
                        RoleId = 4
                    }
                }
            },
            new User
            {
                UserName = "juanTmadPlayer",
                Email = "juanTmadPlayer@gmail.com",
                MobileNumber = "09090909099",
                Password = CreatePassword("123456789").Password,
                PasswordSalt = CreatePassword("123456789").Salt,
                UserRoles = new[] { new UserRoles
                    {
                        RoleId = 5
                    }
                }
            });
        }
    }
}