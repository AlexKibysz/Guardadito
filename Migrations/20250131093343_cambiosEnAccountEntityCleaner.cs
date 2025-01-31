using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardadito.Migrations
{
    /// <inheritdoc />
    public partial class cambiosEnAccountEntityCleaner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaApertura",
                table: "Cuentas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaApertura",
                table: "Cuentas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
