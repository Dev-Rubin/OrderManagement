using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Society
{
    public class LinkMerchantSocietyCommand : IRequest<Result>
    {
        public int MerchantId { get; set; }
        public int SocietyId { get; set; }
        public string? DeliveryInstructions { get; set; }
    }
}
