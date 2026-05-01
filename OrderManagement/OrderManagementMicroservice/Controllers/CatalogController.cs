using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Catalog;
using OrderManagement.Application.Query.Catalog;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-allcatalogs")]
        public async Task<IActionResult> GetAll([FromQuery] int? merchantId, [FromQuery] DateTime? date)
            => Ok(await mediator.Send(new GetAllCatalogsQuery { MerchantId = merchantId, Date = date }));

        [HttpGet("get-catalog-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await mediator.Send(new GetCatalogByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpGet("get-active-catalog")]
        public async Task<IActionResult> GetActive([FromQuery] int merchantId)
        {
            var result = await mediator.Send(new GetActiveCatalogQuery(merchantId));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost("create-catalog")]
        public async Task<IActionResult> Create([FromBody] CreateCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-catalog")]
        public async Task<IActionResult> Update([FromBody] UpdateCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("publish-catalog")]
        public async Task<IActionResult> Publish([FromBody] int id)
        {
            var result = await mediator.Send(new PublishCatalogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-catalog-by-id")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await mediator.Send(new DeleteCatalogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        // Catalog Items
        [HttpPost("add-catalog-item")]
        public async Task<IActionResult> AddItem([FromBody] AddCatalogItemCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-catalog-item")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateCatalogItemCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("remove-catalog-item-by-id")]
        public async Task<IActionResult> RemoveItem([FromBody] int id)
        {
            var result = await mediator.Send(new RemoveCatalogItemCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
