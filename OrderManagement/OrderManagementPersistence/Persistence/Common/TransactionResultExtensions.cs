using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Persistence.Persistence.Common
{
    public static class TransactionResultExtensions
    {
        public static ITransactionResult ToTransactionResult(this IOperationResult result)
        {
            if (result.IsSuccessful)
            {
                return new SuccessfulTransaction(result.Message);
            }
            return new FailedTransaction(result);
        }

        public static ITransactionResult WithMessage(this ITransactionResult transactionResult, string successMessage, string failureMessage)
        {
            if (transactionResult.IsSuccessful)
            {
                return new SuccessfulTransaction(successMessage);
            }
            return new FailedTransaction(failureMessage + "; " + transactionResult.Message, transactionResult.Exception);
        }
    }
}
