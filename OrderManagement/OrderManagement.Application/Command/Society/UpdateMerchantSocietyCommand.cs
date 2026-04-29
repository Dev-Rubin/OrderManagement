using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Society
{
    public class UpdateMerchantSocietyCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? DeliveryInstructions { get; set; }
    }
}
