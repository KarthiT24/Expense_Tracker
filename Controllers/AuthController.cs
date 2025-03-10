using Expense_Tracker.Models.DTOs;
using Expense_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var result = await _userService.LoginUser(userLoginDTO);
            if (result != null)
            {
                return Ok(new { token = result });
            }
            return Unauthorized("Invalid Credentials");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var result = await _userService.SignUpUser(userRegisterDTO);
            if (result)
            {
                return Ok("User Registered Successfully");
            }
            return BadRequest("User Registration Failed");
        }
    }
}
