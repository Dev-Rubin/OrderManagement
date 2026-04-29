using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Society
{
    public class CreateSocietyCommandHandler(ISocietyService s) : IRequestHandler<CreateSocietyCommand, Result>
    { 
        public Task<Result> Handle(CreateSocietyCommand r, CancellationToken _) => s.CreateAsync(r); 
    }
}
