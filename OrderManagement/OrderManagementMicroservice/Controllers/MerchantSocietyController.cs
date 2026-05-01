using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Query.MerchantSociety;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantSocietyController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-societies-by-merchantid")]
        public async Task<IActionResult> GetByMerchant([FromQuery]int merchantId)
            => Ok(await mediator.Send(new GetSocietiesByMerchantQuery(merchantId)));

        [HttpPost("link-merchant-society")]
        public async Task<IActionResult> Link([FromBody] LinkMerchantSocietyCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-merchantsociety")]
        public async Task<IActionResult> Update([FromBody] UpdateMerchantSocietyCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("unlink-merchant-society")]
        public async Task<IActionResult> Unlink([FromBody]int id)
        {
            var result = await mediator.Send(new UnlinkMerchantSocietyCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
