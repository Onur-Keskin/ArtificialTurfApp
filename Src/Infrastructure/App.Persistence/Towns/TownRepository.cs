using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Towns
{
    public class TownRepository(AppDbContext context) : GenericRepository<Town, int>(context), ITownRepository
    {
        public Task<Town?> GetTownWithBusinesses(int townId)
        {
            return context.Towns.Include(x=>x.Businesses).FirstOrDefaultAsync(x => x.Id == townId);
        }
    }
}
