using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class AddIsAvailableColumnForSoftDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "LawnMowers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "GrassTrimmers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "GardenTractors",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Chainsaws",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Automowers",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "LawnMowers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "GrassTrimmers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "GardenTractors");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Chainsaws");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Automowers");
        }
    }
}
