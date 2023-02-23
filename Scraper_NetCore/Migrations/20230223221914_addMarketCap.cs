using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scraper_NetCore.Migrations
{
    /// <inheritdoc />
    public partial class addMarketCap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarketCap",
                table: "Companies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketCap",
                table: "Companies");
        }
    }
}
