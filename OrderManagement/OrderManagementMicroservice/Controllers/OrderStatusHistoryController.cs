using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.OrderStatusHistory;
using OrderManagement.Application.Query.CustomerProfile;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusHistoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-orderstatus-history-by-orderid")]
        public async Task<IActionResult> GetByOrder([FromQuery]int orderId)
            => Ok(await mediator.Send(new GetOrderStatusHistoryQuery(orderId)));

        [HttpPost("post-logorderstatus")]
        public async Task<IActionResult> Log([FromBody] LogOrderStatusCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
