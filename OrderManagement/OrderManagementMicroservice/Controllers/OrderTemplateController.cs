using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.OrderTemplate;
using OrderManagement.Application.Query.OrderTemplate;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderTemplateController(IMediator mediator) : ControllerBase
    {
        [HttpGet("by-merchant/{merchantId}")]
        public async Task<IActionResult> GetByMerchant(int merchantId)
            => Ok(await mediator.Send(new GetOrderTemplatesByMerchantQuery(merchantId)));

        [HttpGet("default/{merchantId}")]
        public async Task<IActionResult> GetDefault(int merchantId)
        {
            var result = await mediator.Send(new GetDefaultOrderTemplateQuery(merchantId));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderTemplateCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderTemplateCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteOrderTemplateCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
