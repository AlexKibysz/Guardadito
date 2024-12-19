using Guardadito.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Guardadito.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<ConfiguracionUsuario> ConfiguracionesUsuario { get; set; }
    public DbSet<Recordatorio> Recordatorios { get; set; }
    public DbSet<Estadistica> Estadisticas { get; set; }
    public DbSet<Meta> Metas { get; set; }
    public DbSet<Presupuesto> Presupuestos { get; set; }
    public DbSet<CategoriaPresupuesto> CategoriasPresupuesto { get; set; }
    public DbSet<EstadisticaDetalle> EstadisticasDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración Usuario
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Cuentas)
            .WithOne(c => c.Usuario)
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Transacciones)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Metas)
            .WithOne(m => m.Usuario)
            .HasForeignKey(m => m.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Presupuestos)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración Cuenta
        modelBuilder.Entity<Cuenta>()
            .HasOne(c => c.MonedaPrincipal)
            .WithMany(m => m.CuentasMonedaPrincipal)
            .HasForeignKey(c => c.MonedaPrincipalId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración Transacción
        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.MonedaOriginal)
            .WithMany(m => m.TransaccionesMonedaOriginal)
            .HasForeignKey(t => t.MonedaOriginalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.MonedaDestino)
            .WithMany(m => m.TransaccionesMonedaDestino)
            .HasForeignKey(t => t.MonedaDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Transacciones)
            .HasForeignKey(t => t.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.Cuenta)
            .WithMany(c => c.Transacciones)
            .HasForeignKey(t => t.CuentaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración Categoría
        modelBuilder.Entity<Categoria>()
            .HasOne(c => c.CategoriaPadre)
            .WithMany(c => c.SubCategorias)
            .HasForeignKey(c => c.CategoriaPadreId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración CategoriaPresupuesto
        modelBuilder.Entity<CategoriaPresupuesto>()
            .HasOne(cp => cp.Presupuesto)
            .WithMany(p => p.Categorias)
            .HasForeignKey(cp => cp.PresupuestoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración ConfiguracionUsuario
        modelBuilder.Entity<ConfiguracionUsuario>()
            .HasOne(cu => cu.Usuario)
            .WithMany()
            .HasForeignKey(cu => cu.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ConfiguracionUsuario>()
    .HasOne(cu => cu.MonedaPrincipal)
    .WithMany(m => m.ConfiguracionesUsuario)
    .HasForeignKey(cu => cu.MonedaPrincipalId)
    .OnDelete(DeleteBehavior.Restrict);

        // Configuración Estadística
        modelBuilder.Entity<Estadistica>()
            .HasOne(e => e.Usuario)
            .WithMany()
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EstadisticaDetalle>()
            .HasOne(ed => ed.Estadistica)
            .WithMany(e => e.Detalles)
            .HasForeignKey(ed => ed.EstadisticaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración Recordatorio
        modelBuilder.Entity<Recordatorio>()
            .HasOne(r => r.Usuario)
            .WithMany()
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración de precisión decimal
        modelBuilder.Entity<Categoria>()
            .Property(c => c.Presupuesto)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CategoriaPresupuesto>()
            .Property(cp => cp.MontoAsignado)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CategoriaPresupuesto>()
            .Property(cp => cp.MontoGastado)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Meta>()
            .Property(m => m.MontoActual)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Meta>()
            .Property(m => m.MontoObjetivo)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Presupuesto>()
            .Property(p => p.MontoTotal)
            .HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (IEntity)entry.Entity;
            entity.SetAuditDates(entry.State == EntityState.Added);
        }
    }
}
