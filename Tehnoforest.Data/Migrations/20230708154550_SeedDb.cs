using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chainsaws_AspNetUsers_UserId",
                table: "Chainsaws");

            migrationBuilder.DropForeignKey(
                name: "FK_GardenTractors_AspNetUsers_UserId",
                table: "GardenTractors");

            migrationBuilder.DropForeignKey(
                name: "FK_GrassTrimmers_AspNetUsers_UserId",
                table: "GrassTrimmers");

            migrationBuilder.DropForeignKey(
                name: "FK_LawnMowers_AspNetUsers_UserId",
                table: "LawnMowers");

            migrationBuilder.InsertData(
                table: "Chainsaws",
                columns: new[] { "Id", "Availability", "BarLength", "CylinderDisplacement", "Description", "ImageUrl", "Model", "Power", "Price", "UserId" },
                values: new object[] { 1, 5, 35, 38, "Лесен за ползване трион в хоби сегмента. Благодарение на достатъчния капацитет на рязане, трионът е подходящ за рязане на дърва за огрев, леко поваляне или подрязване. Има X-Torq® двигател за ниски емисии и Air Injection, който пази филтъра чист.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/chainsaws/photos/studio/h110-0522.webp?v=a56825c923296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", "120 Mark II", 2m, 455m, null });

            migrationBuilder.InsertData(
                table: "GardenTractors",
                columns: new[] { "Id", "Availability", "CuttingHeightMax", "CuttingHeightMin", "CuttingWidth", "CylinderDisplacement", "Description", "ImageUrl", "Model", "NetPower", "Price", "UserId" },
                values: new object[] { 1, 5, 102, 38, 97, 452, "TS 138L е удобен трактор, идеален за собственици на малки и средни градини. Той е ефективен трактор със странично изхвърляне, интелигентен дизайн и ергономичност. TS 138L разполага с мощен двигател Husqvarna Series с без-чок старт, лостово управляема хидростатична трансмисия и ергономично кормило.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/garden-tractors/photos/studio/h310-2250.webp?v=7a7813db23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", "TS 138L", 9m, 6399m, null });

            migrationBuilder.InsertData(
                table: "GrassTrimmers",
                columns: new[] { "Id", "Availability", "CuttingWidth", "Description", "ImageUrl", "Model", "Power", "Price", "UserId" },
                values: new object[] { 1, 5, 47, "Husqvarna 535RX е нова моторна коса в клас 35 куб. см., с отлична ергономия, предвидена за продължително и интензивно натоварване и с достатъчно мощност, за постигане на първокласни резултати.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/brushcutters/photos/studio/h210-0364.webp?v=e58eac2723296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", "535RX", 2m, 1115m, null });

            migrationBuilder.InsertData(
                table: "LawnMowers",
                columns: new[] { "Id", "Availability", "CuttingWidth", "Description", "DriveSystem", "ImageUrl", "Model", "Price", "UserId", "WorkingAreaCapacity" },
                values: new object[] { 1, 5, 47, "Мощна самоходна бензинова косачка за трева. Създаването на подредена и добре подстригана трева е истинско удоволствие с тази самоходна косачка със събиране на тревата. Husqvarna LC 247S е удобна за използване, задвижвана от двигател Husqvarna. Тя разполага и с лесна настройка на височината на рязане, интуитивни контроли и лесна сгъваема дръжка за удобна работа и съхранение.", "Самоход", "https://www-static-nw.husqvarna.com/-/images/aprimo/klippo/walk-behind-mowers/photos/studio/il-527596.webp?v=e7809c1a23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", "LC 247S", 1100m, null, 800 });

            migrationBuilder.AddForeignKey(
                name: "FK_Chainsaws_AspNetUsers_UserId",
                table: "Chainsaws",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GardenTractors_AspNetUsers_UserId",
                table: "GardenTractors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrassTrimmers_AspNetUsers_UserId",
                table: "GrassTrimmers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawnMowers_AspNetUsers_UserId",
                table: "LawnMowers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chainsaws_AspNetUsers_UserId",
                table: "Chainsaws");

            migrationBuilder.DropForeignKey(
                name: "FK_GardenTractors_AspNetUsers_UserId",
                table: "GardenTractors");

            migrationBuilder.DropForeignKey(
                name: "FK_GrassTrimmers_AspNetUsers_UserId",
                table: "GrassTrimmers");

            migrationBuilder.DropForeignKey(
                name: "FK_LawnMowers_AspNetUsers_UserId",
                table: "LawnMowers");

            migrationBuilder.DeleteData(
                table: "Chainsaws",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GardenTractors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GrassTrimmers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LawnMowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Chainsaws_AspNetUsers_UserId",
                table: "Chainsaws",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenTractors_AspNetUsers_UserId",
                table: "GardenTractors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrassTrimmers_AspNetUsers_UserId",
                table: "GrassTrimmers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LawnMowers_AspNetUsers_UserId",
                table: "LawnMowers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
