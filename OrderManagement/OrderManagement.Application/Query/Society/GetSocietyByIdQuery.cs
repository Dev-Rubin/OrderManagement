using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.Society
{
    public class GetSocietyByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public GetSocietyByIdQuery(int id) => Id = id;
    }
}
