using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Towns
{
    public class TownRepository(AppDbContext context) : GenericRepository<Town, int>(context), ITownRepository
    {
        public List<Town> GetTownsByCityId(int cityId)
        {
            return context.Towns.Where(t => t.CityId == cityId).ToList();
        }
    }
}
