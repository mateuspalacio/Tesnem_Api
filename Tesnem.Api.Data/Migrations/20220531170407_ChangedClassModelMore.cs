using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    public partial class ChangedClassModelMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_Course_Id",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_Professor_Id",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Course_Id",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Professor_Id",
                table: "Classes");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Classes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Classes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes",
                column: "ProfessorId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Person_ProfessorId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CourseId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Classes");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Course_Id",
                table: "Classes",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Professor_Id",
                table: "Classes",
                column: "Professor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_Course_Id",
                table: "Classes",
                column: "Course_Id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Person_Professor_Id",
                table: "Classes",
                column: "Professor_Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
