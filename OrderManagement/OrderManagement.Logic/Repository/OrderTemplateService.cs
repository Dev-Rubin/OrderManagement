using OrderManagement.Application.Command.OrderTemplate;
using OrderManagement.Application.DTOs.OrderTemplateDto;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Logic.Repository
{
    public class OrderTemplateService : BasicCrudService<OrderTemplate, int>, IOrderTemplateService
    {
        public OrderTemplateService(IAppDbContext appDbContext, IUnitOfWork unitOfWork,
            IRepository repository, IQueries queries)
            : base(unitOfWork, repository, queries) { }

        public async Task<Result> CreateAsync(CreateOrderTemplateCommand request)
        {
            // If this is default, unset previous default
            if (request.IsDefault)
                await UnsetCurrentDefaultAsync(request.MerchantId);

            var entity = new OrderTemplate
            {
                MerchantId = request.MerchantId,
                TemplateName = request.TemplateName,
                RequireName = request.RequireName,
                RequireMobile = request.RequireMobile,
                RequireFlatVilla = request.RequireFlatVilla,
                RequireSociety = request.RequireSociety,
                RequireBlock = request.RequireBlock,
                RequireWhatsApp = request.RequireWhatsApp,
                CustomFieldsJson = request.CustomFieldsJson,
                IsDefault = request.IsDefault
            };

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Template created.", "Failed to create template.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message,
                data: MapToDto(entity));
        }

        public async Task<Result> UpdateAsync(UpdateOrderTemplateCommand request)
        {
            var entity = await Queries.New<IOrderTemplateQuery>()
                .WhereIdIs(request.Id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Template not found.");

            if (request.IsDefault && !entity.IsDefault)
                await UnsetCurrentDefaultAsync(entity.MerchantId);

            entity.TemplateName = request.TemplateName;
            entity.RequireName = request.RequireName;
            entity.RequireMobile = request.RequireMobile;
            entity.RequireFlatVilla = request.RequireFlatVilla;
            entity.RequireSociety = request.RequireSociety;
            entity.RequireBlock = request.RequireBlock;
            entity.RequireWhatsApp = request.RequireWhatsApp;
            entity.CustomFieldsJson = request.CustomFieldsJson;
            entity.IsDefault = request.IsDefault;

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.SaveUpdate(entity),
                "Template updated.", "Failed to update.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await Queries.New<IOrderTemplateQuery>()
                .WhereIdIs(id)
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("Template not found.");

            var chain = await Transact.ExecuteWithTransactionAsync(
                () => Repository.Delete(entity),
                "Template deleted.", "Failed to delete.");

            return new Result(chain.Result.IsSuccessful, chain.Result.Message);
        }

        public async Task<Result> GetByMerchantAsync(int merchantId)
        {
            var list = await Queries.New<IOrderTemplateQuery>()
                .WhereMerchantIdIs(merchantId)
                .GetAllAsync();

            return Result.Success("Templates fetched.", list.Select(MapToDto).ToList());
        }

        public async Task<Result> GetDefaultAsync(int merchantId)
        {
            var entity = await Queries.New<IOrderTemplateQuery>()
                .WhereMerchantIdIs(merchantId).WhereIsDefault()
                .GetFirstOrDefaultAsync();

            if (entity == null) return Result.Failure("No default template found.");

            return Result.Success("Default template fetched.", MapToDto(entity));
        }

        private async Task UnsetCurrentDefaultAsync(int merchantId)
        {
            var current = await Queries.New<IOrderTemplateQuery>()
                .WhereMerchantIdIs(merchantId).WhereIsDefault()
                .GetFirstOrDefaultAsync();

            if (current != null)
            {
                current.IsDefault = false;
                Repository.SaveUpdate(current);
                await UnitOfWork.SaveAsync();
            }
        }

        private static OrderTemplateDto MapToDto(OrderTemplate e) => new()
        {
            Id = e.Id,
            MerchantId = e.MerchantId,
            TemplateName = e.TemplateName,
            RequireName = e.RequireName,
            RequireMobile = e.RequireMobile,
            RequireFlatVilla = e.RequireFlatVilla,
            RequireSociety = e.RequireSociety,
            RequireBlock = e.RequireBlock,
            RequireWhatsApp = e.RequireWhatsApp,
            CustomFieldsJson = e.CustomFieldsJson,
            IsDefault = e.IsDefault
        };
    }
}
