using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Society
{
    public class UnlinkMerchantSocietyCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public UnlinkMerchantSocietyCommand(int id) => Id = id;
    }
}
