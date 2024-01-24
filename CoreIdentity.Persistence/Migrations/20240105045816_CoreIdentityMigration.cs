using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CoreIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    MobilePrimary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AdminUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DefaultPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_User_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => new { x.UserId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_UserClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserKey",
                columns: table => new
                {
                    UserKeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKey", x => x.UserKeyId);
                    table.ForeignKey(
                        name: "FK_UserKey_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    // table.ForeignKey(
                    //     name: "FK_UserRoles_User_UserId",
                    //     column: x => x.UserId,
                    //     principalTable: "User",
                    //     principalColumn: "Id",
                    //     onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantAudience",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantAudience", x => new { x.TenantId, x.AudienceId });
                    table.ForeignKey(
                        name: "FK_TenantAudience_Tenant_AudienceId",
                        column: x => x.AudienceId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantKey",
                columns: table => new
                {
                    TenantKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantKey", x => x.TenantKeyId);
                    table.ForeignKey(
                        name: "FK_TenantKey_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUser", x => new { x.UserId, x.TenantId });
                    table.ForeignKey(
                        name: "FK_TenantUser_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    UserLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.UserLogId);
                    table.ForeignKey(
                        name: "FK_UserLog_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "LastModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9780), null, "Super Admin" },
                    { 2, new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9784), null, "Operator" },
                    { 3, new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9785), null, "Master Agent" },
                    { 4, new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9786), null, "Agent" },
                    { 5, new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9788), null, "Player" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ChangePassword", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("09fc56a2-362d-43ca-9ff7-54eaa945e730"), false, new DateTime(2024, 1, 5, 12, 58, 15, 920, DateTimeKind.Local).AddTicks(5620), "juanTmadMasterAgent@gmail.com", true, null, "09090909099", true, "PgypPGsuV6l67lxAhnxr+fMnkdf6yZZr/Ve0Kre7s3hniUTaJWE2t2WTe3dU/QuSBNRTvRIFjDf+jcJbpcJ1Jw==", "Wu9cJrgdj/vwWHcWc53NUkx9B8PI3wEikylcUC+/IGs=", "juanTmadMasterAgent" },
                    { new Guid("779c7ed3-9859-4ba3-98e5-33532d7a5981"), false, new DateTime(2024, 1, 5, 12, 58, 15, 857, DateTimeKind.Local).AddTicks(142), "juanTmadOperator@gmail.com", true, null, "09090909099", true, "EKfEnKI5PiktNFxCPTKa63jIMMidY94RuHOldDjZofy61kX0Q8qes3DoDjjt553zeAyewD0HsBFuOwihVjXprQ==", "2hMXGJ0lNNN/PRoPiZRehiZGs8uDEMXyoB/PurIrzek=", "juanTmadOperator" },
                    { new Guid("cac331ea-5c0b-4470-b395-cd91ced1630f"), false, new DateTime(2024, 1, 5, 12, 58, 15, 980, DateTimeKind.Local).AddTicks(3995), "juanTmadAgent@gmail.com", true, null, "09090909099", true, "sHOYA+6ZgVrEV029uqyyX8hhJ0l8jhTFVX5edKmTGc+XbmK78zBuBo28pRCaRF8TpE+7H1Kqpe2soxUsE93Mxg==", "dvy/Z3KJt0UBBcFuePaS+nadlfTHeVYJauQTkzNmydQ=", "juanTmadAgent" },
                    { new Guid("daa70a93-4e90-4fbf-8fa7-c546a323e211"), false, new DateTime(2024, 1, 5, 12, 58, 15, 795, DateTimeKind.Local).AddTicks(8653), "juanTmadAdmin@gmail.com", true, null, "09090909099", true, "C1WxL7oFsp8MZmFfQkA494BFN8Rt8piTjUgr/pwgONa2UxaEw9LydrzK98OZZIpLAaoqLVBwtu953/ZYvgEB8Q==", "gogGbsdUPjpbHEqPs941aXzfx+btsrrV2WQhWboDW8Q=", "juanTmadAdmin" },
                    { new Guid("ec7e38e0-68b2-4daa-b746-25656b18f9e3"), false, new DateTime(2024, 1, 5, 12, 58, 16, 50, DateTimeKind.Local).AddTicks(9078), "juanTmadPlayer@gmail.com", true, null, "09090909099", true, "cugUvANG3S+uniK58RfN0tuFXGhjEW2l0z9ofDj5pL+3wBWdxuYt5fMweMVb/UQS3cqoTOVobfcT0p1hRi8Kaw==", "TZA/HOXzLnITuo8EnHtkJkbPiS9zZhNojKp2qozfVJg=", "juanTmadPlayer" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, new Guid("09fc56a2-362d-43ca-9ff7-54eaa945e730") },
                    { 2, new Guid("779c7ed3-9859-4ba3-98e5-33532d7a5981") },
                    { 1, new Guid("daa70a93-4e90-4fbf-8fa7-c546a323e211") },
                    { 5, new Guid("ec7e38e0-68b2-4daa-b746-25656b18f9e3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_AdminUserId",
                table: "Tenant",
                column: "AdminUserId",
                unique: true,
                filter: "[AdminUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TenantAudience_AudienceId",
                table: "TenantAudience",
                column: "AudienceId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantKey_TenantId",
                table: "TenantKey",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantUser_TenantId",
                table: "TenantUser",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ClaimId",
                table: "UserClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKey_UserId",
                table: "UserKey",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_TenantId",
                table: "UserLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_UserId",
                table: "UserLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantAudience");

            migrationBuilder.DropTable(
                name: "TenantKey");

            migrationBuilder.DropTable(
                name: "TenantUser");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserKey");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
