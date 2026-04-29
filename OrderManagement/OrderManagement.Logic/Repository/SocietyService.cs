using OrderManagement.Application.Command.Society;
using OrderManagement.Application.DTOs.SocietyDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class SocietyService : BasicCrudService<Society, int>, ISocietyService
    {
        public SocietyService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> CreateAsync(CreateSocietyCommand request)
        {
            var entity = new Society
            {
                Name = request.Name,
                City = request.City,
                Area = request.Area,
                PinCode = request.PinCode,
                IsActive = true
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Society created successfully.",
                "Failed to create society."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: MapToDto(entity));
        }

        public async Task<Result> UpdateAsync(UpdateSocietyCommand request)
        {
            var entity = await Queries.New<ISocietyQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Society not found.");

            entity.Name = request.Name;
            entity.City = request.City;
            entity.Area = request.Area;
            entity.PinCode = request.PinCode;
            entity.IsActive = request.IsActive;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Society updated successfully.",
                "Failed to update society."
            );

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await Queries.New<ISocietyQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Society not found.");

            entity.IsActive = false;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Society deactivated.", "Failed to deactivate society.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var entity = await Queries.New<ISocietyQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Society not found.");

            return Result.Success("Society fetched.", MapToDto(entity));
        }

        public async Task<Result> GetAllAsync()
        {
            var list = await Queries.New<ISocietyQuery>()
                .WhereActive()
                .GetAllAsync();

            return Result.Success("Societies fetched.", list.Select(MapToDto).ToList());
        }

        private static SocietyDto MapToDto(Society e) => new()
        {
            Id = e.Id,
            Name = e.Name,
            City = e.City,
            Area = e.Area,
            PinCode = e.PinCode,
            IsActive = e.IsActive
        };
    }
}
