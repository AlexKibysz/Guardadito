using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;
public class ReminderStatus : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }
    /*
     Pendiente,
     Completado,
     Vencido,
     Cancelado
     */
}