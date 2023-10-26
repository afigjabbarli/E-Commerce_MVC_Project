using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform.Migrations
{
    public partial class Seedingdescriptiondatatocategoriestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Color_ColorId",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -7,
                column: "Description",
                value: "<<Phones, tablets, and gadgets>> refer to a diverse range of modern electronic devices. This category includes smartphones for communication, tablets for work and play, and various gadgets to enhance your digital life. Explore the latest in technology, connectivity, and convenience in this dynamic category.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -6,
                column: "Description",
                value: "<<Televisions, audio-video, and photography>> encompass the world of visual and auditory experiences. Within this category, you can find cutting-edge TVs for immersive viewing, audio equipment to elevate your sound, and photography gear to capture life's memorable moments. Dive into a world of stunning sights and sounds with these products.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -5,
                column: "Description",
                value: "<<Laptops and computer equipment>> provide the tools you need to stay connected and productive in the digital age. This category offers a range of laptops and essential computer peripherals and accessories. Whether you need a powerful laptop for work or play or require computer equipment to enhance your setup, you'll find it here.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4,
                column: "Description",
                value: "Air conditioners and other climate equipment includes a variety of devices designed to control the temperature and climate of your living or working space. This category offers a selection of air conditioners, heaters, fans, and other climate control equipment to help you create a comfortable environment in any season.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3,
                column: "Description",
                value: "<<Major home appliances>> refers to large, essential electrical machines commonly used in households to perform various tasks. These appliances are typically permanent fixtures and include items like refrigerators, washing machines, dryers, ovens, stoves, dishwashers, and more. They play a crucial role in modern living by simplifying daily tasks and enhancing overall household efficiency.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2,
                column: "Description",
                value: "<<Small appliances>> are compact and portable electrical devices designed to perform specific tasks in households. These appliances are typically used for various kitchen, cleaning, and personal care purposes. Examples of small appliances include toasters, blenders, coffee makers, electric kettles, microwave ovens, vacuum cleaners, irons, hair dryers, and more. Small appliances are known for their convenience, as they make daily chores and routines more manageable.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1,
                column: "Description",
                value: "Game consoles and accessories refer to the hardware and peripherals used for playing video games. Game consoles are specialized electronic devices designed primarily for gaming and typically come with built-in gaming capabilities, controllers, and other features. Accessories, on the other hand, are add-ons or enhancements that can improve the gaming experience. Common game consoles include products from companies like Sony (PlayStation), Microsoft (Xbox), and Nintendo, while accessories can encompass items like extra controllers, virtual reality headsets, gaming keyboards and mice, steering wheels, and more. Gamers often invest in these accessories to enhance their gameplay and overall enjoyment of video games.");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Colors_ColorId",
                table: "ProductColors",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Colors_ColorId",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Color_ColorId",
                table: "ProductColors",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
