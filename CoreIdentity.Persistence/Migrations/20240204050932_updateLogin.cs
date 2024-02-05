using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cac331ea-5c0b-4470-b395-cd91ced1630f"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("09fc56a2-362d-43ca-9ff7-54eaa945e730") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("779c7ed3-9859-4ba3-98e5-33532d7a5981") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("daa70a93-4e90-4fbf-8fa7-c546a323e211") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("ec7e38e0-68b2-4daa-b746-25656b18f9e3") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("09fc56a2-362d-43ca-9ff7-54eaa945e730"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("779c7ed3-9859-4ba3-98e5-33532d7a5981"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("daa70a93-4e90-4fbf-8fa7-c546a323e211"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec7e38e0-68b2-4daa-b746-25656b18f9e3"));

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockTime",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 13, 9, 31, 653, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 13, 9, 31, 653, DateTimeKind.Local).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 13, 9, 31, 653, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 13, 9, 31, 653, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 4, 13, 9, 31, 653, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Attempts", "ChangePassword", "CreatedOn", "Email", "EmailConfirmed", "LastModifiedBy", "LockTime", "Locked", "MobileNumber", "MobilePrimary", "Password", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { new Guid("3ddd94ac-51d8-4688-a3aa-23aab22c1554"), 0, false, new DateTime(2024, 2, 4, 13, 9, 31, 663, DateTimeKind.Local).AddTicks(4284), "juanTmadAdmin@gmail.com", true, null, null, false, "09090909099", true, "m7zDkbTPXA0rOnWN9uPFQHKXqtQmmoIlz4JdeH3BjNQ2YoR6ceNA5wU4tfVr68//PYwnUM8mpO2XDt2ino55yg==", "xP83ledzy4vsg2Nk1mfs4ghY5xJ33BM4FgY8Z8CBjCE=", "juanTmadAdmin" },
                    { new Guid("501f564b-8cff-49d9-bb1e-3e654139b989"), 0, false, new DateTime(2024, 2, 4, 13, 9, 31, 971, DateTimeKind.Local).AddTicks(6764), "juanTmadPlayer@gmail.com", true, null, null, false, "09090909099", true, "gCzxmRoiMP4OBQlmzqpOEnw7SkUxUOd/3hkFN9krZewDUXqbcD6YTDRHoBEajL6C7YrzA/R3Yi2s9DA6wPsTdg==", "vzRjR+o5cqN84+qMkoq/X6vkVOF5Z8iSZPZPpfPvUrE=", "juanTmadPlayer" },
                    { new Guid("78cf1a61-a484-43b9-9e07-8f6503dedee0"), 0, false, new DateTime(2024, 2, 4, 13, 9, 31, 748, DateTimeKind.Local).AddTicks(2925), "juanTmadOperator@gmail.com", true, null, null, false, "09090909099", true, "kpFwbcc8x1s3i6Zco0JjFU8jWeto87S0BSHZbtJQjZQzgXdb/ndb80kXtQpzj0Zmsd1vRAz03ysYMh+tjtXp+A==", "2fCWLeBV4y8l/i4xYVOKISlJABn+q1G3pFdQY8LuHko=", "juanTmadOperator" },
                    { new Guid("ad1cac91-f172-4fbb-9f5c-dd22b5c78740"), 0, false, new DateTime(2024, 2, 4, 13, 9, 31, 830, DateTimeKind.Local).AddTicks(6077), "juanTmadMasterAgent@gmail.com", true, null, null, false, "09090909099", true, "IFh0LaQu7NdasqH4zIjE7u+1jURcTiz+IX8rdjYRIi+ixrDyc+/a7czxuphALxJx2Ce8C1i4UNJZY03q9x24Pg==", "Q7iiC9/nXaZ/YiLI2eRRTzNKAmjTUEXN7qRmHxtQhtc=", "juanTmadMasterAgent" },
                    { new Guid("e2922d48-78b7-46a9-9e4c-7138850faa8e"), 0, false, new DateTime(2024, 2, 4, 13, 9, 31, 903, DateTimeKind.Local).AddTicks(5643), "juanTmadAgent@gmail.com", true, null, null, false, "09090909099", true, "gFzbdXtQCou92N9Qz5LoGdmI6ooBValig5GIhdWgGLE1V2yAhGj8fCWAbOWqXph6z7vaDR72cU5X5+PhvfxxwA==", "IhLx4TC7tfEEDjHDAPPLxX7/WV/BPktruZFwpC9aEm4=", "juanTmadAgent" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("3ddd94ac-51d8-4688-a3aa-23aab22c1554") },
                    { 5, new Guid("501f564b-8cff-49d9-bb1e-3e654139b989") },
                    { 2, new Guid("78cf1a61-a484-43b9-9e07-8f6503dedee0") },
                    { 3, new Guid("ad1cac91-f172-4fbb-9f5c-dd22b5c78740") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e2922d48-78b7-46a9-9e4c-7138850faa8e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("3ddd94ac-51d8-4688-a3aa-23aab22c1554") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, new Guid("501f564b-8cff-49d9-bb1e-3e654139b989") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("78cf1a61-a484-43b9-9e07-8f6503dedee0") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, new Guid("ad1cac91-f172-4fbb-9f5c-dd22b5c78740") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3ddd94ac-51d8-4688-a3aa-23aab22c1554"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("501f564b-8cff-49d9-bb1e-3e654139b989"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("78cf1a61-a484-43b9-9e07-8f6503dedee0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ad1cac91-f172-4fbb-9f5c-dd22b5c78740"));

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 5, 12, 58, 15, 790, DateTimeKind.Local).AddTicks(9788));

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
                    { 3, new Guid("09fc56a2-362d-43ca-9ff7-54eaa945e730") },
                    { 2, new Guid("779c7ed3-9859-4ba3-98e5-33532d7a5981") },
                    { 1, new Guid("daa70a93-4e90-4fbf-8fa7-c546a323e211") },
                    { 5, new Guid("ec7e38e0-68b2-4daa-b746-25656b18f9e3") }
                });
        }
    }
}
