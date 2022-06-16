using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    public partial class ReMake2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId1",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_ProfessorId1",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Classes_ClassId1",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Person_StudentId1",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "StudentId1",
                table: "Tests",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ClassId1",
                table: "Tests",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_StudentId1",
                table: "Tests",
                newName: "IX_Tests_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_ClassId1",
                table: "Tests",
                newName: "IX_Tests_ClassId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId1",
                table: "Classes",
                newName: "ProfessorId");

            migrationBuilder.RenameColumn(
                name: "CourseId1",
                table: "Classes",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ProfessorId1",
                table: "Classes",
                newName: "IX_Classes_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_CourseId1",
                table: "Classes",
                newName: "IX_Classes_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes",
                column: "ProfessorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Classes_ClassId",
                table: "Tests",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Person_StudentId",
                table: "Tests",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Classes_ClassId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Person_StudentId",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Tests",
                newName: "StudentId1");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Tests",
                newName: "ClassId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_StudentId",
                table: "Tests",
                newName: "IX_Tests_StudentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_ClassId",
                table: "Tests",
                newName: "IX_Tests_ClassId1");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Classes",
                newName: "ProfessorId1");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Classes",
                newName: "CourseId1");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                newName: "IX_Classes_ProfessorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                newName: "IX_Classes_CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId1",
                table: "Classes",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_ProfessorId1",
                table: "Classes",
                column: "ProfessorId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Classes_ClassId1",
                table: "Tests",
                column: "ClassId1",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Person_StudentId1",
                table: "Tests",
                column: "StudentId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
