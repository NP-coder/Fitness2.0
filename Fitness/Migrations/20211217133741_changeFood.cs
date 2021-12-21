﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.Migrations
{
    public partial class changeFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
