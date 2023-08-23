using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreIdentity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Tenantfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_TenantAudience_Tenant_TenantId",
            //     table: "TenantAudience");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddForeignKey(
            //     name: "FK_TenantAudience_Tenant_TenantId",
            //     table: "TenantAudience",
            //     column: "TenantId",
            //     principalTable: "Tenant",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
