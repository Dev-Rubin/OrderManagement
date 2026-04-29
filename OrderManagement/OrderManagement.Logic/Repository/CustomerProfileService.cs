using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Command.CustomerProfile;
using OrderManagement.Application.DTOs.CustomerProfileDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class CustomerProfileService : BasicCrudService<CustomerProfile, int>, ICustomerProfileService
    {
        public CustomerProfileService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> CreateAsync(CreateCustomerProfileCommand request)
        {
            var exists = await Queries.New<ICustomerProfileQuery>()
                .WhereUserIdIs(request.UserId)
                .WhereMerchantSocietyIdIs(request.MerchantSocietyId)
                .GetAnyAsync();

            if (exists) return Result.Failure("Customer profile already exists for this society.");

            var entity = new CustomerProfile
            {
                UserId = request.UserId,
                MerchantSocietyId = request.MerchantSocietyId,
                FullName = request.FullName,
                MobileNumber = request.MobileNumber,
                FlatOrVillaNumber = request.FlatOrVillaNumber,
                Block = request.Block,
                WhatsAppId = request.WhatsAppId,
                IsActive = true,
                TotalOrders = 0
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Customer profile created.", "Failed to create profile.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: new { ProfileId = entity.Id });
        }

        public async Task<Result> UpdateAsync(UpdateCustomerProfileCommand request)
        {
            var entity = await Queries.New<ICustomerProfileQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Customer profile not found.");

            entity.FullName = request.FullName;
            entity.MobileNumber = request.MobileNumber;
            entity.FlatOrVillaNumber = request.FlatOrVillaNumber;
            entity.Block = request.Block;
            entity.WhatsAppId = request.WhatsAppId;
            entity.IsActive = request.IsActive;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Profile updated.", "Failed to update.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var entity = await Queries.New<ICustomerProfileQuery>()
                .IncludeMerchantSociety().WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Not found.");

            return Result.Success("Fetched.", MapToDto(entity));
        }

        public async Task<Result> GetByMerchantSocietyAsync(int merchantSocietyId)
        {
            var list = await Queries.New<ICustomerProfileQuery>()
                .IncludeMerchantSociety()
                .WhereMerchantSocietyIdIs(merchantSocietyId)
                .WhereActive()
                .GetAllAsync();

            return Result.Success("Fetched.", list.Select(MapToDto).ToList());
        }

        public async Task<Result> GetOrderHistoryAsync(int customerProfileId)
        {
            var profile = await Queries.New<ICustomerProfileQuery>()
                .WhereIdIs(customerProfileId)
                .GetFirstOrDefaultAsync();

            if (profile == null) return Result.Failure("Profile not found.");

            var orders = await Queries.New<IOrderQuery>()
                .WhereUserIdIs(profile.UserId)
                .WhereMerchantSocietyIdIs(profile.MerchantSocietyId)
                .IncludeItems()
                .OrderByDesc(x => x.Id)
                .ToListAsync();

            var dtos = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                AddedDate = o.AddedDate,
                OrderItems = o.OrderItems?.Select(i => new OrderItemDto
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList() ?? []
            }).ToList();

            return Result.Success("Order history fetched.", dtos);
        }

        private static CustomerProfileDto MapToDto(CustomerProfile e) => new()
        {
            Id = e.Id,
            UserId = e.UserId,
            MerchantSocietyId = e.MerchantSocietyId,
            FullName = e.FullName,
            MobileNumber = e.MobileNumber,
            FlatOrVillaNumber = e.FlatOrVillaNumber,
            Block = e.Block,
            WhatsAppId = e.WhatsAppId,
            IsActive = e.IsActive,
            LastOrderAt = e.LastOrderAt,
            TotalOrders = e.TotalOrders,
            SocietyName = e.MerchantSociety?.Society?.Name ?? string.Empty
        };
    }
}
