using App.Application.Features.Users;
using App.Application.Features.Users.Login;
using App.Application.Features.Users.Register;
using App.Application.Features.Users.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class AuthController(IUserService userService) : CustomBaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
            => CreateActionResult(await userService.AuthenticateAsync(request));

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request) =>
            CreateActionResult(await userService.RegisterAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() =>
            CreateActionResult(await userService.GetAllUsersAsync());

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.Claims.FirstOrDefault()?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var user = await userService.GetUserByIdAsync(Convert.ToInt32(userId));

            return CreateActionResult(user);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var userId = User.Claims.FirstOrDefault()?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            //request.Id = Convert.ToInt32(userId);

            return CreateActionResult(await userService.UpdateUserAsync(request));
        }

    }
}
