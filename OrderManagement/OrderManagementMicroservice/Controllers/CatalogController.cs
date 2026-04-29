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
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? merchantId, [FromQuery] DateTime? date)
            => Ok(await mediator.Send(new GetAllCatalogsQuery { MerchantId = merchantId, Date = date }));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetCatalogByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpGet("active/{merchantId}")]
        public async Task<IActionResult> GetActive(int merchantId)
        {
            var result = await mediator.Send(new GetActiveCatalogQuery(merchantId));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("{id}/publish")]
        public async Task<IActionResult> Publish(int id)
        {
            var result = await mediator.Send(new PublishCatalogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteCatalogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        // Catalog Items
        [HttpPost("item")]
        public async Task<IActionResult> AddItem([FromBody] AddCatalogItemCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("item")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateCatalogItemCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("item/{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            var result = await mediator.Send(new RemoveCatalogItemCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
