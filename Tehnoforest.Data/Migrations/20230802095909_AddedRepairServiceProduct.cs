using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class AddedRepairServiceProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairServiceProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BrandMachine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModelMachine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateOfAcceptance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReturning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairServiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairServiceProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairServiceProducts_UserId",
                table: "RepairServiceProducts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairServiceProducts");
        }
    }
}
