using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;

public class TransactionCategory : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }

    /*
     Alimentacion,
     Transporte,
     Vivienda,
     Entretenimiento,
     Servicios,
     Educacion,
     Salud*/
}