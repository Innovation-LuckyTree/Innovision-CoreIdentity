using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserLog",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Tenant",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AppKey",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "LastModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 25, 21, 2, 19, 381, DateTimeKind.Local).AddTicks(6940), null, "Super Admin" },
                    { 2, new DateTime(2023, 9, 25, 21, 2, 19, 381, DateTimeKind.Local).AddTicks(6943), null, "Operator" },
                    { 3, new DateTime(2023, 9, 25, 21, 2, 19, 381, DateTimeKind.Local).AddTicks(6944), null, "Master Agent" },
                    { 4, new DateTime(2023, 9, 25, 21, 2, 19, 381, DateTimeKind.Local).AddTicks(6945), null, "Agent" },
                    { 5, new DateTime(2023, 9, 25, 21, 2, 19, 381, DateTimeKind.Local).AddTicks(6947), null, "Player" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ChangePassword", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("064aec21-220f-448c-ada1-f76214bf64e7"), false, new DateTime(2023, 9, 25, 21, 2, 19, 384, DateTimeKind.Local).AddTicks(2526), "juanTmadAdmin@gmail.com", true, null, "09090909099", true, "wje69iDpTtCH8SG63ixkE3FAgr1PKUo8eBffrl7T55DkhdIZYh2yfpY/4wnRYnAAP1K0PRfJi1gXtpmFY3BBCw==", "zAtqUUPG8Jod25qRRkW1d2P2AbRTT6GzRkx8u5Djp84=", "juanTmadAdmin" },
                    { new Guid("209d9489-db14-42d9-a9f3-286602af2f4a"), false, new DateTime(2023, 9, 25, 21, 2, 19, 460, DateTimeKind.Local).AddTicks(2445), "juanTmadMasterAgent@gmail.com", true, null, "09090909099", true, "Nvi5mb9CaoMag2NjilhOvV51uXqD58GQYaDQqr6zXjpDf9iCUG18GX19bJ+lBiBVQTtuoHSUeHCWrjJXJXHeqg==", "NEzIFqdwxtk3w9gzyyQvdrF0grPvXSVidtyAo8WmWSo=", "juanTmadMasterAgent" },
                    { new Guid("3a52b95a-87b2-4159-9fd9-411b7c8b7c9e"), false, new DateTime(2023, 9, 25, 21, 2, 19, 497, DateTimeKind.Local).AddTicks(6874), "juanTmadAgent@gmail.com", true, null, "09090909099", true, "a5QHFrVGJnzvPOMTGsnMQprgrgAjfDXEH2oEFwk4Fw0pRDwsiw+6twnxO9WV7xWL/6NFb45/PDwQuYOiXvNubQ==", "uxmaAamlkmMUn7YlEmC/LtraPj8Xyf8eECnZaooc4zg=", "juanTmadAgent" },
                    { new Guid("51d69e59-44db-4d02-8261-8d1627224267"), false, new DateTime(2023, 9, 25, 21, 2, 19, 421, DateTimeKind.Local).AddTicks(7895), "juanTmadOperator@gmail.com", true, null, "09090909099", true, "/PywDXfiKpzjxIBJ3jSczMM/gLtVord0l5e+52BD0kHS1b84M7x8a1Z06CCgUkP8Gs+w274+237ENbwKNB1m/w==", "OZBD2KgSAKnp3afxlPdnvreQuUpVaGyJnGE2e+pl90A=", "juanTmadOperator" },
                    { new Guid("9f9f3b89-1511-4e99-a4fb-e19699557fd1"), false, new DateTime(2023, 9, 25, 21, 2, 19, 535, DateTimeKind.Local).AddTicks(5739), "juanTmadPlayer@gmail.com", true, null, "09090909099", true, "+qT5E47w0c2yJrGE2HXj7+aNPx1A7E+kKAL5pMC8UxuTRGdTXhQ63o8N2lkUGIO011GSjXhrS5mANYo703P+vg==", "eu8rqGO8wqjr4E/c1NsE1myy1/ll6ndg8hLZnk5K1wk=", "juanTmadPlayer" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, new Guid("3a52b95a-87b2-4159-9fd9-411b7c8b7c9e") },
                    { 1, new Guid("064aec21-220f-448c-ada1-f76214bf64e7") },
                    { 3, new Guid("209d9489-db14-42d9-a9f3-286602af2f4a") },
                    { 2, new Guid("51d69e59-44db-4d02-8261-8d1627224267") },
                    { 5, new Guid("9f9f3b89-1511-4e99-a4fb-e19699557fd1") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3a52b95a-87b2-4159-9fd9-411b7c8b7c9e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("064aec21-220f-448c-ada1-f76214bf64e7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("209d9489-db14-42d9-a9f3-286602af2f4a") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("51d69e59-44db-4d02-8261-8d1627224267") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("9f9f3b89-1511-4e99-a4fb-e19699557fd1") });

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
                keyValue: new Guid("064aec21-220f-448c-ada1-f76214bf64e7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("209d9489-db14-42d9-a9f3-286602af2f4a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("51d69e59-44db-4d02-8261-8d1627224267"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f9f3b89-1511-4e99-a4fb-e19699557fd1"));

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "UserLog",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Issuer",
                table: "Tenant",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Domain",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppKey",
                table: "Tenant",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
