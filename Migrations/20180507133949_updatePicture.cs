using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class updatePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "picture",
                table: "userAccounts",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "picture",
                table: "userAccounts",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
