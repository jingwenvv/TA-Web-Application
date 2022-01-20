using Microsoft.EntityFrameworkCore.Migrations;

namespace TA__Application.Migrations
{
    public partial class UpdateHourInAva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Availability");

            migrationBuilder.AddColumn<double>(
                name: "hour",
                table: "Availability",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hour",
                table: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
