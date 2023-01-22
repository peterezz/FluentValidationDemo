using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DairElAnbaBeshoy.Core.Migrations
{
    public partial class AddIsApproveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "06b5ecc1-bf8b-475f-ada1-b11830563e00");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "122e49a1-36fc-4536-91ce-b6a89b27a937");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Retreaves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19d071fc-4481-4cc6-9f35-701bddcddac0", "7cf52f6d-94eb-4f6d-9a58-6e160ed2cee7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae0d5294-f0b2-48ae-b726-75ada179aa20", "8956f1c2-0b6b-4972-954a-210d4fc45bc1", "BasicUser", "BASICUSER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "19d071fc-4481-4cc6-9f35-701bddcddac0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ae0d5294-f0b2-48ae-b726-75ada179aa20");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Retreaves");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06b5ecc1-bf8b-475f-ada1-b11830563e00", "51a4fa06-96e7-4965-a198-0102044af2e8", "BasicUser", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "122e49a1-36fc-4536-91ce-b6a89b27a937", "7584f780-028a-4cf1-b702-384cb3d5869e", "Admin", null });
        }
    }
}
