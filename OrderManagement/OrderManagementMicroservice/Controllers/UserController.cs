using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Query.User;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("roles-autocomplete")]
        public async Task<IActionResult> GetRolesAutocompleteAsync([FromQuery]GetRolesAutocompleteQuery qry)
            => Ok(await _mediator.Send(qry));

    }
}
