using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Data.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeScr",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeSrc",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeSrc",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeScr",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
