using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    public partial class ChangedClassModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Classes",
                newName: "Professor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                newName: "IX_Classes_Professor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_Professor_Id",
                table: "Classes",
                column: "Professor_Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_Professor_Id",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Professor_Id",
                table: "Classes",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_Professor_Id",
                table: "Classes",
                newName: "IX_Classes_ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes",
                column: "ProfessorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
