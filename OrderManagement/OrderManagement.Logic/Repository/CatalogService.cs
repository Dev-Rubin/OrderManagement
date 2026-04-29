using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.DTOs.CatalogDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class CatalogService : BasicCrudService<Catalog, int>, ICatalogService
    {
        public CatalogService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> CreateAsync(CreateCatalogCommand request)
        {
            var entity = new Catalog
            {
                MerchantId = request.MerchantId,
                Title = request.Title,
                Description = request.Description,
                CatalogDate = request.CatalogDate,
                ScheduledPublishAt = request.ScheduledPublishAt,
                ExpiresAt = request.ExpiresAt,
                WhatsAppMessageTemplate = request.WhatsAppMessageTemplate,
                Status = request.ScheduledPublishAt.HasValue
                    ? CatalogStatus.Scheduled
                    : CatalogStatus.Draft,
                Items = request.Items.Select((item, i) => new CatalogItem
                {
                    ProductId = item.ProductId,
                    ItemName = item.ItemName,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    IsAvailable = true,
                    SortOrder = item.SortOrder > 0 ? item.SortOrder : i + 1
                }).ToList()
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Catalog created.", "Failed to create catalog.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: new { CatalogId = entity.Id });
        }

        public async Task<Result> UpdateAsync(UpdateCatalogCommand request)
        {
            var entity = await Queries.New<ICatalogQuery>()
                .WhereIdIs(request.Id)
                .GetLastOrDefaultAsync();

            if (entity == null) return Result.Failure("Catalog not found.");
            if (entity.Status == CatalogStatus.Active)
                return Result.Failure("Cannot edit an active catalog.");

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.CatalogDate = request.CatalogDate;
            entity.ScheduledPublishAt = request.ScheduledPublishAt;
            entity.ExpiresAt = request.ExpiresAt;
            entity.WhatsAppMessageTemplate = request.WhatsAppMessageTemplate;
            entity.ImageUrl = request.ImageUrl;

            if (request.ScheduledPublishAt.HasValue && entity.Status == CatalogStatus.Draft)
                entity.Status = CatalogStatus.Scheduled;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Catalog updated.", "Failed to update catalog.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> PublishAsync(int id)
        {
            var entity = await Queries.New<ICatalogQuery>()
                .WhereIdIs(id)
                .GetLastOrDefaultAsync();

            if (entity == null) return Result.Failure("Catalog not found.");

            entity.Status = CatalogStatus.Active;
            entity.PublishedAt = DateTime.UtcNow;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Catalog published.", "Failed to publish.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await Queries.New<ICatalogQuery>()
                .WhereIdIs(id)
                .GetLastOrDefaultAsync();

            if (entity == null) return Result.Failure("Catalog not found.");

            entity.IsDeleted = true;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Catalog deleted.", "Failed to delete.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var entity = await Queries.New<ICatalogQuery>()
                .IncludeItems()
                .WhereIdIs(id)
                .GetLastOrDefaultAsync();

            if (entity == null) return Result.Failure("Not found.");

            return Result.Success("Catalog fetched.", MapToDto(entity));
        }

        public async Task<Result> GetAllAsync(int? merchantId, DateTime? date)
        {
            var query = Queries.New<ICatalogQuery>().IncludeItems();

            if (merchantId.HasValue) query = query.WhereMerchantIdIs(merchantId.Value);
            if (date.HasValue) query = query.WhereDateIs(date.Value);

            var list = await query.OrderByDesc(x => x.CatalogDate).ToListAsync();

            return Result.Success("Catalogs fetched.", list.Select(MapToDto).ToList());
        }

        public async Task<Result> GetActiveAsync(int merchantId)
        {
            var entity = await Queries.New<ICatalogQuery>()
                .IncludeItems()
                .WhereMerchantIdIs(merchantId)
                .WhereStatus(CatalogStatus.Active)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("No active catalog found.");

            return Result.Success("Active catalog fetched.", MapToDto(entity));
        }

        public async Task<Result> AddItemAsync(AddCatalogItemCommand request)
        {
            var entity = new CatalogItem
            {
                CatalogId = request.CatalogId,
                ProductId = request.ProductId,
                ItemName = request.ItemName,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price,
                IsAvailable = true,
                SortOrder = request.SortOrder
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Item added.", "Failed to add item.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: new { ItemId = entity.Id });
        }

        public async Task<Result> UpdateItemAsync(UpdateCatalogItemCommand request)
        {
            var entity = await Queries.New<ICatalogItemQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Item not found.");

            entity.ItemName = request.ItemName;
            entity.Description = request.Description;
            entity.Quantity = request.Quantity;
            entity.Price = request.Price;
            entity.IsAvailable = request.IsAvailable;
            entity.SortOrder = request.SortOrder;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Item updated.", "Failed to update item.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> RemoveItemAsync(int id)
        {
            var entity = await Queries.New<ICatalogItemQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Item not found.");

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.Delete(entity),
                "Item removed.", "Failed to remove item.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        private static CatalogDto MapToDto(Catalog e) => new()
        {
            Id = e.Id,
            MerchantId = e.MerchantId,
            MerchantName = e.Merchant?.BusinessName ?? string.Empty,
            Title = e.Title,
            Description = e.Description,
            CatalogDate = e.CatalogDate,
            ScheduledPublishAt = e.ScheduledPublishAt,
            PublishedAt = e.PublishedAt,
            ExpiresAt = e.ExpiresAt,
            Status = e.Status.ToString(),
            ImageUrl = e.ImageUrl,
            WhatsAppMessageTemplate = e.WhatsAppMessageTemplate,
            Items = e.Items?.Select(i => new CatalogItemDto
            {
                Id = i.Id,
                CatalogId = i.CatalogId,
                ProductId = i.ProductId,
                ItemName = i.ItemName,
                Description = i.Description,
                Quantity = i.Quantity,
                Price = i.Price,
                IsAvailable = i.IsAvailable,
                SortOrder = i.SortOrder
            }).OrderBy(x => x.SortOrder).ToList() ?? []
        };
    }
}
