using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    public partial class EnrollmentUpdateFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Person_EnrollmentId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "EnrollmentNumber",
                table: "Enrollments",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Enrollments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_PersonId",
                table: "Enrollments",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Person_PersonId",
                table: "Enrollments",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Person_PersonId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_PersonId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentNumber",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Enrollments");

            migrationBuilder.AddColumn<Guid>(
                name: "EnrollmentId",
                table: "Person",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EnrollmentId",
                table: "Person",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Enrollments_EnrollmentId",
                table: "Person",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
