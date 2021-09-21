using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLAPI.Migrations
{
    public partial class MySecondMigration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatdormId",
                table: "Commands");

            migrationBuilder.RenameColumn(
                name: "PlatdormId",
                table: "Commands",
                newName: "PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Commands_PlatdormId",
                table: "Commands",
                newName: "IX_Commands_PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Commands",
                newName: "PlatdormId");

            migrationBuilder.RenameIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands",
                newName: "IX_Commands_PlatdormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatdormId",
                table: "Commands",
                column: "PlatdormId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
