using App.Application.Features.Towns.Dto;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;

namespace App.Application.Features.Users
{
    public interface IUserService
    {
        Task<ServiceResult<UserDto>> GetByUsernameAsync(string username);
        Task<ServiceResult<UserDto>> GetUserByEmailAsync(string email);
        Task<ServiceResult<UserDto>> GetUserByIdAsync(int id);
        Task<ServiceResult<List<UserDto>>> GetAllUsersAsync();
        Task<ServiceResult<UserWithReservationsDto>> GetUserWithReservations(int id);
        Task<ServiceResult<CreateUserResponse>> AddUserAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request);
        Task<ServiceResult> DeleteUserAsync(DeleteUserRequest request);
    }
}
