using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDatabaseImplement.Migrations
{
    public partial class AddedNullableForMedal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medals_Electives_ElectiveId",
                table: "Medals");

            migrationBuilder.AlterColumn<int>(
                name: "ElectiveId",
                table: "Medals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medals_Electives_ElectiveId",
                table: "Medals",
                column: "ElectiveId",
                principalTable: "Electives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medals_Electives_ElectiveId",
                table: "Medals");

            migrationBuilder.AlterColumn<int>(
                name: "ElectiveId",
                table: "Medals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medals_Electives_ElectiveId",
                table: "Medals",
                column: "ElectiveId",
                principalTable: "Electives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
