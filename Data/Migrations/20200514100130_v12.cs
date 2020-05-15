using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Data.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
