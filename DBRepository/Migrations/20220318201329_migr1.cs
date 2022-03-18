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
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AuthUsers_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    ProjectRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => new { x.Id, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_Workspaces_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WorkspaceId = table.Column<int>(type: "int", nullable: false),
                    WorkspaceEntityId = table.Column<int>(type: "int", nullable: false),
                    WorkspaceEntityUserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Workspaces_WorkspaceEntityId_WorkspaceEntityUserProfileId",
                        columns: x => new { x.WorkspaceEntityId, x.WorkspaceEntityUserProfileId },
                        principalTable: "Workspaces",
                        principalColumns: new[] { "Id", "UserProfileId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathFolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountFactObject = table.Column<int>(type: "int", nullable: false),
                    CountFactFiles = table.Column<int>(type: "int", nullable: false),
                    CountPlanFiles = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folders_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AuthUsers",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin", "admin", 0 });

            migrationBuilder.InsertData(
                table: "AuthUsers",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 2, "user", "user", 1 });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AuthUserId", "Email", "Name", "NumberPhone", "Vk" },
                values: new object[] { 1, 1, "i.tiulkina@mail.ru", "Ирина Т", "79527914962", "null" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AuthUserId", "Email", "Name", "NumberPhone", "Vk" },
                values: new object[] { 2, 2, "i.tiulkina@mail.ru", "Ирина Т", "79527914962", "null" });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ProjectId",
                table: "Folders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserProfileId",
                table: "Folders",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_WorkspaceEntityId_WorkspaceEntityUserProfileId",
                table: "Projects",
                columns: new[] { "WorkspaceEntityId", "WorkspaceEntityUserProfileId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AuthUserId",
                table: "UserProfiles",
                column: "AuthUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_UserProfileId",
                table: "Workspaces",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AuthUsers");
        }
    }
}
