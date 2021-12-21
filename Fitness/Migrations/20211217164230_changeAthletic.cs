using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.Migrations
{
    public partial class changeAthletic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Athleticss",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Athleticss",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Athleticss_AspNetUsers_UserId",
                table: "Athleticss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
