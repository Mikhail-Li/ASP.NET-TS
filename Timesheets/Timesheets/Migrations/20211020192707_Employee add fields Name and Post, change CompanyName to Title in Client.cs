using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class EmployeeaddfieldsNameandPostchangeCompanyNametoTitleinClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "clients",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "employees",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "clients",
                newName: "CompanyName");
        }
    }
}
