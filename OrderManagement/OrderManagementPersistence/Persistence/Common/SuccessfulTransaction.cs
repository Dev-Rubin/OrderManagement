using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Persistence.Persistence.Common
{
    [Serializable]
    public class SuccessfulTransaction : ITransactionResult
    {
        #region Constructor and Initialization

        public SuccessfulTransaction(string message = "Success")
        {
            Message = message;
        }

        #endregion

        #region Properties
        public string Message { get; set; }
        public Exception Exception
        {
            get { return null; }
        }

        public bool IsSuccessful
        {
            get { return true; }
        }
        public string ReferenceNo { get; set; }
        public int ReferenceId { get; set; }

        #endregion
    }
}