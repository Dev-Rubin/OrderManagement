using MediatR;
using OrderManagement.Application.Query.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Society
{
    public class GetSocietyByIdQueryHandler(ISocietyService s) : IRequestHandler<GetSocietyByIdQuery, Result>
    {
        public Task<Result> Handle(GetSocietyByIdQuery r, CancellationToken _) => s.GetByIdAsync(r.Id);
    }
}
