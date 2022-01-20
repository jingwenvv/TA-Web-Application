using Microsoft.EntityFrameworkCore.Migrations;

namespace TA__Application.Migrations
{
    public partial class changeEnrollment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseNum",
                table: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "Dept",
                table: "Enrollment",
                newName: "course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "course",
                table: "Enrollment",
                newName: "Dept");

            migrationBuilder.AddColumn<string>(
                name: "CourseNum",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
