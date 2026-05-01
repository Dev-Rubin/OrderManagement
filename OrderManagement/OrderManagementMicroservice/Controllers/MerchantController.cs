using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Merchant;
using OrderManagement.Application.Query.Merchant;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController(IMediator mediator) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
            => Ok(await mediator.Send(new GetAllMerchantsQuery()));

        [HttpGet("get-merchant-by-id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var result = await mediator.Send(new GetMerchantByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost("create-merchant")]
        public async Task<IActionResult> Create([FromBody] CreateMerchantCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-merchant")]
        public async Task<IActionResult> Update([FromBody] UpdateMerchantCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-by-id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteMerchantCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
