using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class includecompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "User");

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
    }
}
