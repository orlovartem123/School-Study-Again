using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDatabaseImplement.Migrations
{
    public partial class fixInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialInterests_Interests_MaterialId",
                table: "MaterialInterests");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialInterests_InterestId",
                table: "MaterialInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialInterests_Interests_InterestId",
                table: "MaterialInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialInterests_Interests_InterestId",
                table: "MaterialInterests");

            migrationBuilder.DropIndex(
                name: "IX_MaterialInterests_InterestId",
                table: "MaterialInterests");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialInterests_Interests_MaterialId",
                table: "MaterialInterests",
                column: "MaterialId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
