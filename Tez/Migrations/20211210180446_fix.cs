using Microsoft.EntityFrameworkCore.Migrations;

namespace Tez.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostType_PostTypeID",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostType",
                table: "PostType");

            migrationBuilder.RenameTable(
                name: "PostType",
                newName: "PostTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTypes",
                table: "PostTypes",
                column: "PostTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostTypes_PostTypeID",
                table: "Posts",
                column: "PostTypeID",
                principalTable: "PostTypes",
                principalColumn: "PostTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostTypes_PostTypeID",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTypes",
                table: "PostTypes");

            migrationBuilder.RenameTable(
                name: "PostTypes",
                newName: "PostType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostType",
                table: "PostType",
                column: "PostTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostType_PostTypeID",
                table: "Posts",
                column: "PostTypeID",
                principalTable: "PostType",
                principalColumn: "PostTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
