using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tehnoforest.Data.Migrations
{
    public partial class AddShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCartItems");
        }
    }
}
