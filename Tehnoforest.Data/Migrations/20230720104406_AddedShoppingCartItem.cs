using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class AddedShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Automowers_AutomowerId",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "Automowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Automowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "AutomowerId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "LawnMowers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "GrassTrimmers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Automowers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Automowers_AutomowerId",
                table: "ShoppingCartItems",
                column: "AutomowerId",
                principalTable: "Automowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Automowers_AutomowerId",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "AutomowerId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "LawnMowers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "GrassTrimmers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Automowers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Automowers",
                columns: new[] { "Id", "Availability", "BoundaryType", "Description", "ImageUrl", "IsAvailable", "MaximumSlopePerformance", "Model", "Price", "UserId", "WorkingAreaCapacity" },
                values: new object[] { 1, 5, "Wire", "Husqvarna Automower® 305 се характеризира с компактен дизайн и е идеална за по-малки, комплексни градини с площ до 600 m2 като с лекота обработва склонове с наклон от 40%. Четирколесната платформа, заедно със систематичното управление на проходите осигурява ефективна работа, а функцията за тройно търсене улеснява намирането на най-бързия път до зарядната станция.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/robotic-mowers/photos/studio/h310-2059.webp?v=1f5ec561e00e823d&format=WEBP_LANDSCAPE_CONTAIN_MD", false, 40, "305", 2460m, null, 600 });

            migrationBuilder.InsertData(
                table: "Automowers",
                columns: new[] { "Id", "Availability", "BoundaryType", "Description", "ImageUrl", "IsAvailable", "MaximumSlopePerformance", "Model", "Price", "UserId", "WorkingAreaCapacity" },
                values: new object[] { 2, 5, "Wire", "Когато се грижите за тревни площи с площ до 1500 m2, роботизираната косачка Husqvarna Automower® 315 Mark II върши работата вместо вас. Компактната конструкция с 4 колела означава, че тя може да се справя с наклони с 40% наклон и да се насочва през тесни проходи. Когато работата е свършена, функцията за тройно търсене намира най-бързия път обратно до зарядната станция.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/robotic-mowers/photos/studio/h310-2059.webp?v=1f5ec561e00e823d&format=WEBP_LANDSCAPE_CONTAIN_MD", false, 40, "315 Mark II", 3850m, null, 1500 });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Automowers_AutomowerId",
                table: "ShoppingCartItems",
                column: "AutomowerId",
                principalTable: "Automowers",
                principalColumn: "Id");
        }
    }
}
