using App.Application.Features.Users;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class UserController(IUserService userService) : CustomBaseController
    {
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => CreateActionResult(await userService.GetAllUsersAsync());
        
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        => CreateActionResult(await userService.GetUserByIdAsync(id));

        [HttpGet("{id:int}/reservations")]
        public async Task<IActionResult> GetUserWithReservations(int id)
            => CreateActionResult(await userService.GetUserWithReservations(id));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
            => CreateActionResult(await userService.AddUserAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        => CreateActionResult(await userService.UpdateUserAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
            => CreateActionResult(await userService.DeleteUserAsync(request));

    }
}
