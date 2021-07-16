using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class ClientsHasForeignKeyUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "clients",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_UserId",
                table: "clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_users_UserId",
                table: "clients",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_users_UserId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_clients_UserId",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "clients",
                newName: "User");
        }
    }
}
