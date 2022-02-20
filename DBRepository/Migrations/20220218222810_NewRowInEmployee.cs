using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBRepository.Migrations
{
    public partial class NewRowInEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SalaryPaid",
                table: "WorkEmployees",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "NumberPhone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryPaid",
                table: "WorkEmployees");

            migrationBuilder.DropColumn(
                name: "NumberPhone",
                table: "Employees");
        }
    }
}
