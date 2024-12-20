using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardadito.Migrations
{
    /// <inheritdoc />
    public partial class addconfigpages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Prioridad",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "TipoRecordatorio",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "TipoEstadistica",
                table: "Estadisticas");

            migrationBuilder.DropColumn(
                name: "TipoCuenta",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "TipoCategoria",
                table: "Categorias");

            migrationBuilder.AddColumn<Guid>(
                name: "RolId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Recordatorios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PrioridadId",
                table: "Recordatorios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipoRecordatorioId",
                table: "Recordatorios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EstadoId",
                table: "Metas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipoEstadisticaId",
                table: "Estadisticas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipoCuentaId",
                table: "Cuentas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TipoCategoriaId",
                table: "Categorias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorios_EstadoId",
                table: "Recordatorios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorios_PrioridadId",
                table: "Recordatorios",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordatorios_TipoRecordatorioId",
                table: "Recordatorios",
                column: "TipoRecordatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_EstadoId",
                table: "Metas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estadisticas_TipoEstadisticaId",
                table: "Estadisticas",
                column: "TipoEstadisticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_TipoCuentaId",
                table: "Cuentas",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_TipoCategoriaId",
                table: "Categorias",
                column: "TipoCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias",
                column: "TipoCategoriaId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_AccountType_TipoCuentaId",
                table: "Cuentas",
                column: "TipoCuentaId",
                principalTable: "AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estadisticas_StatType_TipoEstadisticaId",
                table: "Estadisticas",
                column: "TipoEstadisticaId",
                principalTable: "StatType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_GoalStatus_EstadoId",
                table: "Metas",
                column: "EstadoId",
                principalTable: "GoalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_Priority_PrioridadId",
                table: "Recordatorios",
                column: "PrioridadId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_ReminderStatus_EstadoId",
                table: "Recordatorios",
                column: "EstadoId",
                principalTable: "ReminderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordatorios_ReminderType_TipoRecordatorioId",
                table: "Recordatorios",
                column: "TipoRecordatorioId",
                principalTable: "ReminderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_AccountType_TipoCuentaId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Estadisticas_StatType_TipoEstadisticaId",
                table: "Estadisticas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_GoalStatus_EstadoId",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_Priority_PrioridadId",
                table: "Recordatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_ReminderStatus_EstadoId",
                table: "Recordatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Recordatorios_ReminderType_TipoRecordatorioId",
                table: "Recordatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropTable(
                name: "GoalStatus");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "ReminderStatus");

            migrationBuilder.DropTable(
                name: "ReminderType");

            migrationBuilder.DropTable(
                name: "StatType");

            migrationBuilder.DropTable(
                name: "TransactionCategory");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Recordatorios_EstadoId",
                table: "Recordatorios");

            migrationBuilder.DropIndex(
                name: "IX_Recordatorios_PrioridadId",
                table: "Recordatorios");

            migrationBuilder.DropIndex(
                name: "IX_Recordatorios_TipoRecordatorioId",
                table: "Recordatorios");

            migrationBuilder.DropIndex(
                name: "IX_Metas_EstadoId",
                table: "Metas");

            migrationBuilder.DropIndex(
                name: "IX_Estadisticas_TipoEstadisticaId",
                table: "Estadisticas");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_TipoCuentaId",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_TipoCategoriaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "PrioridadId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "TipoRecordatorioId",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "TipoEstadisticaId",
                table: "Estadisticas");

            migrationBuilder.DropColumn(
                name: "TipoCuentaId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "TipoCategoriaId",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Recordatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Prioridad",
                table: "Recordatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoRecordatorio",
                table: "Recordatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoEstadistica",
                table: "Estadisticas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCuenta",
                table: "Cuentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCategoria",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
