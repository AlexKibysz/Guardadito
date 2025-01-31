using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardadito.Entity;

public class Cuenta : BaseEntity
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public required string Nombre { get; set; }

    [Required(ErrorMessage = "El Id Cuenta es obligatorio")]
    public Guid TipoCuentaId { get; set; }

    public AccountType? TipoCuenta { get; set; }

    [Required(ErrorMessage = "El saldo actual es obligatorio")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "El saldo debe ser mayor o igual a 0")]
    public decimal SaldoActual { get; set; }

    [Required(ErrorMessage = "El saldo disponible es obligatorio")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "El saldo disponible debe ser mayor o igual a 0")]
    public decimal SaldoDisponible { get; set; }


    [Required(ErrorMessage = "La moneda principal es obligatoria")]
    public Guid MonedaPrincipalId { get; set; }
    public Currency? MonedaPrincipal { get; set; }

    public Guid UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }

    public ICollection<Transaccion>? Transacciones { get; set; }
}