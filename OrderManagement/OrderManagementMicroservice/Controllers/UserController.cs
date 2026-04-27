using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Query.User;
using OrderManagement.Domain.Enums;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/user")]
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
