using System.ComponentModel.DataAnnotations;
using Guardadito.Entity.Enums;

namespace Guardadito.Entity;

public class Recordatorio : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
    public DateTime FechaVencimiento { get; set; }

    [Required(ErrorMessage = "El tipo de recordatorio es obligatorio")]
    public ReminderType TipoRecordatorio { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio")]
    public ReminderStatus Estado { get; set; }

    [Required(ErrorMessage = "La prioridad es obligatoria")]
    public Priority Prioridad { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}