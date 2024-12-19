using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guardadito.Entity;

public class EstadisticaDetalle : BaseEntity
{
   public Guid Id { get; set; }
   public DateTime CreatedAt { get; set; }
   public DateTime UpdatedAt { get; set; }

   [Required]
   public string Clave { get; set; }

   [Required]
   [Column(TypeName = "decimal(18,2)")]
   public decimal Valor { get; set; }

   // Relaciones
   public Guid EstadisticaId { get; set; }
   public Estadistica Estadistica { get; set; }
}