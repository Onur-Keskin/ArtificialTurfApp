using App.Application.Features.Users;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class UserController(IUserService userService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => CreateActionResult(await userService.GetAllUsersAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        => CreateActionResult(await userService.GetUserByIdAsync(id));

        [HttpGet("{id:int}/reservations")]
        public async Task<IActionResult> GetUserWithReservations(int id)
            => CreateActionResult(await userService.GetUserWithReservations(id));

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
            => CreateActionResult(await userService.AddUserAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        => CreateActionResult(await userService.UpdateUserAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
            => CreateActionResult(await userService.DeleteUserAsync(request));

    }
}
