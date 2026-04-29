using OrderManagement.Application.Command.OrderTemplate;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IOrderTemplateService
    {
        Task<Result> CreateAsync(CreateOrderTemplateCommand request);
        Task<Result> UpdateAsync(UpdateOrderTemplateCommand request);
        Task<Result> DeleteAsync(int id);
        Task<Result> GetByMerchantAsync(int merchantId);
        Task<Result> GetDefaultAsync(int merchantId);
    }
}
