using MediatR;
using OrderManagement.Domain.Enums;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.OrderStatusHistory
{
    public class LogOrderStatusCommand : IRequest<Result>
    {
        public int OrderId { get; set; }
        public OrderStatus FromStatus { get; set; }
        public OrderStatus ToStatus { get; set; }
        public string? Remarks { get; set; }
        public int? ChangedByUserId { get; set; }
    }
}
