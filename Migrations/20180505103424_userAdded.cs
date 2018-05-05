using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class userAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardInfo",
                columns: table => new
                {
                    cardInfoID = table.Column<string>(nullable: false),
                    cardNumber = table.Column<string>(nullable: true),
                    cardholderName = table.Column<string>(nullable: true),
                    cvc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfo", x => x.cardInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cartID = table.Column<string>(nullable: false),
                    quantityInCart = table.Column<int>(nullable: false),
                    totalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cartID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfo",
                columns: table => new
                {
                    ShippingInfoID = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    zipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfo", x => x.ShippingInfoID);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    cartItemID = table.Column<string>(nullable: false),
                    bookQuantity = table.Column<int>(nullable: false),
                    cartID = table.Column<string>(nullable: true),
                    itemCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.cartItemID);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_cartID",
                        column: x => x.cartID,
                        principalTable: "Cart",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ShippingInfoID = table.Column<string>(nullable: true),
                    aspUserId = table.Column<string>(nullable: true),
                    cardInfoID = table.Column<string>(nullable: true),
                    favoriteBookId = table.Column<int>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userAccounts_ShippingInfo_ShippingInfoID",
                        column: x => x.ShippingInfoID,
                        principalTable: "ShippingInfo",
                        principalColumn: "ShippingInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userAccounts_CardInfo_cardInfoID",
                        column: x => x.cardInfoID,
                        principalTable: "CardInfo",
                        principalColumn: "cardInfoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userAccounts_books_favoriteBookId",
                        column: x => x.favoriteBookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderID = table.Column<string>(nullable: false),
                    UserAccountId = table.Column<string>(nullable: true),
                    itemsBoughtcartID = table.Column<string>(nullable: true),
                    orderShippingInfoShippingInfoID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_Order_userAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Cart_itemsBoughtcartID",
                        column: x => x.itemsBoughtcartID,
                        principalTable: "Cart",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_ShippingInfo_orderShippingInfoShippingInfoID",
                        column: x => x.orderShippingInfoShippingInfoID,
                        principalTable: "ShippingInfo",
                        principalColumn: "ShippingInfoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_UserAccountId",
                table: "books",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_cartID",
                table: "CartItem",
                column: "cartID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserAccountId",
                table: "Order",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_itemsBoughtcartID",
                table: "Order",
                column: "itemsBoughtcartID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderShippingInfoShippingInfoID",
                table: "Order",
                column: "orderShippingInfoShippingInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_ShippingInfoID",
                table: "userAccounts",
                column: "ShippingInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_cardInfoID",
                table: "userAccounts",
                column: "cardInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_favoriteBookId",
                table: "userAccounts",
                column: "favoriteBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_userAccounts_UserAccountId",
                table: "books",
                column: "UserAccountId",
                principalTable: "userAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_userAccounts_UserAccountId",
                table: "books");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "userAccounts");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ShippingInfo");

            migrationBuilder.DropTable(
                name: "CardInfo");

            migrationBuilder.DropIndex(
                name: "IX_books_UserAccountId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "books");
        }
    }
}
