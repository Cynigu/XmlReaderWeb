using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBRepository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BetForObject = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountFactObject = table.Column<int>(type: "int", nullable: false),
                    CountFactFiles = table.Column<int>(type: "int", nullable: false),
                    CountPlanFiles = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsGetSalary = table.Column<bool>(type: "bit", nullable: false),
                    IsEnd = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathFolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountObject = table.Column<int>(type: "int", nullable: false),
                    CountXmlFiles = table.Column<int>(type: "int", nullable: false),
                    CountFiles = table.Column<int>(type: "int", nullable: false),
                    WorkEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_WorkEmployees_WorkEmployeeId",
                        column: x => x.WorkEmployeeId,
                        principalTable: "WorkEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_WorkEmployeeId",
                table: "Folders",
                column: "WorkEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEmployees_EmployeeId",
                table: "WorkEmployees",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "WorkEmployees");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
