using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlReader.Data.DBRepository.Migrations
{
    public partial class addEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThisEmployeeId",
                table: "AuthUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_ThisEmployeeId",
                table: "AuthUsers",
                column: "ThisEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUsers_Employees_ThisEmployeeId",
                table: "AuthUsers",
                column: "ThisEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUsers_Employees_ThisEmployeeId",
                table: "AuthUsers");

            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_ThisEmployeeId",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "ThisEmployeeId",
                table: "AuthUsers");
        }
    }
}
