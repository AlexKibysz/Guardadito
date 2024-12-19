namespace Guardadito.Entity;

public interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
    void SetAuditDates(bool isNew = false);
}