using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardadito.Entity;

public class Transaccion : BaseEntity
{
    public new Guid Id { get; set; }
    public new DateTime CreatedAt { get; set; }
    public new DateTime UpdatedAt { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "La moneda original es obligatoria")]
    public Guid MonedaOriginalId { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal? MontoConvertido { get; set; }

    public Guid? MonedaDestinoId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria")]
    public Guid CategoriaId { get; set; }

    public List<string> Etiquetas { get; set; }

    public List<string> Adjuntos { get; set; }

    public bool Recurrente { get; set; }

    [StringLength(500)] public string Descripcion { get; set; }

    // Relaciones
    public Currency MonedaOriginal { get; set; }
    public Currency MonedaDestino { get; set; }
    public Categoria Categoria { get; set; }
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public Guid CuentaId { get; set; }
    public Cuenta Cuenta { get; set; }
}