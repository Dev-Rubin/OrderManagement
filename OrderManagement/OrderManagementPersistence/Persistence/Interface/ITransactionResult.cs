namespace OrderManagement.Infrastructure.Persistence.Interface
{
    public interface ITransactionResult : IOperationResult
    {
        Exception Exception { get; }
        string ReferenceNo { get; set; }
        int ReferenceId { get; set; }

    }
}
