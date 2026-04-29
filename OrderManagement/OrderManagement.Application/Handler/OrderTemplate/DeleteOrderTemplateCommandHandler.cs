using MediatR;
using OrderManagement.Application.Command.OrderTemplate;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderTemplate
{
    public class DeleteOrderTemplateCommandHandler(IOrderTemplateService s) : IRequestHandler<DeleteOrderTemplateCommand, Result>
    { 
        public Task<Result> Handle(DeleteOrderTemplateCommand r, CancellationToken _) => s.DeleteAsync(r.Id);
    }
}
