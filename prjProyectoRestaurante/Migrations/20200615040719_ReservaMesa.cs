using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace prjProyectoRestaurante.Migrations
{
    public partial class ReservaMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraReserva",
                table: "ReservaMesa",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HoraReserva",
                table: "ReservaMesa",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
