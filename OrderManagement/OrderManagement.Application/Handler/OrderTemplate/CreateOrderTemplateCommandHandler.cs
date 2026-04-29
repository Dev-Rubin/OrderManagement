using MediatR;
using OrderManagement.Application.Command.OrderTemplate;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderTemplate
{
    public class CreateOrderTemplateCommandHandler(IOrderTemplateService s) : IRequestHandler<CreateOrderTemplateCommand, Result>
    { 
        public Task<Result> Handle(CreateOrderTemplateCommand r, CancellationToken _) => s.CreateAsync(r);
    }
}
