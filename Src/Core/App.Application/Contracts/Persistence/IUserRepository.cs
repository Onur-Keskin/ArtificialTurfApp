using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IUserRepository:IGenericRepository<User,int>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetUserByEmail(string email);
    }
}
