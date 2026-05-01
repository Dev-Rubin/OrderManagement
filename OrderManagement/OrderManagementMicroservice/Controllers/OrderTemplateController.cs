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
        [HttpGet("get-order-templates-by-merchantid")]
        public async Task<IActionResult> GetByMerchant([FromQuery]int merchantId)
            => Ok(await mediator.Send(new GetOrderTemplatesByMerchantQuery(merchantId)));

        [HttpGet("get-default-order-template")]
        public async Task<IActionResult> GetDefault([FromQuery]int merchantId)
        {
            var result = await mediator.Send(new GetDefaultOrderTemplateQuery(merchantId));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost("create-order-template")]
        public async Task<IActionResult> Create([FromBody] CreateOrderTemplateCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-order-template")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderTemplateCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-by-id")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var result = await mediator.Send(new DeleteOrderTemplateCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
