using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Society;
using OrderManagement.Application.Query.Society;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocietyController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get-all-societies")]
        public async Task<IActionResult> GetAll()
            => Ok(await mediator.Send(new GetAllSocietiesQuery()));

        [HttpGet("get-society-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetSocietyByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost("create-society")]
        public async Task<IActionResult> Create([FromBody] CreateSocietyCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update-society")]
        public async Task<IActionResult> Update([FromBody] UpdateSocietyCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-society-by-id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteSocietyCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
