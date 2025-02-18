using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewVehiclePreApproval.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Request_Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "requests");
        }
    }
}
