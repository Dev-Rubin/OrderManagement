using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.OrderTemplate
{
    public class UpdateOrderTemplateCommand : IRequest<Result>
    {
        public int Id { get; set; }
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
