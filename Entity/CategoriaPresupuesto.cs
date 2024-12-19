using System.ComponentModel.DataAnnotations;

namespace Guardadito.Entity;

public class CategoriaPresupuesto : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El monto asignado es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto asignado debe ser mayor a 0")]
    public decimal MontoAsignado { get; set; }

    [Required(ErrorMessage = "El monto gastado es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El monto gastado debe ser mayor o igual a 0")]
    public decimal MontoGastado { get; set; }

    // Relaciones
    public Guid PresupuestoId { get; set; }
    public Presupuesto Presupuesto { get; set; }
}