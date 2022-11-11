using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.UpSchool.DataAccessLayer.Migrations
{
    public partial class mig_create_appuser_employeetask_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskAssigneeUserID = table.Column<int>(type: "int", nullable: false),
                    FollowerUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.EmployeeTaskID);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_AspNetUsers_FollowerUserID",
                        column: x => x.FollowerUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_AspNetUsers_TaskAssigneeUserID",
                        column: x => x.TaskAssigneeUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_FollowerUserID",
                table: "EmployeeTasks",
                column: "FollowerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TaskAssigneeUserID",
                table: "EmployeeTasks",
                column: "TaskAssigneeUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTasks");
        }
    }
}
