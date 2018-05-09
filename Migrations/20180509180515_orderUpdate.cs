using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class orderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "totalCost",
                table: "orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "zipCode",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "city",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "country",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "totalCost",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "zipCode",
                table: "orders");
        }
    }
}
