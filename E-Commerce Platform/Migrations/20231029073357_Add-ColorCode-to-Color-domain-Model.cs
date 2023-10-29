using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class AddColorCodetoColordomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Colors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -5,
                column: "Code",
                value: "#000000");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -4,
                column: "Code",
                value: "#666666");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -3,
                column: "Code",
                value: "#0052d6");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -2,
                column: "Code",
                value: "#ffffff");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -1,
                column: "Code",
                value: "#ff0000");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { -7, "#fbff00", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Yellow", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -6, "#04b40f", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Green", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Colors");
        }
    }
}
