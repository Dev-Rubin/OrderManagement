using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Society
{
    public class UpdateSocietyCommandHandler(ISocietyService s) : IRequestHandler<UpdateSocietyCommand, Result>
    { 
        public Task<Result> Handle(UpdateSocietyCommand r, CancellationToken _) => s.UpdateAsync(r);
    }
}
