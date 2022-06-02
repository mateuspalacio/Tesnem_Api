using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    public partial class AddedPastCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CourseRequirement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRequirement", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastCourses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseCourseRequirement",
                columns: table => new
                {
                    RequirementsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequirementsId1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCourseRequirement", x => new { x.RequirementsId, x.RequirementsId1 });
                    table.ForeignKey(
                        name: "FK_CourseCourseRequirement_CourseRequirement_RequirementsId1",
                        column: x => x.RequirementsId1,
                        principalTable: "CourseRequirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCourseRequirement_Courses_RequirementsId",
                        column: x => x.RequirementsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastCoursesStudent",
                columns: table => new
                {
                    CoursesCompletedIdId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentsWhoCompletedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastCoursesStudent", x => new { x.CoursesCompletedIdId, x.StudentsWhoCompletedId });
                    table.ForeignKey(
                        name: "FK_PastCoursesStudent_PastCourses_CoursesCompletedIdId",
                        column: x => x.CoursesCompletedIdId,
                        principalTable: "PastCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastCoursesStudent_Person_StudentsWhoCompletedId",
                        column: x => x.StudentsWhoCompletedId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCourseRequirement_RequirementsId1",
                table: "CourseCourseRequirement",
                column: "RequirementsId1");

            migrationBuilder.CreateIndex(
                name: "IX_PastCoursesStudent_StudentsWhoCompletedId",
                table: "PastCoursesStudent",
                column: "StudentsWhoCompletedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCourseRequirement");

            migrationBuilder.DropTable(
                name: "PastCoursesStudent");

            migrationBuilder.DropTable(
                name: "CourseRequirement");

            migrationBuilder.DropTable(
                name: "PastCourses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Courses");
        }
    }
}
