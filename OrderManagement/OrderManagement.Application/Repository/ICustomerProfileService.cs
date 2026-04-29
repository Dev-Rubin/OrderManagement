using OrderManagement.Application.Command.CustomerProfile;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface ICustomerProfileService
    {
        Task<Result> CreateAsync(CreateCustomerProfileCommand request);
        Task<Result> UpdateAsync(UpdateCustomerProfileCommand request);
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetByMerchantSocietyAsync(int merchantSocietyId);
        Task<Result> GetOrderHistoryAsync(int customerProfileId);
    }
}
