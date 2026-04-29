using OrderManagement.Application.Command.Merchant;
using OrderManagement.Application.DTOs.MerchantDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class MerchantService : BasicCrudService<Merchant, int>, IMerchantService
    {
        public MerchantService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> CreateAsync(CreateMerchantCommand request)
        {
            var entity = new Merchant
            {
                BusinessName = request.BusinessName,
                OwnerName = request.OwnerName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                WhatsAppNumber = request.WhatsAppNumber,
                Address = request.Address,
                AdminUserId = request.AdminUserId,
                IsActive = true
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Merchant created successfully.",
                "Failed to create merchant."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: MapToDto(entity));
        }

        public async Task<Result> UpdateAsync(UpdateMerchantCommand request)
        {
            var entity = await Queries.New<IMerchantQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Merchant not found.");

            entity.BusinessName = request.BusinessName;
            entity.OwnerName = request.OwnerName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;
            entity.WhatsAppNumber = request.WhatsAppNumber;
            entity.LogoUrl = request.LogoUrl;
            entity.Address = request.Address;
            entity.IsActive = request.IsActive;
            entity.AdminUserId = request.AdminUserId;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Merchant updated successfully.",
                "Failed to update merchant."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await Queries.New<IMerchantQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Merchant not found.");

            entity.IsActive = false;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Merchant deactivated successfully.",
                "Failed to deactivate merchant."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var entity = await Queries.New<IMerchantQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Merchant not found.");

            return Result.Success("Merchant fetched.", MapToDto(entity));
        }

        public async Task<Result> GetAllAsync()
        {
            var list = await Queries.New<IMerchantQuery>()
                .WhereActive()
                .GetAllAsync();

            return Result.Success("Merchants fetched.", list.Select(MapToDto).ToList());
        }

        private static MerchantDto MapToDto(Merchant e) => new()
        {
            Id = e.Id,
            BusinessName = e.BusinessName,
            OwnerName = e.OwnerName,
            PhoneNumber = e.PhoneNumber,
            Email = e.Email,
            WhatsAppNumber = e.WhatsAppNumber,
            LogoUrl = e.LogoUrl,
            Address = e.Address,
            IsActive = e.IsActive,
            AdminUserId = e.AdminUserId
        };
    }
}
