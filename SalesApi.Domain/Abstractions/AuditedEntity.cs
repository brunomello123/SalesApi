namespace SalesApi.Domain.Abstractions;

public class AuditedEntity : BasicEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastMotificationTime { get; set; }

    protected AuditedEntity()
    {
        
    }
    protected AuditedEntity(Guid id)
        : base(id)
    {
    }
}