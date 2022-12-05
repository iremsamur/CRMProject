using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.UpSchool.DataAccessLayer.Migrations
{
    public partial class mig_email_confirmed_control_column_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmedControl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmedControl",
                table: "AspNetUsers");
        }
    }
}
