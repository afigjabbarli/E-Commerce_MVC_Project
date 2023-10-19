using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class Size_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { -7, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "XXS", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -6, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "XS", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -5, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "S", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "M", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "L", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "XL", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "XXL", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
