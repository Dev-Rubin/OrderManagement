namespace OrderManagement.Infrastructure.Persistence.Interface
{
    public interface IApplicationSettings
    {
        int TransactionRetryCount { get; }
        string Separator { get; }
        int UnitMoneyDecimalPlaces { get; }
        double TaxRate { get; }
    }
}
