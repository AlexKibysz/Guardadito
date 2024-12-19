using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardadito.Entity;

public class Currency : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    [Required(ErrorMessage = "El código de la moneda es obligatorio")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe tener exactamente 3 caracteres")]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "El código debe contener solo letras mayúsculas")]
    public string Code { get; set; }

    [Required(ErrorMessage = "El nombre de la moneda es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El símbolo es obligatorio")]
    [StringLength(10, ErrorMessage = "El símbolo no puede exceder los 10 caracteres")]
    public string Symbol { get; set; }

    [Required(ErrorMessage = "La tasa de cambio es obligatoria")]
    [Column(TypeName = "decimal(18,6)")]
    [Range(0.000001, 999999.999999, ErrorMessage = "La tasa de cambio debe estar entre 0.000001 y 999999.999999")]
    public decimal ExchangeRate { get; set; }

    [Required]
    public DateOnly RateDate { get; set; }

    public bool IsActive { get; set; } = true;

    // Relaciones
    public ICollection<Cuenta> CuentasMonedaPrincipal { get; set; }
    public ICollection<Transaccion> TransaccionesMonedaOriginal { get; set; }
    public ICollection<Transaccion> TransaccionesMonedaDestino { get; set; }
    public ICollection<ConfiguracionUsuario> ConfiguracionesUsuario { get; set; }

    public void SetAuditDates(bool isNew = false)
    {
        if (isNew)
            CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}