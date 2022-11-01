using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcesss.Migrations
{
    public partial class AddedTotalReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "63b92e30-5828-4b5b-836a-30040f9424f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5c327c5c-0ccd-4b6b-bf7a-05829bbf3a95");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "67dcfad6-c8b4-4c07-9598-2ea0dd3809ff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "09a211b8-8912-4a84-9101-0eaca5cbeb81");
        }
    }
}
