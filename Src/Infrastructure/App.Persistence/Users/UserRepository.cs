using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Users
{
    public class UserRepository(AppDbContext context) : GenericRepository<User, int>(context), IUserRepository
    {
        public async Task<User> GetByUsername(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Name == username);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
