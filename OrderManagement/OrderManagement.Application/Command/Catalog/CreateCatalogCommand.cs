using MediatR;
using OrderManagement.Application.DTOs.CatalogDto;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Catalog
{
    public class CreateCatalogCommand : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CatalogDate { get; set; }
        public DateTime? ScheduledPublishAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? WhatsAppMessageTemplate { get; set; }
        public List<CreateCatalogItemDto> Items { get; set; } = [];
    }
}
