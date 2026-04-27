namespace OrderManagement.Domain.Entities.Common
{
    public interface IBaseEntity<out TIdentity> : IEntity
    {
        TIdentity Id { get; }
    }
}
