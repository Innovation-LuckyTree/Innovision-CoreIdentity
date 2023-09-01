using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatetenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "TenantKey",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "TenantKey");
        }
    }
}
