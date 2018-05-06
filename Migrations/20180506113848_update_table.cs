using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class update_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_userAccounts_UserAccountId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_ShippingInfo_ShippingInfoID",
                table: "userAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoID",
                table: "userAccounts");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_books_UserAccountId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "cardInfoID",
                table: "userAccounts",
                newName: "cardInfoId");

            migrationBuilder.RenameColumn(
                name: "ShippingInfoID",
                table: "userAccounts",
                newName: "shippingInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_userAccounts_cardInfoID",
                table: "userAccounts",
                newName: "IX_userAccounts_cardInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_userAccounts_ShippingInfoID",
                table: "userAccounts",
                newName: "IX_userAccounts_shippingInfoId");

            migrationBuilder.RenameColumn(
                name: "ShippingInfoID",
                table: "ShippingInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "cardInfoID",
                table: "CardInfo",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoId",
                table: "userAccounts",
                column: "cardInfoId",
                principalTable: "CardInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_ShippingInfo_shippingInfoId",
                table: "userAccounts",
                column: "shippingInfoId",
                principalTable: "ShippingInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoId",
                table: "userAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_ShippingInfo_shippingInfoId",
                table: "userAccounts");

            migrationBuilder.RenameColumn(
                name: "shippingInfoId",
                table: "userAccounts",
                newName: "ShippingInfoID");

            migrationBuilder.RenameColumn(
                name: "cardInfoId",
                table: "userAccounts",
                newName: "cardInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_userAccounts_shippingInfoId",
                table: "userAccounts",
                newName: "IX_userAccounts_ShippingInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_userAccounts_cardInfoId",
                table: "userAccounts",
                newName: "IX_userAccounts_cardInfoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShippingInfo",
                newName: "ShippingInfoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CardInfo",
                newName: "cardInfoID");

            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "books",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_books_userAccounts_UserAccountId",
                table: "books",
                column: "UserAccountId",
                principalTable: "userAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_ShippingInfo_ShippingInfoID",
                table: "userAccounts",
                column: "ShippingInfoID",
                principalTable: "ShippingInfo",
                principalColumn: "ShippingInfoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoID",
                table: "userAccounts",
                column: "cardInfoID",
                principalTable: "CardInfo",
                principalColumn: "cardInfoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
