using OrderManagement.Application.Command.OrderStatusHistory;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IOrderStatusHistoryService
    {
        Task<Result> LogAsync(LogOrderStatusCommand request);
        Task<Result> GetByOrderIdAsync(int orderId);
    }
}
