using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryTime",
                table: "UserLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "UserLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 12, 36, 12, 222, DateTimeKind.Local).AddTicks(1010));

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
                    { 2, new Guid("07a1fd0a-2bc6-40ea-91c1-d2ea8be67e93") },
                    { 1, new Guid("2d1a9749-68f5-4456-8159-91923982cbf2") },
                    { 5, new Guid("4d8f1852-0d9e-4b0f-a26f-cff660b32311") },
                    { 3, new Guid("63c06053-6c0b-4084-a452-4d4fa96877d9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("741dc48b-5d25-4bf2-8abf-e11b1ceab34b"));

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

            migrationBuilder.DropColumn(
                name: "ExpiryTime",
                table: "UserLog");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "UserLog");

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
        }
    }
}
