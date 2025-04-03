namespace Brasileirao.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
