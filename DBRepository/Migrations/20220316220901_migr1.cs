using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlReader.Data.DBRepository.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AuthUsers_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BetForObject = table.Column<float>(type: "real", nullable: false),
                    CountFactObject = table.Column<int>(type: "int", nullable: false),
                    CountFactFiles = table.Column<int>(type: "int", nullable: false),
                    CountPlanFiles = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryPaid = table.Column<float>(type: "real", nullable: false),
                    IsGetSalary = table.Column<bool>(type: "bit", nullable: false),
                    IsEnd = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_WorkEmployees_WorkId",
                        column: x => x.WorkId,
                        principalTable: "WorkEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthUsers",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AuthUsers",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 2, "emp", "emp", "employee" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AuthUserId", "Email", "IsAdmin", "Name", "NumberPhone", "Vk" },
                values: new object[] { 1, 1, "i.tiulkina@mail.ru", true, "Ирина Т", "79527914962", "null" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AuthUserId", "Email", "IsAdmin", "Name", "NumberPhone", "Vk" },
                values: new object[] { 2, 2, "i.tiulkina@mail.ru", false, "Ирина Т", "79527914962", "null" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AuthUserId",
                table: "Employees",
                column: "AuthUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_WorkId",
                table: "Folders",
                column: "WorkId");

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

            migrationBuilder.DropTable(
                name: "AuthUsers");
        }
    }
}
