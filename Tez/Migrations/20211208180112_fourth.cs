using Microsoft.EntityFrameworkCore.Migrations;

namespace Tez.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "Duyurus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "Duyurus");
        }
    }
}
