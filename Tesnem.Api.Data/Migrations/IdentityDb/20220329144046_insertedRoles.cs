using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations.IdentityDb
{
    public partial class insertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c6e88c5-6fec-49d4-93b4-43fa33952ccd", "5887b9c8-2936-4ca1-8939-43de8914df14", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55fe190a-f21a-4982-a62d-3729934f1dcc", "65e1a593-d411-45d8-9430-d8ea6bf310dc", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91bae2b8-ae9b-4c60-8981-76d06b0592a8", "dffbbf8e-ea24-4802-89c5-f9082346bb52", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c6e88c5-6fec-49d4-93b4-43fa33952ccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55fe190a-f21a-4982-a62d-3729934f1dcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91bae2b8-ae9b-4c60-8981-76d06b0592a8");
        }
    }
}
