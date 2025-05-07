namespace SalesApi.Domain.Abstractions;

public abstract class BasicEntity
{
    public Guid Id { get; private set; }
    
    protected BasicEntity(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));

        Id = id;
    }
    protected BasicEntity (){}
}