using System.ComponentModel.DataAnnotations;
using Guardadito.Entity.Enums;

namespace Guardadito.Entity;

public class Usuario : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }


    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string PasswordHash { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio")]
    public UserRole Rol { get; set; }

    // Relaciones
    public ICollection<Cuenta> Cuentas { get; set; }
    public ICollection<Transaccion> Transacciones { get; set; }
    public ICollection<Meta> Metas { get; set; }
    public ICollection<Presupuesto> Presupuestos { get; set; }

    public void SetAuditDates(bool isNew = false)
    {
        throw new NotImplementedException();
    }

}