using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewVehiclePreApproval.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_User_Dealership_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_DealershipId",
                table: "users",
                column: "DealershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_dealerships_DealershipId",
                table: "users",
                column: "DealershipId",
                principalTable: "dealerships",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_dealerships_DealershipId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_DealershipId",
                table: "users");
        }
    }
}
