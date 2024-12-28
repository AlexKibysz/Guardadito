using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardadito.Entity;

public class CategoriaPresupuesto : BaseEntity
{
    public new Guid Id { get; set; }
    public new DateTime CreatedAt { get; set; }
    public new DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El monto asignado es obligatorio")]
    [Column(TypeName = "decimal(18,6)")]
    [Range(typeof(decimal), "0.000001", "999999999999.999999", ErrorMessage = "La tasa de cambio debe estar entre 0.000001 y 999999999999.999999")]
    public decimal MontoAsignado { get; set; }

    [Required(ErrorMessage = "El monto gastado es obligatorio")]
    [Column(TypeName = "decimal(18,6)")]
    [Range(typeof(decimal), "0.000001", "999999999999.999999", ErrorMessage = "La tasa de cambio debe estar entre 0.000001 y 999999999999.999999")]
    public decimal MontoGastado { get; set; }

    // Relaciones
    public Guid PresupuestoId { get; set; }
    public Presupuesto Presupuesto { get; set; }
}