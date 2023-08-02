using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class DeletedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automowers");

            migrationBuilder.DropTable(
                name: "Chainsaws");

            migrationBuilder.DropTable(
                name: "GardenTractors");

            migrationBuilder.DropTable(
                name: "GrassTrimmers");

            migrationBuilder.DropTable(
                name: "LawnMowers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    BoundaryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MaximumSlopePerformance = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingAreaCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automowers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chainsaws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    BarLength = table.Column<int>(type: "int", nullable: false),
                    CylinderDisplacement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Power = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chainsaws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chainsaws_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GardenTractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    CuttingHeightMax = table.Column<int>(type: "int", nullable: false),
                    CuttingHeightMin = table.Column<int>(type: "int", nullable: false),
                    CuttingWidth = table.Column<int>(type: "int", nullable: false),
                    CylinderDisplacement = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NetPower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenTractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardenTractors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrassTrimmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    CuttingWidth = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrassTrimmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrassTrimmers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LawnMowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    CuttingWidth = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DriveSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingAreaCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawnMowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawnMowers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Chainsaws",
                columns: new[] { "Id", "Availability", "BarLength", "CylinderDisplacement", "Description", "ImageUrl", "IsAvailable", "Model", "Power", "Price", "UserId" },
                values: new object[] { 1, 5, 35, 38m, "Лесен за ползване трион в хоби сегмента. Благодарение на достатъчния капацитет на рязане, трионът е подходящ за рязане на дърва за огрев, леко поваляне или подрязване. Има X-Torq® двигател за ниски емисии и Air Injection, който пази филтъра чист.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/chainsaws/photos/studio/h110-0522.webp?v=a56825c923296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", false, "120 Mark II", 2m, 455m, null });

            migrationBuilder.InsertData(
                table: "GardenTractors",
                columns: new[] { "Id", "Availability", "CuttingHeightMax", "CuttingHeightMin", "CuttingWidth", "CylinderDisplacement", "Description", "ImageUrl", "IsAvailable", "Model", "NetPower", "Price", "UserId" },
                values: new object[] { 1, 5, 102, 38, 97, 452, "TS 138L е удобен трактор, идеален за собственици на малки и средни градини. Той е ефективен трактор със странично изхвърляне, интелигентен дизайн и ергономичност. TS 138L разполага с мощен двигател Husqvarna Series с без-чок старт, лостово управляема хидростатична трансмисия и ергономично кормило.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/garden-tractors/photos/studio/h310-2250.webp?v=7a7813db23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", false, "TS 138L", 9m, 6399m, null });

            migrationBuilder.InsertData(
                table: "GrassTrimmers",
                columns: new[] { "Id", "Availability", "CuttingWidth", "Description", "ImageUrl", "IsAvailable", "Model", "Power", "Price", "UserId" },
                values: new object[] { 1, 5, 47, "Husqvarna 535RX е нова моторна коса в клас 35 куб. см., с отлична ергономия, предвидена за продължително и интензивно натоварване и с достатъчно мощност, за постигане на първокласни резултати.", "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/brushcutters/photos/studio/h210-0364.webp?v=e58eac2723296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", false, "535RX", 2m, 1115m, null });

            migrationBuilder.InsertData(
                table: "LawnMowers",
                columns: new[] { "Id", "Availability", "CuttingWidth", "Description", "DriveSystem", "ImageUrl", "IsAvailable", "Model", "Price", "UserId", "WorkingAreaCapacity" },
                values: new object[] { 1, 5, 47, "Мощна самоходна бензинова косачка за трева. Създаването на подредена и добре подстригана трева е истинско удоволствие с тази самоходна косачка със събиране на тревата. Husqvarna LC 247S е удобна за използване, задвижвана от двигател Husqvarna. Тя разполага и с лесна настройка на височината на рязане, интуитивни контроли и лесна сгъваема дръжка за удобна работа и съхранение.", "Самоход", "https://www-static-nw.husqvarna.com/-/images/aprimo/klippo/walk-behind-mowers/photos/studio/il-527596.webp?v=e7809c1a23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL", false, "LC 247S", 1100m, null, 800 });

            migrationBuilder.CreateIndex(
                name: "IX_Automowers_UserId",
                table: "Automowers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chainsaws_UserId",
                table: "Chainsaws",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenTractors_UserId",
                table: "GardenTractors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GrassTrimmers_UserId",
                table: "GrassTrimmers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LawnMowers_UserId",
                table: "LawnMowers",
                column: "UserId");
        }
    }
}
