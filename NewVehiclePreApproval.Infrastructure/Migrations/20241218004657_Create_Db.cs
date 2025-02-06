using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewVehiclePreApproval.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seller_information_dealership = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    seller_information_vendor_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_information_full_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    client_information_email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    client_information_phone_number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    client_information_dni = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    client_information_rtn = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    client_information_estimated_monthly_income = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    client_information_state = table.Column<string>(type: "text", nullable: false),
                    client_information_city = table.Column<string>(type: "text", nullable: false),
                    client_information_home_address = table.Column<string>(type: "text", nullable: false),
                    client_information_work_or_business_name = table.Column<string>(type: "text", nullable: false),
                    client_information_work_or_business_description = table.Column<string>(type: "text", nullable: false),
                    client_information_work_or_business_address = table.Column<string>(type: "text", nullable: false),
                    vehicle_information_brand = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vehicle_information_model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vehicle_information_year = table.Column<int>(type: "integer", nullable: false),
                    vehicle_information_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    rejection_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_requests", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_requests_id",
                table: "requests",
                column: "id",
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
