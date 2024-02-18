using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.API.Migrations
{
    public partial class AgregarFechaUsuarioModifico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModifico",
                table: "Recibos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioModificoId",
                table: "Recibos",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModifico",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "UsuarioModificoId",
                table: "Recibos");
        }
    }
}
