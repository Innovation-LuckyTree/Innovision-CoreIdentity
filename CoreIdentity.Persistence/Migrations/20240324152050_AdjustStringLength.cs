using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustStringLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("34256ae5-de73-426c-8748-de0e9c608377"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("153351ca-456d-4c8d-870d-1c9aca0a112a") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("517257b7-a537-4107-95c0-905f04e49c67") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("87d079fb-4d7b-4be5-9739-78b16dd07c81") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("9c47d44e-7c53-4ded-b52f-3478c178ce43") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("153351ca-456d-4c8d-870d-1c9aca0a112a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("517257b7-a537-4107-95c0-905f04e49c67"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("87d079fb-4d7b-4be5-9739-78b16dd07c81"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9c47d44e-7c53-4ded-b52f-3478c178ce43"));

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserLog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserDeviceToken",
                columns: table => new
                {
                    UserDeviceTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeviceToken", x => x.UserDeviceTokenId);
                    table.ForeignKey(
                        name: "FK_UserDeviceToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 23, 20, 49, 843, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 23, 20, 49, 843, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 23, 20, 49, 843, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 23, 20, 49, 843, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 24, 23, 20, 49, 843, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Attempts", "ChangePassword", "CompanyId", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "LockTime", "Locked", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("09df74ba-ee71-4e5f-90a4-7c1e51297716"), 0, false, null, new DateTime(2024, 3, 24, 23, 20, 49, 950, DateTimeKind.Local).AddTicks(3900), "juanTmadMasterAgent@gmail.com", true, null, null, false, "09090909099", true, "mWaVCfJnQQMX1EESeMftcjKuob/puxmg6fxhvtFlGuW5U3EJYiFTaf9+LDfmj/mrA9GDf78tKkOvayaOYgEosQ==", "hm0mt1KSHEpzYv7KEhj24ufgQqOgohJjYgR4xuBa564=", "juanTmadMasterAgent" },
                    { new Guid("68b4b3dd-0786-42d3-a6f4-20bab79b1869"), 0, false, null, new DateTime(2024, 3, 24, 23, 20, 50, 78, DateTimeKind.Local).AddTicks(9767), "juanTmadPlayer@gmail.com", true, null, null, false, "09090909099", true, "UOGLz0HEkAluMRLtj283TT1XfL17WnwvfqbZ1biWrvrTOJhp97jJ/Vk7SYRcr2ED5UA3WlWwFBH/IJr+svXKjQ==", "ZsBlveWv/bVIG+Lqc5hwjkU5qys6+Du1nROgYmUVAws=", "juanTmadPlayer" },
                    { new Guid("c96c7370-43fe-4626-b327-cc4f7dd3c995"), 0, false, null, new DateTime(2024, 3, 24, 23, 20, 50, 14, DateTimeKind.Local).AddTicks(2087), "juanTmadAgent@gmail.com", true, null, null, false, "09090909099", true, "hqnNe9XRhyMQ9DezLHkqjbPnJpvBaCOfJdiAJhYxyXNjLYQAZBnSl2stA9QZKd9BiRMOQrWL3IIcLRdYGacFFQ==", "MCm34P6r1FHan5Skf6FVo1JHcTkHH0WZOthU1SlqKn8=", "juanTmadAgent" },
                    { new Guid("cba2ada5-6aac-4cb8-9575-83609f28dec3"), 0, false, null, new DateTime(2024, 3, 24, 23, 20, 49, 845, DateTimeKind.Local).AddTicks(8977), "juanTmadAdmin@gmail.com", true, null, null, false, "09090909099", true, "Q5jRr6ZfVu0VRDnThfUo2NKSp3fd3kefYO72LcSn78+YXV+GC1Q0NXoMiSbQYC2iyf0eQpX0HfBS2gSUJUoFTw==", "C82toLJZT+ehVGz01R9sHXvnGLcgPE9xCzq3ZqAOBPc=", "juanTmadAdmin" },
                    { new Guid("fd0473d0-782a-4759-8eba-87e55bbf8746"), 0, false, null, new DateTime(2024, 3, 24, 23, 20, 49, 897, DateTimeKind.Local).AddTicks(6037), "juanTmadOperator@gmail.com", true, null, null, false, "09090909099", true, "dUy8YKDVqdJSsEVOrgEB09AcPTcbmDIOvLTbyKgtrE9aJa8ZIupsDJiDYdl4pbaOLlOROM0UyxIvDKGW1BNIiw==", "Vq2Jm0vyQ2YrQn3IP8iCKq6OT2cNpZj/7SOq0ixiOmE=", "juanTmadOperator" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, new Guid("09df74ba-ee71-4e5f-90a4-7c1e51297716") },
                    { 5, new Guid("68b4b3dd-0786-42d3-a6f4-20bab79b1869") },
                    { 1, new Guid("cba2ada5-6aac-4cb8-9575-83609f28dec3") },
                    { 2, new Guid("fd0473d0-782a-4759-8eba-87e55bbf8746") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDeviceToken_UserId",
                table: "UserDeviceToken",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDeviceToken");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c96c7370-43fe-4626-b327-cc4f7dd3c995"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("09df74ba-ee71-4e5f-90a4-7c1e51297716") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("68b4b3dd-0786-42d3-a6f4-20bab79b1869") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("cba2ada5-6aac-4cb8-9575-83609f28dec3") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("fd0473d0-782a-4759-8eba-87e55bbf8746") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("09df74ba-ee71-4e5f-90a4-7c1e51297716"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68b4b3dd-0786-42d3-a6f4-20bab79b1869"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cba2ada5-6aac-4cb8-9575-83609f28dec3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fd0473d0-782a-4759-8eba-87e55bbf8746"));

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserLog",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 10, 59, 49, 798, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 10, 59, 49, 798, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 10, 59, 49, 798, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 10, 59, 49, 798, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 10, 59, 49, 798, DateTimeKind.Local).AddTicks(3369));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Attempts", "ChangePassword", "CompanyId", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "LockTime", "Locked", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("153351ca-456d-4c8d-870d-1c9aca0a112a"), 0, false, null, new DateTime(2024, 2, 10, 10, 59, 49, 800, DateTimeKind.Local).AddTicks(8314), "juanTmadAdmin@gmail.com", true, null, null, false, "09090909099", true, "NPbsoJTFnoLOut2PrQpeMZNGui/YwUwVn2JrLPCuRIuXG/CFsejj6X+hi2TvUmnH3NqJ33Z4xcD/CXAJuinWhQ==", "2JhQiT08xCW7sXczjHh2tEdJJa4DkyAUVuqgTnACbKg=", "juanTmadAdmin" },
                    { new Guid("34256ae5-de73-426c-8748-de0e9c608377"), 0, false, null, new DateTime(2024, 2, 10, 10, 59, 49, 956, DateTimeKind.Local).AddTicks(7190), "juanTmadAgent@gmail.com", true, null, null, false, "09090909099", true, "qx204OmXcumePgFgAnOaKS/dc6m3dmjcKW3ibobVFwmzZ03nr6LP0c6JTm0xE6mPSFuLQOCMM5At9Mgykfoqog==", "6EvZ8Hf2GompfqpAceul3xJkDbYS9Rqm/qx+aiLGqws=", "juanTmadAgent" },
                    { new Guid("517257b7-a537-4107-95c0-905f04e49c67"), 0, false, null, new DateTime(2024, 2, 10, 10, 59, 49, 850, DateTimeKind.Local).AddTicks(7391), "juanTmadOperator@gmail.com", true, null, null, false, "09090909099", true, "vqH+Ua8Zq5mJepZhInX+YCEhxtY6CWTwR8MeOnTCmtuP1FVDl9dWFNZjPqvRM9I5fHHJTctwSRfC7c/ARqq//w==", "Fyfa2E2VSsJ0Kzy3ds6g0DH3SSzeqCSN1BbdHd8f200=", "juanTmadOperator" },
                    { new Guid("87d079fb-4d7b-4be5-9739-78b16dd07c81"), 0, false, null, new DateTime(2024, 2, 10, 10, 59, 50, 8, DateTimeKind.Local).AddTicks(9501), "juanTmadPlayer@gmail.com", true, null, null, false, "09090909099", true, "DkdbEh00tyU/jGY+6HMISVtGvZl35pp4J9sPXxn1nLQ6Gdqorz4oGGAT+u03lRxzKOm4nHXbw+F2iLhVXN67tQ==", "5hJhm4Vp08iT/kO0QATirRoiqxAOLvFzO7OsXiMqgJo=", "juanTmadPlayer" },
                    { new Guid("9c47d44e-7c53-4ded-b52f-3478c178ce43"), 0, false, null, new DateTime(2024, 2, 10, 10, 59, 49, 904, DateTimeKind.Local).AddTicks(6900), "juanTmadMasterAgent@gmail.com", true, null, null, false, "09090909099", true, "ZUlV8XqJ35AlAcQuU9ADsz+i7BQSo/QFDRsElkqFtWFczJZ61PMK4VFLKje6/o3WSW9xWbWEaU0nxxqdx0lIrQ==", "NPnxGqLBQQeQ95y3Mne1+ZZhOfB65Dr2WM5p99r7Bgg=", "juanTmadMasterAgent" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("153351ca-456d-4c8d-870d-1c9aca0a112a") },
                    { 2, new Guid("517257b7-a537-4107-95c0-905f04e49c67") },
                    { 5, new Guid("87d079fb-4d7b-4be5-9739-78b16dd07c81") },
                    { 3, new Guid("9c47d44e-7c53-4ded-b52f-3478c178ce43") }
                });
        }
    }
}
