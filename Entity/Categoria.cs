using System.ComponentModel.DataAnnotations;
using Guardadito.Entity;

namespace Guardadito.Entity;

public class Categoria : BaseEntity
{
   [Required(ErrorMessage = "El nombre es obligatorio")]
   [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
   public string Nombre { get; set; }

   [Required(ErrorMessage = "El tipo de categoría es obligatorio")]
   public CategoryType TipoCategoria { get; set; }

   public Guid? CategoriaPadreId { get; set; }

   [Required(ErrorMessage = "El ícono es obligatorio")]
   [StringLength(50, ErrorMessage = "El ícono no puede exceder los 50 caracteres")]
   public string Icono { get; set; }

   [Required(ErrorMessage = "El color es obligatorio")]
   [StringLength(7, ErrorMessage = "El color debe estar en formato hexadecimal (#RRGGBB)")]
   [RegularExpression(@"^#[0-9A-Fa-f]{6}$", ErrorMessage = "El color debe estar en formato hexadecimal válido")]
   public string Color { get; set; }

   [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser mayor o igual a 0")]
   public decimal Presupuesto { get; set; }

   // Relaciones
   public Categoria CategoriaPadre { get; set; }
   public ICollection<Categoria> SubCategorias { get; set; }
   public ICollection<Transaccion> Transacciones { get; set; }
}