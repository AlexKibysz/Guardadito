using System.ComponentModel.DataAnnotations;

namespace Guardadito.Entity;

public class Presupuesto : BaseEntity
{
    public new Guid Id { get; set; }
    public new DateTime CreatedAt { get; set; }
    public new DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El monto total es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor a 0")]
    public decimal MontoTotal { get; set; }


    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "La fecha de fin es obligatoria")]
    public DateTime FechaFin { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public ICollection<CategoriaPresupuesto> Categorias { get; set; }
}