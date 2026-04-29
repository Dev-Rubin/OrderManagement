using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Merchant
{
    public class DeleteMerchantCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public DeleteMerchantCommand(int id) => Id = id;
    }
}
