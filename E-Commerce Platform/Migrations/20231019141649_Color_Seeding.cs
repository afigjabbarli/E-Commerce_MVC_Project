using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class Color_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { -5, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Black", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Gray", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Blue", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "White", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Red", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
