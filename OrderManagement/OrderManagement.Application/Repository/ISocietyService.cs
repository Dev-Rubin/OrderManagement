using OrderManagement.Application.Command.Society;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Repository
{
    public interface ISocietyService
    {
        Task<Result> CreateAsync(CreateSocietyCommand request);
        Task<Result> UpdateAsync(UpdateSocietyCommand request);
        Task<Result> DeleteAsync(int id);
        Task<Result> GetByIdAsync(int id);
        Task<Result> GetAllAsync();
    }
}
