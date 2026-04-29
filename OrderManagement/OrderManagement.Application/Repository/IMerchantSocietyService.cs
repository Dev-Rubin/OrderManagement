using OrderManagement.Application.Command.Society;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface IMerchantSocietyService
    {
        Task<Result> LinkAsync(LinkMerchantSocietyCommand request);
        Task<Result> UpdateAsync(UpdateMerchantSocietyCommand request);
        Task<Result> UnlinkAsync(int id);
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetByMerchantAsync(int merchantId);
    }
}
