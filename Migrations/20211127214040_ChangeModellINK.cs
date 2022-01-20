using Microsoft.EntityFrameworkCore.Migrations;

namespace TA__Application.Migrations
{
    public partial class ChangeModellINK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Application_ApplicationID",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_ApplicationID",
                table: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "Availabilities",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availabilities",
                table: "Application");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_ApplicationID",
                table: "Availability",
                column: "ApplicationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Application_ApplicationID",
                table: "Availability",
                column: "ApplicationID",
                principalTable: "Application",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
