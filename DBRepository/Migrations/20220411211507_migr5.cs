using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlReader.Data.DBRepository.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AuthUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "AuthUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AuthUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AuthUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AuthUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 1);
        }
    }
}
