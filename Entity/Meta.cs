using System.ComponentModel.DataAnnotations;
using Guardadito.Entity.Enums;

namespace Guardadito.Entity;

public class Meta : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El monto objetivo es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto objetivo debe ser mayor a 0")]
    public decimal MontoObjetivo { get; set; }

    [Required(ErrorMessage = "El monto actual es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El monto actual debe ser mayor o igual a 0")]
    public decimal MontoActual { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "La fecha límite es obligatoria")]
    public DateTime FechaLimite { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio")]
    public GoalStatus Estado { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}