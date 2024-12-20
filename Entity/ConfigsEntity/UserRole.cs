using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;

public class UserRole : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }

    /*
     Administrador,
     Usuario,
     Invitado
     */
}