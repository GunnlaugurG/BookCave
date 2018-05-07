using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoId",
                table: "userAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_books_favoriteBookId",
                table: "userAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_userAccounts_ShippingInfo_shippingInfoId",
                table: "userAccounts");

            migrationBuilder.DropIndex(
                name: "IX_userAccounts_cardInfoId",
                table: "userAccounts");

            migrationBuilder.DropIndex(
                name: "IX_userAccounts_favoriteBookId",
                table: "userAccounts");

            migrationBuilder.DropIndex(
                name: "IX_userAccounts_shippingInfoId",
                table: "userAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardInfo",
                table: "CardInfo");

            migrationBuilder.DropColumn(
                name: "favoriteBookId",
                table: "userAccounts");

            migrationBuilder.RenameTable(
                name: "ShippingInfo",
                newName: "shipingInfo");

            migrationBuilder.RenameTable(
                name: "CardInfo",
                newName: "cardInfo");

            migrationBuilder.RenameColumn(
                name: "shippingInfoId",
                table: "userAccounts",
                newName: "shippingInfoForUserId");

            migrationBuilder.RenameColumn(
                name: "cardInfoId",
                table: "userAccounts",
                newName: "cardInfoForUserId");

            migrationBuilder.AlterColumn<string>(
                name: "shippingInfoForUserId",
                table: "userAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cardInfoForUserId",
                table: "userAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "favoriteBookForUserId",
                table: "userAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "authorDescription",
                table: "authors",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_shipingInfo",
                table: "shipingInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cardInfo",
                table: "cardInfo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_shipingInfo",
                table: "shipingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cardInfo",
                table: "cardInfo");

            migrationBuilder.DropColumn(
                name: "favoriteBookForUserId",
                table: "userAccounts");

            migrationBuilder.DropColumn(
                name: "authorDescription",
                table: "authors");

            migrationBuilder.RenameTable(
                name: "shipingInfo",
                newName: "ShippingInfo");

            migrationBuilder.RenameTable(
                name: "cardInfo",
                newName: "CardInfo");

            migrationBuilder.RenameColumn(
                name: "shippingInfoForUserId",
                table: "userAccounts",
                newName: "shippingInfoId");

            migrationBuilder.RenameColumn(
                name: "cardInfoForUserId",
                table: "userAccounts",
                newName: "cardInfoId");

            migrationBuilder.AlterColumn<string>(
                name: "shippingInfoId",
                table: "userAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cardInfoId",
                table: "userAccounts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "favoriteBookId",
                table: "userAccounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardInfo",
                table: "CardInfo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_cardInfoId",
                table: "userAccounts",
                column: "cardInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_favoriteBookId",
                table: "userAccounts",
                column: "favoriteBookId");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_shippingInfoId",
                table: "userAccounts",
                column: "shippingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_CardInfo_cardInfoId",
                table: "userAccounts",
                column: "cardInfoId",
                principalTable: "CardInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userAccounts_books_favoriteBookId",
                table: "userAccounts",
                column: "favoriteBookId",
                principalTable: "books",
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
    }
}
