using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class newTablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aspUserIdForShipping",
                table: "shipingInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aspUserIdForCardInfo",
                table: "cardInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aspUserIdForShipping",
                table: "shipingInfo");

            migrationBuilder.DropColumn(
                name: "aspUserIdForCardInfo",
                table: "cardInfo");
        }
    }
}
