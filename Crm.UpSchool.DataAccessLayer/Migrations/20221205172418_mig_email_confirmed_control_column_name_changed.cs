using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.UpSchool.DataAccessLayer.Migrations
{
    public partial class mig_email_confirmed_control_column_name_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailConfirmedControl",
                table: "AspNetUsers",
                newName: "EmailConfirmedControlCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailConfirmedControlCode",
                table: "AspNetUsers",
                newName: "EmailConfirmedControl");
        }
    }
}
