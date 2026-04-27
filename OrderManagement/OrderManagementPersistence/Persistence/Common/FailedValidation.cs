using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Persistence.Persistence.Common
{
    public class FailedValidation : IOperationResult
    {
        public FailedValidation(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }

        public bool IsSuccessful
        {
            get { return false; }
        }
    }
}