using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.CustomerProfile
{
    public class GetCustomerProfileByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public GetCustomerProfileByIdQuery(int id) => Id = id;
    }
}
