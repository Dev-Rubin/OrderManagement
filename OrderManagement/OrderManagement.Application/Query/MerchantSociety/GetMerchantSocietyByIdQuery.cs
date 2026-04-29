using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.MerchantSociety
{
    public class GetMerchantSocietyByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public GetMerchantSocietyByIdQuery(int id) => Id = id;
    }
}
