using App.Application.Contracts.Persistence;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        public async Task<ServiceResult<CreateUserResponse>> AddUserAsync(CreateUserRequest request)
        {
            #region async manuel service business check
            var anyUserName = await userRepository.AnyAsync(x => x.Name == request.Name);

            if (anyUserName)
            {
                return ServiceResult<CreateUserResponse>.Fail("Kullanıcı ismi veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }
            #endregion

            var user = mapper.Map<User>(request);

            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateUserResponse>.SuccessAsCreated(new CreateUserResponse(user.Id), $"api/towns/{user.Id}");
        }

        public async Task<ServiceResult> DeleteUserAsync(DeleteUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return ServiceResult.Fail("Kullanıcı veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            userRepository.Delete(user!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            if (users is null)
            {
                return ServiceResult<List<UserDto?>>.Fail("Kullanıcılar bulunamadı");
            }

            var usersAsDto = mapper.Map<List<UserDto>>(users);

            return ServiceResult<List<UserDto>>.Success(usersAsDto);
        }

        public async Task<ServiceResult<UserDto>> GetByUsernameAsync(string username)
        {
            var user = await userRepository.GetByUsername(username);

            if (user is null)
            {
                return ServiceResult<UserDto?>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserDto>(user);

            return ServiceResult<UserDto>.Success(userAsDto)!;
        }

        public async Task<ServiceResult<UserDto>> GetUserByEmailAsync(string email)
        {
            var user = await userRepository.GetUserByEmail(email);

            if (user is null)
            {
                return ServiceResult<UserDto?>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserDto>(user);

            return ServiceResult<UserDto>.Success(userAsDto)!;
        }

        public async Task<ServiceResult<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user is null)
            {
                return ServiceResult<UserDto?>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserDto>(user);

            return ServiceResult<UserDto>.Success(userAsDto)!;
        }

        public async Task<ServiceResult<UserWithReservationsDto>> GetUserWithReservations(int id)
        {
            var user = await userRepository.GetUserWithReservations(id);

            var userWithReservationsAsDto = mapper.Map<UserWithReservationsDto>(user);

            return ServiceResult<UserWithReservationsDto>.Success(userWithReservationsAsDto);
        }

        public async Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var isUserNameExist = await userRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id);

            if (isUserNameExist)
            {
                return ServiceResult.Fail("Kullanıcı ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var user = mapper.Map<User>(request);

            userRepository.Update(user);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
