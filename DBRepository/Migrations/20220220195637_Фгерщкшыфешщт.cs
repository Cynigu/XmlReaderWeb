using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBRepository.Migrations
{
    public partial class Фгерщкшыфешщт : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthUsers",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin", "qwerty123", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
