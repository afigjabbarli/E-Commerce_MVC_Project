using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class Category_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { -7, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Phones, tablets and gadgets", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -6, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Televisions, audio-video and photography", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -5, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Laptops and computer equipment", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -4, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Air conditioners and other climate equipment", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -3, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Major Home Appliances", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -2, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Small Appliances", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { -1, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Game consoles and accessories", new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
