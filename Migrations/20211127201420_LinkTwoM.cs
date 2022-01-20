using Microsoft.EntityFrameworkCore.Migrations;

namespace TA__Application.Migrations
{
    public partial class LinkTwoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Application_ApplicationID",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_ApplicationID",
                table: "Availability");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
