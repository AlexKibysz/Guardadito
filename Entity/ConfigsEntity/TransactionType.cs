using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;

public class TransactionType : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }
    /*
    Ingreso,
        Gasto,
        Transferencia*/
}