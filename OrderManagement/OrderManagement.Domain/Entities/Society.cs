using OrderManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entities
{
    public class Society : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? PinCode { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<MerchantSociety> MerchantSocieties { get; set; } = [];
    }
}
