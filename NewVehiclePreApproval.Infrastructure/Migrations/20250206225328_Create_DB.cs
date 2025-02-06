using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewVehiclePreApproval.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerInformation_Dealership = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SellerInformation_VendorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientInformation_FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientInformation_Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ClientInformation_PhoneNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ClientInformation_Dni = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ClientInformation_Rtn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    ClientInformation_EstimatedMonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClientInformation_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInformation_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInformation_HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInformation_WorkOrBusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInformation_WorkOrBusinessDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInformation_WorkOrBusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleInformation_Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleInformation_Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleInformation_Year = table.Column<int>(type: "int", nullable: false),
                    VehicleInformation_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleInformation_Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requests_Id",
                table: "requests",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requests");
        }
    }
}
