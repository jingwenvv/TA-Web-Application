using Microsoft.EntityFrameworkCore.Migrations;

namespace TA__Application.Migrations
{
    public partial class addTempString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tempString",
                table: "Availability",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tempString",
                table: "Availability");
        }
    }
}
