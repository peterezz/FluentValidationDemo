using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DairElAnbaBeshoy.Core.Migrations
{
    public partial class UpdatedRetreavesScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoverGovernorate",
                table: "Retreaves",
                newName: "Governorate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Governorate",
                table: "Retreaves",
                newName: "GoverGovernorate");
        }
    }
}
