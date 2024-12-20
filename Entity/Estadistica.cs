namespace Guardadito.Entity;

public class Estadistica : BaseEntity
{
    public new Guid Id { get; set; }

    public new DateTime CreatedAt { get; set; }

    public new DateTime UpdatedAt { get; set; }

    public StatType TipoEstadistica { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }

    public Usuario Usuario { get; set; }

    public ICollection<EstadisticaDetalle> Detalles { get; set; }
}