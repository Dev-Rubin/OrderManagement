using OrderManagement.Application.Command.Society;
using OrderManagement.Application.DTOs.MerchantSocietyDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class MerchantSocietyService : BasicCrudService<MerchantSociety, int>, IMerchantSocietyService
    {
        public MerchantSocietyService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> LinkAsync(LinkMerchantSocietyCommand request)
        {
            var exists = await Queries.New<IMerchantSocietyQuery>()
                .WhereMerchantIdIs(request.MerchantId)
                .WhereSocietyIdIs(request.SocietyId)
                .GetAnyAsync();

            if (exists) return Result.Failure("This merchant-society link already exists.");

            var entity = new MerchantSociety
            {
                MerchantId = request.MerchantId,
                SocietyId = request.SocietyId,
                DeliveryInstructions = request.DeliveryInstructions,
                IsActive = true
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Merchant linked to society successfully.",
                "Failed to link merchant to society."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: new { MerchantSocietyId = entity.Id });
        }

        public async Task<Result> UpdateAsync(UpdateMerchantSocietyCommand request)
        {
            var entity = await Queries.New<IMerchantSocietyQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Merchant-society link not found.");

            entity.IsActive = request.IsActive;
            entity.DeliveryInstructions = request.DeliveryInstructions;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Updated successfully.", "Failed to update.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> UnlinkAsync(int id)
        {
            var entity = await Queries.New<IMerchantSocietyQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Link not found.");

            entity.IsActive = false;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Unlinked successfully.", "Failed to unlink.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var entity = await Queries.New<IMerchantSocietyQuery>()
                .IncludeMerchant().IncludeSociety().WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Not found.");

            return Result.Success("Fetched.", MapToDto(entity));
        }

        public async Task<Result> GetByMerchantAsync(int merchantId)
        {
            var list = await Queries.New<IMerchantSocietyQuery>()
                .IncludeSociety()
                .WhereMerchantIdIs(merchantId)
                .WhereActive()
                .GetAllAsync();

            return Result.Success("Fetched.", list.Select(MapToDto).ToList());
        }

        private static MerchantSocietyDto MapToDto(MerchantSociety e) => new()
        {
            Id = e.Id,
            MerchantId = e.MerchantId,
            MerchantName = e.Merchant?.BusinessName ?? string.Empty,
            SocietyId = e.SocietyId,
            SocietyName = e.Society?.Name ?? string.Empty,
            IsActive = e.IsActive,
            DeliveryInstructions = e.DeliveryInstructions
        };
    }
}
