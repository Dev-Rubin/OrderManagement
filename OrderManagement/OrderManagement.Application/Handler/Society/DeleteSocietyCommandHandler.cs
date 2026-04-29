using MediatR;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.Society
{
    public class DeleteSocietyCommandHandler(ISocietyService s) : IRequestHandler<DeleteSocietyCommand, Result>
    { 
        public Task<Result> Handle(DeleteSocietyCommand r, CancellationToken _) => s.DeleteAsync(r.Id); 
    }
}
