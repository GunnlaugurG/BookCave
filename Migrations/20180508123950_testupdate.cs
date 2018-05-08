using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class testupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    bookForCartItem = table.Column<int>(nullable: false),
                    bookQuantity = table.Column<int>(nullable: false),
                    itemCost = table.Column<double>(nullable: false),
                    keyCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    cartForUserId = table.Column<string>(nullable: true),
                    quantityInCart = table.Column<int>(nullable: false),
                    totalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wishLists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    aspUserforWishList = table.Column<string>(nullable: true),
                    bookForWishListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "wishLists");
        }
    }
}
