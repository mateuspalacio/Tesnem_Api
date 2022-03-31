using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations.IdentityDb
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a28b30-1c44-4c9e-8bae-917187ea8af9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78cc421a-532b-43c5-8df1-725bede3eac8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2dadb8a-a15f-4657-ade5-8efb3973280a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c21d5e2-cc9c-499d-a590-ca201fa42b95", "d55a61a8-687b-4890-9e02-f19bf20ffd91", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac6b87ed-d4a7-4a3f-a335-08bd101a0429", "25f2f4aa-eed8-4a4e-8a6e-630b5241a997", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb854c6e-9127-4c40-9b3d-7d2cfc9b57df", "897d392f-af32-4cc7-bbce-12aaa486ff5d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c21d5e2-cc9c-499d-a590-ca201fa42b95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6b87ed-d4a7-4a3f-a335-08bd101a0429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb854c6e-9127-4c40-9b3d-7d2cfc9b57df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68a28b30-1c44-4c9e-8bae-917187ea8af9", "1e080937-99f2-4562-a126-91abb170367a", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78cc421a-532b-43c5-8df1-725bede3eac8", "aff8c6e2-9ddb-4e67-8721-6a59d3d7ff88", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2dadb8a-a15f-4657-ade5-8efb3973280a", "69d7a5b9-4873-4041-b59a-62c81cf4f6d8", "Administrator", "ADMINISTRATOR" });
        }
    }
}
