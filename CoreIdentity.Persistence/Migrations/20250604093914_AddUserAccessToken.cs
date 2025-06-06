using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccessToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("741dc48b-5d25-4bf2-8abf-e11b1ceab34b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("07a1fd0a-2bc6-40ea-91c1-d2ea8be67e93") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("2d1a9749-68f5-4456-8159-91923982cbf2") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("4d8f1852-0d9e-4b0f-a26f-cff660b32311") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("63c06053-6c0b-4084-a452-4d4fa96877d9") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("07a1fd0a-2bc6-40ea-91c1-d2ea8be67e93"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2d1a9749-68f5-4456-8159-91923982cbf2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4d8f1852-0d9e-4b0f-a26f-cff660b32311"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("63c06053-6c0b-4084-a452-4d4fa96877d9"));

            migrationBuilder.AlterColumn<long>(
                name: "UserLogId",
                table: "UserLog",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "LogId",
                table: "UserLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserAccessToken",
                columns: table => new
                {
                    UserAccessTokenId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLogId = table.Column<long>(type: "bigint", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessTokenKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessToken", x => x.UserAccessTokenId);
                    table.ForeignKey(
                        name: "FK_UserAccessToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessTokenLog",
                columns: table => new
                {
                    UserAccessTokenLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccessTokenId = table.Column<long>(type: "bigint", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessTokenLog", x => x.UserAccessTokenLogId);
                    table.ForeignKey(
                        name: "FK_UserAccessTokenLog_UserAccessToken_UserAccessTokenId",
                        column: x => x.UserAccessTokenId,
                        principalTable: "UserAccessToken",
                        principalColumn: "UserAccessTokenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessToken_UserId",
                table: "UserAccessToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessTokenLog_UserAccessTokenId",
                table: "UserAccessTokenLog",
                column: "UserAccessTokenId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_UserLog_UserAccessToken_UserLogId",
            //     table: "UserLog",
            //     column: "UserLogId",
            //     principalTable: "UserAccessToken",
            //     principalColumn: "UserAccessTokenId",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLog_UserAccessToken_UserLogId",
                table: "UserLog");

            migrationBuilder.DropTable(
                name: "UserAccessTokenLog");

            migrationBuilder.DropTable(
                name: "UserAccessToken");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "UserLog");

            migrationBuilder.AlterColumn<int>(
                name: "UserLogId",
                table: "UserLog",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "LastModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1003), null, "Super Admin" },
                    { 2, new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1006), null, "Operator" },
                    { 3, new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1007), null, "Master Agent" },
                    { 4, new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1008), null, "Agent" },
                    { 5, new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1010), null, "Player" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Attempts", "ChangePassword", "CompanyId", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "LockTime", "Locked", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("07a1fd0a-2bc6-40ea-91c1-d2ea8be67e93"), 0, false, null, new DateTime(2024, 7, 9, 12, 36, 12, 274, DateTimeKind.Local).AddTicks(9371), "juanTmadOperator@gmail.com", true, null, null, false, "09090909099", true, "vnmYtkwXWErjNOmtRrPN1zAFNneYV5tytl35N0LExUCGl34CEWJT0wnMJtct9oEdR+MQq6Bni59H0alhvdVaJA==", "GjIim7qBrjgZMjymiIbV4uN1umclK1jn74rgeyaI3M4=", "juanTmadOperator" },
                    { new Guid("2d1a9749-68f5-4456-8159-91923982cbf2"), 0, false, null, new DateTime(2024, 7, 9, 12, 36, 12, 224, DateTimeKind.Local).AddTicks(8606), "juanTmadAdmin@gmail.com", true, null, null, false, "09090909099", true, "g56nlg9W+OCojktyQkDlIdc5bY3UpDDqm1ZAP51C/t4l04sYOJy/FPJBEQXp1+AdUxNP04BkToSvFherxjZ5kQ==", "+hKj+3ir1jImWNXn9oIrOarxzw1E2FWB7AGza3Ipfwk=", "juanTmadAdmin" },
                    { new Guid("4d8f1852-0d9e-4b0f-a26f-cff660b32311"), 0, false, null, new DateTime(2024, 7, 9, 12, 36, 12, 456, DateTimeKind.Local).AddTicks(7064), "juanTmadPlayer@gmail.com", true, null, null, false, "09090909099", true, "L3Yp4H/jYccdlxvUA2BG/IL6LVMd1CJhW2pYSasLICFQB3NHyZMqPkPAy381d4RaRTNwDfJlUZu3GNTDVDbPOg==", "fMMYhijxbxmuhzXyK/ffn4Wxg4Z2o8SU0Wt0aXLv1SQ=", "juanTmadPlayer" },
                    { new Guid("63c06053-6c0b-4084-a452-4d4fa96877d9"), 0, false, null, new DateTime(2024, 7, 9, 12, 36, 12, 325, DateTimeKind.Local).AddTicks(3973), "juanTmadMasterAgent@gmail.com", true, null, null, false, "09090909099", true, "pyCKX1UcKZ54pufoMQc2CWJ7TZKB6glp7mUbIA/rdVKcPzTVGIws1JGbNnPxWp27hJ4j1ZQ7bJj82HLF8n45cg==", "P/N/yaQp+WJrwb1uUV8Cn5dFK/eSEwtI/aWXC4hPdbA=", "juanTmadMasterAgent" },
                    { new Guid("741dc48b-5d25-4bf2-8abf-e11b1ceab34b"), 0, false, null, new DateTime(2024, 7, 9, 12, 36, 12, 394, DateTimeKind.Local).AddTicks(3591), "juanTmadAgent@gmail.com", true, null, null, false, "09090909099", true, "yudtaQJU1ja2Qiu2MRhKLfZGw4eem3e4/u9fjtcnCZ6fwUyLdfUvWisFFPK15ZCIxUgTbihNrpovGUiHKgJXvA==", "+3jjxLIF4ZFDhPtz2ydu6YShkVMiw+3VaS2ZHg1nE0s=", "juanTmadAgent" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, new Guid("07a1fd0a-2bc6-40ea-91c1-d2ea8be67e93") },
                    { 1, new Guid("2d1a9749-68f5-4456-8159-91923982cbf2") },
                    { 5, new Guid("4d8f1852-0d9e-4b0f-a26f-cff660b32311") },
                    { 3, new Guid("63c06053-6c0b-4084-a452-4d4fa96877d9") }
                });
        }
    }
}
