using Guardadito.Entity.Contracts;


namespace Guardadito.Entity;

public class CategoryType : BaseEntity, IConfigurationEntity
{
   public string Name { get; set; }
}