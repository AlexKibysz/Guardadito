#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Guardadito.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Categorias",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                TipoCategoria = table.Column<int>("int", nullable: false),
                CategoriaPadreId = table.Column<Guid>("uniqueidentifier", nullable: true),
                Icono = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                Color = table.Column<string>("nvarchar(7)", maxLength: 7, nullable: false),
                Presupuesto = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categorias", x => x.Id);
                table.ForeignKey(
                    "FK_Categorias_Categorias_CategoriaPadreId",
                    x => x.CategoriaPadreId,
                    "Categorias",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Currencies",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Code = table.Column<string>("nvarchar(3)", maxLength: 3, nullable: false),
                Name = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Symbol = table.Column<string>("nvarchar(10)", maxLength: 10, nullable: false),
                ExchangeRate = table.Column<decimal>("decimal(18,6)", nullable: false),
                RateDate = table.Column<DateOnly>("date", nullable: false),
                IsActive = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Currencies", x => x.Id); });

        migrationBuilder.CreateTable(
            "Usuarios",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>("nvarchar(max)", nullable: false),
                PasswordHash = table.Column<string>("nvarchar(max)", nullable: false),
                Rol = table.Column<int>("int", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Usuarios", x => x.Id); });

        migrationBuilder.CreateTable(
            "ConfiguracionesUsuario",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                MonedaPrincipalId = table.Column<Guid>("uniqueidentifier", nullable: false),
                FormatoFecha = table.Column<string>("nvarchar(20)", maxLength: 20, nullable: false),
                NotificacionesActivas = table.Column<bool>("bit", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ConfiguracionesUsuario", x => x.Id);
                table.ForeignKey(
                    "FK_ConfiguracionesUsuario_Currencies_MonedaPrincipalId",
                    x => x.MonedaPrincipalId,
                    "Currencies",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_ConfiguracionesUsuario_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Cuentas",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                TipoCuenta = table.Column<int>("int", nullable: false),
                SaldoActual = table.Column<decimal>("decimal(18,2)", nullable: false),
                SaldoDisponible = table.Column<decimal>("decimal(18,2)", nullable: false),
                MonedaPrincipalId = table.Column<Guid>("uniqueidentifier", nullable: false),
                LimiteCredito = table.Column<decimal>("decimal(18,2)", nullable: true),
                FechaCorte = table.Column<DateTime>("datetime2", nullable: true),
                FechaPago = table.Column<DateTime>("datetime2", nullable: true),
                FechaApertura = table.Column<DateTime>("datetime2", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cuentas", x => x.Id);
                table.ForeignKey(
                    "FK_Cuentas_Currencies_MonedaPrincipalId",
                    x => x.MonedaPrincipalId,
                    "Currencies",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_Cuentas_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Estadisticas",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                TipoEstadistica = table.Column<int>("int", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Estadisticas", x => x.Id);
                table.ForeignKey(
                    "FK_Estadisticas_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Metas",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                MontoObjetivo = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                MontoActual = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                FechaInicio = table.Column<DateTime>("datetime2", nullable: false),
                FechaLimite = table.Column<DateTime>("datetime2", nullable: false),
                Estado = table.Column<int>("int", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Metas", x => x.Id);
                table.ForeignKey(
                    "FK_Metas_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Presupuestos",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                MontoTotal = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                FechaInicio = table.Column<DateTime>("datetime2", nullable: false),
                FechaFin = table.Column<DateTime>("datetime2", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Presupuestos", x => x.Id);
                table.ForeignKey(
                    "FK_Presupuestos_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Recordatorios",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Titulo = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                FechaVencimiento = table.Column<DateTime>("datetime2", nullable: false),
                TipoRecordatorio = table.Column<int>("int", nullable: false),
                Estado = table.Column<int>("int", nullable: false),
                Prioridad = table.Column<int>("int", nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Recordatorios", x => x.Id);
                table.ForeignKey(
                    "FK_Recordatorios_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "Transacciones",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Monto = table.Column<decimal>("decimal(18,2)", nullable: false),
                MonedaOriginalId = table.Column<Guid>("uniqueidentifier", nullable: false),
                MontoConvertido = table.Column<decimal>("decimal(18,2)", nullable: true),
                MonedaDestinoId = table.Column<Guid>("uniqueidentifier", nullable: true),
                Fecha = table.Column<DateTime>("datetime2", nullable: false),
                CategoriaId = table.Column<Guid>("uniqueidentifier", nullable: false),
                Etiquetas = table.Column<string>("nvarchar(max)", nullable: false),
                Adjuntos = table.Column<string>("nvarchar(max)", nullable: false),
                Recurrente = table.Column<bool>("bit", nullable: false),
                Descripcion = table.Column<string>("nvarchar(500)", maxLength: 500, nullable: false),
                UsuarioId = table.Column<Guid>("uniqueidentifier", nullable: false),
                CuentaId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transacciones", x => x.Id);
                table.ForeignKey(
                    "FK_Transacciones_Categorias_CategoriaId",
                    x => x.CategoriaId,
                    "Categorias",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_Transacciones_Cuentas_CuentaId",
                    x => x.CuentaId,
                    "Cuentas",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_Transacciones_Currencies_MonedaDestinoId",
                    x => x.MonedaDestinoId,
                    "Currencies",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_Transacciones_Currencies_MonedaOriginalId",
                    x => x.MonedaOriginalId,
                    "Currencies",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    "FK_Transacciones_Usuarios_UsuarioId",
                    x => x.UsuarioId,
                    "Usuarios",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "EstadisticasDetalle",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Clave = table.Column<string>("nvarchar(max)", nullable: false),
                Valor = table.Column<decimal>("decimal(18,2)", nullable: false),
                EstadisticaId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadisticasDetalle", x => x.Id);
                table.ForeignKey(
                    "FK_EstadisticasDetalle_Estadisticas_EstadisticaId",
                    x => x.EstadisticaId,
                    "Estadisticas",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "CategoriasPresupuesto",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedAt = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>("datetime2", nullable: false),
                Nombre = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false),
                MontoAsignado = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                MontoGastado = table.Column<decimal>("decimal(18,2)", precision: 18, scale: 2, nullable: false),
                PresupuestoId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CategoriasPresupuesto", x => x.Id);
                table.ForeignKey(
                    "FK_CategoriasPresupuesto_Presupuestos_PresupuestoId",
                    x => x.PresupuestoId,
                    "Presupuestos",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            "IX_Categorias_CategoriaPadreId",
            "Categorias",
            "CategoriaPadreId");

        migrationBuilder.CreateIndex(
            "IX_CategoriasPresupuesto_PresupuestoId",
            "CategoriasPresupuesto",
            "PresupuestoId");

        migrationBuilder.CreateIndex(
            "IX_ConfiguracionesUsuario_MonedaPrincipalId",
            "ConfiguracionesUsuario",
            "MonedaPrincipalId");

        migrationBuilder.CreateIndex(
            "IX_ConfiguracionesUsuario_UsuarioId",
            "ConfiguracionesUsuario",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_Cuentas_MonedaPrincipalId",
            "Cuentas",
            "MonedaPrincipalId");

        migrationBuilder.CreateIndex(
            "IX_Cuentas_UsuarioId",
            "Cuentas",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_Estadisticas_UsuarioId",
            "Estadisticas",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_EstadisticasDetalle_EstadisticaId",
            "EstadisticasDetalle",
            "EstadisticaId");

        migrationBuilder.CreateIndex(
            "IX_Metas_UsuarioId",
            "Metas",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_Presupuestos_UsuarioId",
            "Presupuestos",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_Recordatorios_UsuarioId",
            "Recordatorios",
            "UsuarioId");

        migrationBuilder.CreateIndex(
            "IX_Transacciones_CategoriaId",
            "Transacciones",
            "CategoriaId");

        migrationBuilder.CreateIndex(
            "IX_Transacciones_CuentaId",
            "Transacciones",
            "CuentaId");

        migrationBuilder.CreateIndex(
            "IX_Transacciones_MonedaDestinoId",
            "Transacciones",
            "MonedaDestinoId");

        migrationBuilder.CreateIndex(
            "IX_Transacciones_MonedaOriginalId",
            "Transacciones",
            "MonedaOriginalId");

        migrationBuilder.CreateIndex(
            "IX_Transacciones_UsuarioId",
            "Transacciones",
            "UsuarioId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "CategoriasPresupuesto");

        migrationBuilder.DropTable(
            "ConfiguracionesUsuario");

        migrationBuilder.DropTable(
            "EstadisticasDetalle");

        migrationBuilder.DropTable(
            "Metas");

        migrationBuilder.DropTable(
            "Recordatorios");

        migrationBuilder.DropTable(
            "Transacciones");

        migrationBuilder.DropTable(
            "Presupuestos");

        migrationBuilder.DropTable(
            "Estadisticas");

        migrationBuilder.DropTable(
            "Categorias");

        migrationBuilder.DropTable(
            "Cuentas");

        migrationBuilder.DropTable(
            "Currencies");

        migrationBuilder.DropTable(
            "Usuarios");
    }
}