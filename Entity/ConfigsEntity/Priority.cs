using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;

public class Priority : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }
}