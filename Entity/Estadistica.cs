using System.ComponentModel.DataAnnotations;
using Guardadito.Entity.Enums;

namespace Guardadito.Entity;

public class Estadistica : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public StatType TipoEstadistica { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public ICollection<EstadisticaDetalle> Detalles { get; set; }
}