using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DairElAnbaBeshoy.Core.Migrations
{
    public partial class UpdateRetreaveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "962d8c1f-b68d-4722-84a7-14bd37697c44");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9f38b249-a33e-475e-b8f8-e8ba94e9789e");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Retreaves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06b5ecc1-bf8b-475f-ada1-b11830563e00", "51a4fa06-96e7-4965-a198-0102044af2e8", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "122e49a1-36fc-4536-91ce-b6a89b27a937", "7584f780-028a-4cf1-b702-384cb3d5869e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "06b5ecc1-bf8b-475f-ada1-b11830563e00");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "122e49a1-36fc-4536-91ce-b6a89b27a937");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Retreaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "962d8c1f-b68d-4722-84a7-14bd37697c44", "13ef5f4a-ab9d-4e78-b628-db305f82874d", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f38b249-a33e-475e-b8f8-e8ba94e9789e", "1fdfb835-da4e-49fa-a432-7875c67211f3", "BasicUser", null });
        }
    }
}
