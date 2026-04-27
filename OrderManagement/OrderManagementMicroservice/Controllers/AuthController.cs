using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Command.Auth;

namespace OrderManagement.Microservice.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand cmd)
            => Ok(await _mediator.Send(cmd));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand cmd)
            => Ok(await _mediator.Send(cmd));

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenCommand cmd)
            => Ok(await _mediator.Send(cmd));

        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOtp(GenerateOtpCommand request)
            => Ok(await _mediator.Send(request));

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpCommand request)
            => Ok(await _mediator.Send(request));

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand request)
            => Ok(await _mediator.Send(request));
    }
}
