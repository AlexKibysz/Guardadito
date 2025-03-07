using System.ComponentModel.DataAnnotations;

namespace Guardadito.Entity;

public class Categoria : BaseEntity
{
    public Categoria()
    {
        SubCategorias = new List<Categoria>();
        Transacciones = new List<Transaccion>();
    }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; }

    // Propiedades de Navegacion de Composite

    public Guid? CategoriaPadreId { get; set; }

    public virtual Categoria? CategoriaPadre { get; set; }
    public virtual ICollection<Categoria>? SubCategorias { get; set; }

    [Required(ErrorMessage = "El ícono es obligatorio")]
    [StringLength(50, ErrorMessage = "El ícono no puede exceder los 50 caracteres")]
    public string Icono { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    [StringLength(7, ErrorMessage = "El color debe estar en formato hexadecimal (#RRGGBB)")]
    [RegularExpression(@"^#[0-9A-Fa-f]{6}$", ErrorMessage = "El color debe estar en formato hexadecimal válido")]
    public string Color { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser mayor o igual a 0")]
    public decimal Presupuesto { get; set; }

    [Required(ErrorMessage = "El tipo de categoría es obligatorio")]
    public Guid TipoCategoriaId { get; set; }

    public virtual CategoryType? TipoCategoria { get; set; }

    public ICollection<Transaccion>? Transacciones { get; set; }

    // metodos de Composite
    public void AddSubcategoria(Categoria subcategoria)
    {
        subcategoria.CategoriaPadreId = Id;
        SubCategorias.Add(subcategoria);
    }

    public void RemoveSubcategoria(Categoria subcategoria)
    {
        SubCategorias.Remove(subcategoria);
    }

    public bool IsLeaf()
    {
        return !SubCategorias.Any();
    }
}