namespace Guardadito.Entity;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void SetAuditDates(bool isNew = false)
    {
        // Siempre guardar en UTC
        var utcNow = DateTime.UtcNow;

        if (isNew)
            CreatedAt = utcNow;
        UpdatedAt = utcNow;
    }

    // Método helper para obtener fechas en zona horaria local
    public DateTime GetLocalCreatedAt()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(CreatedAt, TimeZoneInfo.Local);
    }

    public DateTime GetLocalUpdatedAt()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(UpdatedAt, TimeZoneInfo.Local);
    }
}