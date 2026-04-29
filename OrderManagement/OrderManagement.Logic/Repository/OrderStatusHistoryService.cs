using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Command.OrderStatusHistory;
using OrderManagement.Application.DTOs.OrderStatusHistoryDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class OrderStatusHistoryService : BasicCrudService<OrderStatusHistory, int>, IOrderStatusHistoryService
    {
        public OrderStatusHistoryService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> LogAsync(LogOrderStatusCommand request)
        {
            var entity = new OrderStatusHistory
            {
                OrderId = request.OrderId,
                FromStatus = request.FromStatus,
                ToStatus = request.ToStatus,
                Remarks = request.Remarks,
                ChangedByUserId = request.ChangedByUserId,
                ChangedAt = DateTime.UtcNow
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Status logged.", "Failed to log status.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByOrderIdAsync(int orderId)
        {
            var list = await Queries.New<IOrderStatusHistoryQuery>()
                .WhereOrderIdIs(orderId)
                .IncludeChangedByUser()
                .OrderByDesc(x => x.ChangedAt)
                .ToListAsync();

            var dtos = list.Select(e => new OrderStatusHistoryDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                FromStatus = e.FromStatus.ToString(),
                ToStatus = e.ToStatus.ToString(),
                Remarks = e.Remarks,
                ChangedByUserId = e.ChangedByUserId,
                ChangedByUserName = e.ChangedByUser?.UserName,
                ChangedAt = e.ChangedAt
            }).ToList();

            return Result.Success("Status history fetched.", dtos);
        }
    }
}
