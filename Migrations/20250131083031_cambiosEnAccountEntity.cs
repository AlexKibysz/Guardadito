using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardadito.Migrations
{
    /// <inheritdoc />
    public partial class cambiosEnAccountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCorte",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "LimiteCredito",
                table: "Cuentas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCorte",
                table: "Cuentas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Cuentas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LimiteCredito",
                table: "Cuentas",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
