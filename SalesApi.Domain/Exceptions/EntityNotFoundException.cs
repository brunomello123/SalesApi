namespace SalesApi.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message)
    {
    }

    public EntityNotFoundException(string entityName, object key) 
        : base($"Entity '{entityName}' with key '{key}' not found.")
    {
    }
}