using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,

        [Display(Name = "Confirmed")]
        Confirmed = 2,

        [Display(Name = "Processing")]
        Processing = 3,

        [Display(Name = "Out For Delivery")]
        OutForDelivery = 4,

        [Display(Name = "Delivered")]
        Delivered = 5,

        [Display(Name = "Cancelled")]
        Cancelled = 6,

        [Display(Name = "Failed")]
        Failed = 7
    }
}
