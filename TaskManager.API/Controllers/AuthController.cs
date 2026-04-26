using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Auth.Commands.RegisterUser;
using TaskManager.Application.Features.Auth.Queries.Login;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [AllowAnonymous] // No auth required to register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);
                return Ok(new { Message = "User registered successfully", UserId = userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [AllowAnonymous] // Frontend will call this to verify credentials before saving to localStorage
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var userDto = await _mediator.Send(query);

            if (userDto != null)
            {
                // Return the user details so the frontend can display them
                return Ok(userDto);
            }

            return Unauthorized(new { Error = "Invalid username or password" });
        }
    }
}
