using MediatR;
using OrderManagement.Application.Command.OrderStatusHistory;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.OrderStatusHistory
{
    public class LogOrderStatusCommandHandler(IOrderStatusHistoryService s) : IRequestHandler<LogOrderStatusCommand, Result>
    { 
        public Task<Result> Handle(LogOrderStatusCommand r, CancellationToken _) => s.LogAsync(r);
    }
}
