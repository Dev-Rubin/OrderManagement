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
        [HttpGet("by-order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
            => Ok(await mediator.Send(new GetOrderStatusHistoryQuery(orderId)));

        [HttpPost]
        public async Task<IActionResult> Log([FromBody] LogOrderStatusCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
