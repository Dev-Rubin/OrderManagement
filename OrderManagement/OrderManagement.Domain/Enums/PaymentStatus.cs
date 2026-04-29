using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Enums
{
    public enum PaymentStatus
    {
        [Display(Name = "Pending")]
        [Description("Payment is pending")]
        Pending = 0,
        
        [Display(Name = "Link Sent")]
        [Description("Payment link sent to customer")]
        LinkSent = 1,
        
        [Display(Name = "Paid")]
        [Description("Payment completed successfully")]
        Paid = 2,
        
        [Display(Name = "Failed")]
        [Description("Payment failed")]
        Failed = 3,
        
        [Display(Name = "Refunded")]
        [Description("Payment has been refunded")]
        Refunded = 4
    }
}
