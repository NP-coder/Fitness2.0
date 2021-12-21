using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.Migrations
{
    public partial class AddOthersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId1",
                table: "Athleticss");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AspNetUsers_UserId1",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UserId1",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Athleticss_UserId1",
                table: "Athleticss");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Athleticss");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Athleticss",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserId",
                table: "Foods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Athleticss_UserId",
                table: "Athleticss",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_AspNetUsers_UserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Athleticss_UserId",
                table: "Athleticss");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Foods",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Athleticss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Athleticss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UserId1",
                table: "Foods",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Athleticss_UserId1",
                table: "Athleticss",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId1",
                table: "Athleticss",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_AspNetUsers_UserId1",
                table: "Foods",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
