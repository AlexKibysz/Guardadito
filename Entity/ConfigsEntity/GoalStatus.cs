using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;
public class GoalStatus : BaseEntity, IConfigurationEntity
{
   public string Name { get; set; }
}
