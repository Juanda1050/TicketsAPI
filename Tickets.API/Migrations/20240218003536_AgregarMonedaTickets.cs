using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.API.Migrations
{
    public partial class AgregarMonedaTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("d6529dfb-ab23-4153-9329-8d088fedb403"));

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Recibos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "Recibos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "Recibos");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Recibos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contraseña", "FechaCreo", "Nombre" },
                values: new object[] { new Guid("d6529dfb-ab23-4153-9329-8d088fedb403"), "12345678", new DateTime(2024, 2, 15, 22, 16, 56, 418, DateTimeKind.Local).AddTicks(4751), "admin" });
        }
    }
}
