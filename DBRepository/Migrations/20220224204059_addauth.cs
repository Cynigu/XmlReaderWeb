using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlReader.Data.DBRepository.Migrations
{
    public partial class addauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthUserId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AuthUserId",
                table: "Employees",
                column: "AuthUserId",
                unique: true,
                filter: "[AuthUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AuthUsers_AuthUserId",
                table: "Employees",
                column: "AuthUserId",
                principalTable: "AuthUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AuthUsers_AuthUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AuthUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AuthUserId",
                table: "Employees");
        }
    }
}
