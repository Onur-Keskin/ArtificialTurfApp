using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ICityRepository:IGenericRepository<City,int>
    {
        Task<City?> GetCityWithTowns(int cityId);
    }
}
