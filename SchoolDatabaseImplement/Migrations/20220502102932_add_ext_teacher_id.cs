using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDatabaseImplement.Migrations
{
    public partial class add_ext_teacher_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtId",
                table: "Teachers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtId",
                table: "Teachers");
        }
    }
}
