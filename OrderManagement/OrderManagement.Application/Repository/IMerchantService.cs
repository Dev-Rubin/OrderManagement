using OrderManagement.Application.Command.Merchant;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IMerchantService
    {
        Task<Result> CreateAsync(CreateMerchantCommand request);
        Task<Result> UpdateAsync(UpdateMerchantCommand request);
        Task<Result> DeleteAsync(int id);
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetAllAsync();
    }
}
