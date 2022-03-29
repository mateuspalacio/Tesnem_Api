using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesnem.Api.Data.Migrations.IdentityDb
{
    public partial class changedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07da4238-ffa8-4651-a1fa-542d7a11946a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c417a54-5efa-41b5-b377-a6c5d86a04e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86e1036c-ea37-48e2-be37-8fde63bcd23d");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07da4238-ffa8-4651-a1fa-542d7a11946a", "612781a6-0feb-4c0c-96d3-1f2bcd820687", "Professor", "PROFESSOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c417a54-5efa-41b5-b377-a6c5d86a04e1", "7c34842b-2f43-4bb0-b3ec-e34b71a0f478", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86e1036c-ea37-48e2-be37-8fde63bcd23d", "5c873739-ce0e-4194-9bbf-3d9db5238ea6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
