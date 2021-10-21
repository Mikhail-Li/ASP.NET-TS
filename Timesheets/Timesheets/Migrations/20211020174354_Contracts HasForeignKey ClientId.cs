using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class ContractsHasForeignKeyClientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contracts_ClientId",
                table: "contracts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_clients_ClientId",
                table: "contracts",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_clients_ClientId",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "IX_contracts_ClientId",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "contracts");
        }
    }
}
