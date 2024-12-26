using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Update;
using App.Domain.Entities;

namespace App.Application.Features.Users
{
    public interface IUserService
    {
        Task<ServiceResult<User>> GetByUsernameAsync(string username);
        Task<ServiceResult<User>> GetUserByEmailAsync(string email);
        Task<ServiceResult> AddUserAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request);
        Task<ServiceResult> DeleteUserAsync(DeleteUserRequest request);
    }
}
