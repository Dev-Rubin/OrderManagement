namespace OrderManagement.Application.DTOs.OrderTemplateDto
{
    public class OrderTemplateDto
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public bool RequireName { get; set; }
        public bool RequireMobile { get; set; }
        public bool RequireFlatVilla { get; set; }
        public bool RequireSociety { get; set; }
        public bool RequireBlock { get; set; }
        public bool RequireWhatsApp { get; set; }
        public string? CustomFieldsJson { get; set; }
        public bool IsDefault { get; set; }
    }

}
