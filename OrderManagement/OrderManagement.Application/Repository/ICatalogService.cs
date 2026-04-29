using OrderManagement.Application.Command.Catalog;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface ICatalogService
    {
        Task<Result> CreateAsync(CreateCatalogCommand request);
        Task<Result> UpdateAsync(UpdateCatalogCommand request);
        Task<Result> PublishAsync(int id);
        Task<Result> DeleteAsync(int id);
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetAllAsync(int? merchantId, DateTime? date);
        Task<Result> GetActiveAsync(int merchantId);
        Task<Result> AddItemAsync(AddCatalogItemCommand request);
        Task<Result> UpdateItemAsync(UpdateCatalogItemCommand request);
        Task<Result> RemoveItemAsync(int id);
    }
}
