using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DairElAnbaBeshoy.Core.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.InsertData(
                table: "Roles" ,
                columns: new[ ] { "Id" , "ConcurrencyStamp" , "Name" , "NormalizedName" } ,
                values: new object[ ] { "55b5ead0-820b-48d3-8ebe-dc43564d8ed2" , "31b95770-03a3-4007-a3f5-1454e62f5e43" , "Admin" , "ADMIN" } );

            migrationBuilder.InsertData(
                table: "Roles" ,
                columns: new[ ] { "Id" , "ConcurrencyStamp" , "Name" , "NormalizedName" } ,
                values: new object[ ] { "8d5e05ec-de2b-4a2e-b35c-8480ff842a22" , "0f6247b8-e5aa-449a-9667-d921f8a9dbb3" , "BasicUser" , "BASICUSER" } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DeleteData(
                table: "Roles" ,
                keyColumn: "Id" ,
                keyValue: "55b5ead0-820b-48d3-8ebe-dc43564d8ed2" );

            migrationBuilder.DeleteData(
                table: "Roles" ,
                keyColumn: "Id" ,
                keyValue: "8d5e05ec-de2b-4a2e-b35c-8480ff842a22" );
        }
    }
}
