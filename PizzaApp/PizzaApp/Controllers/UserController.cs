namespace PizzaApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PizzaApp.DTOs.UserDTOs;
    using PizzaApp.Services.Interfaces;
    using PizzaApp.Shared.CustomExceptions;

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // allows access without authentication
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User/authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserDTO model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(user);
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO model)
        {
            try
            {
                await _userService.Register(model);
                return Ok(new { message = "Registration successful" });
            }
            catch (UserException ex)
            {
                return BadRequest(new { message = ex.Message, username = ex.Username });
            }
        }
    }
}
