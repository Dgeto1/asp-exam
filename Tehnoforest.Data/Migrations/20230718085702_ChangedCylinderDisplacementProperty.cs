using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class ChangedCylinderDisplacementProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CylinderDisplacement",
                table: "Chainsaws",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Chainsaws",
                keyColumn: "Id",
                keyValue: 1,
                column: "CylinderDisplacement",
                value: 38m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CylinderDisplacement",
                table: "Chainsaws",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Chainsaws",
                keyColumn: "Id",
                keyValue: 1,
                column: "CylinderDisplacement",
                value: 38);
        }
    }
}
