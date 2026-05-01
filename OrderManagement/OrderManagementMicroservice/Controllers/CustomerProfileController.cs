using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.CustomerProfile;
using OrderManagement.Application.Query.CustomerProfile;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerProfileController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-merchant-society-by-merchantsocietyid")]
        public async Task<IActionResult> GetByMerchantSociety(int merchantSocietyId)
            => Ok(await mediator.Send(new GetCustomersByMerchantSocietyQuery(merchantSocietyId)));

        [HttpGet("get-customer-profile-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetCustomerProfileByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpGet("get-customer-order-history-by-id")]
        public async Task<IActionResult> GetOrderHistory(int id)
            => Ok(await mediator.Send(new GetCustomerOrderHistoryQuery(id)));

        [HttpPost("create-customer-profile")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerProfileCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-customer-profile")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerProfileCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
