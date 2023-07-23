using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class AddedProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingAreaCapacity = table.Column<int>(type: "int", nullable: true),
                    MaximumSlopePerformance = table.Column<int>(type: "int", nullable: true),
                    BoundaryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CylinderDisplacement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BarLength = table.Column<int>(type: "int", nullable: true),
                    NetPower = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CuttingWidth = table.Column<int>(type: "int", nullable: true),
                    CuttingHeightMax = table.Column<int>(type: "int", nullable: true),
                    CuttingHeightMin = table.Column<int>(type: "int", nullable: true),
                    DriveSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
