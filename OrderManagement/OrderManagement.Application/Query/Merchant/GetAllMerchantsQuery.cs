using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Merchant
{
    public class GetAllMerchantsQuery : IRequest<Result> { }
}
