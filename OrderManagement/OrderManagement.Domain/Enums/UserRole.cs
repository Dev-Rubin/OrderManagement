using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Enums
{

    public enum UserRole
    {
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,

        [Display(Name = "Admin")]
        Admin = 2,

        [Display(Name = "Operator")]
        Operator = 3,

        [Display(Name = "Delivery Agent")]
        DeliveryAgent = 4,

        [Display(Name = "Customer")]
        Customer = 5
    }
}
