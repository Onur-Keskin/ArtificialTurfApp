using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Towns
{
    public class TownRepository(AppDbContext context) : GenericRepository<Town, int>(context), ITownRepository
    {
        public List<Town> GetTownsByCityId(int cityId)
        {
            return context.Towns.Where(t => t.CityId == cityId).ToList();
        }

        public Task<Town?> GetTownWithFields(int townId)
        {
            return context.Towns.Include(x=>x.FootballFields).FirstOrDefaultAsync(x => x.Id == townId);
        }
    }
}
