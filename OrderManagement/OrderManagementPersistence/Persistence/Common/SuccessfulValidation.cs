using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Persistence.Persistence.Common
{
    public class SuccessfulValidation : IOperationResult
    {
        public SuccessfulValidation(string message = "Entity is valid")
        {
            Message = message;
        }

        #region IOperationResult Members

        public string Message { get; private set; }

        public bool IsSuccessful
        {
            get { return true; }
        }

        #endregion
    }
}