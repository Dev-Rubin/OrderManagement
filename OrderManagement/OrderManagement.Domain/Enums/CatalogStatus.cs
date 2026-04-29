using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Enums
{
    public enum CatalogStatus
    {
        [Display(Name = "Draft")]
        [Description("Catalog is in draft state")]
        Draft = 0,

        [Display(Name = "Scheduled")]   
        [Description("Catalog is scheduled for publishing")]
        Scheduled = 1,
        
        [Display(Name = "Active")]
        [Description("Catalog is active")]
        Active = 2,
        
        [Display(Name = "Expired")]
        [Description("Catalog has expired")]
        Expired = 3
    }
}
