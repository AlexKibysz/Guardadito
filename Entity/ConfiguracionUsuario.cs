using System.ComponentModel.DataAnnotations;

namespace Guardadito.Entity;

public class ConfiguracionUsuario : BaseEntity
{
    public new Guid Id { get; set; }
    public new DateTime CreatedAt { get; set; }
    public new DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "La moneda principal es obligatoria")]
    public Guid MonedaPrincipalId { get; set; }

    [Required(ErrorMessage = "La moneda principal es obligatoria")]
    public Currency MonedaPrincipal { get; set; }

    [Required(ErrorMessage = "El formato de fecha es obligatorio")]
    [StringLength(20, ErrorMessage = "El formato de fecha no puede exceder los 20 caracteres")]
    public string FormatoFecha { get; set; }

    [Required(ErrorMessage = "El estado de notificaciones es obligatorio")]
    public bool NotificacionesActivas { get; set; }

    // Relaciones
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}