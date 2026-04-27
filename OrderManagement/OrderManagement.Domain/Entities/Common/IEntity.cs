namespace OrderManagement.Domain.Entities.Common
{
    public interface IEntity
    {
        bool IsTransient();

        IReadOnlyList<ILegacyEvent> Events { get; }

        void ResetEvents();
    }
}