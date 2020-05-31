using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Data.Migrations
{
    public partial class v30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoteResult",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteResult",
                table: "Comments");
        }
    }
}
