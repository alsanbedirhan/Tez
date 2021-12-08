using Microsoft.EntityFrameworkCore.Migrations;

namespace Tez.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "Duyurus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "Duyurus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
