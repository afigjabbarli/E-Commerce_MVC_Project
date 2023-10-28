using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class Dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "Game consoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "Game consoles and accessories");
        }
    }
}
