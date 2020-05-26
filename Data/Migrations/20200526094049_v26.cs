using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding.Data.Migrations
{
    public partial class v26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegDate",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegDate",
                table: "Companies");
        }
    }
}
