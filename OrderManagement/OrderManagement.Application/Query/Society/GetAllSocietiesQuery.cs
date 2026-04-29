using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Society
{
    public class GetAllSocietiesQuery : IRequest<Result> { }
}
