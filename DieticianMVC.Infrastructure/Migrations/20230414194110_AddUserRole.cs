using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DieticianMVC.Infrastructure.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Dieticianes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Dieticianes_UserId",
                table: "Dieticianes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dieticianes_AspNetUsers_UserId",
                table: "Dieticianes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dieticianes_AspNetUsers_UserId",
                table: "Dieticianes");

            migrationBuilder.DropIndex(
                name: "IX_Dieticianes_UserId",
                table: "Dieticianes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dieticianes");
        }
    }
}
