using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;
public class ReminderType : BaseEntity, IConfigurationEntity
{
   public string Name { get; set; }

   /*
   PagoFactura,
   MetaAhorro,
   LimitePrespuesto,
   VencimientoTarjeta
   */
}