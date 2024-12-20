using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;

public class AccountType : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }
}