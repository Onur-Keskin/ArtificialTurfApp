using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Cities
{
    public class CityRepository(AppDbContext context) : GenericRepository<City, int>(context), ICityRepository
    {
        public Task<City?> GetCityWithTowns(int cityId)
        {
            return context.Cities.Include(x => x.Towns).FirstOrDefaultAsync(x => x.Id == cityId);
        }
    }
}
