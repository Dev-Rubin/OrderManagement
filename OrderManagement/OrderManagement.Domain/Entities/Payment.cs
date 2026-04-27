using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Payment : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public string? RazorpayOrderId { get; set; }
        public string? RazorpayPaymentId { get; set; }
        public string? PaymentLinkId { get; set; }
        public string? PaymentLinkUrl { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? FailureReason { get; set; }
        public int RetryCount { get; set; }
        public DateTime? LinkExpiresAt { get; set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
    }
}
