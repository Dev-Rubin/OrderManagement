using MediatR;
using OrderManagement.Application.Query.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Society
{
    public class GetAllSocietiesQueryHandler(ISocietyService s) : IRequestHandler<GetAllSocietiesQuery, Result>
    { 
        public Task<Result> Handle(GetAllSocietiesQuery r, CancellationToken _) => s.GetAllAsync(); 
    }
}
