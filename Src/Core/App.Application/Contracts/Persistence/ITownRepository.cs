using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ITownRepository : IGenericRepository<Town,int>
    {
        List<Town> GetTownsByCityId(int cityId);

        Task<Town?> GetTownWithFields(int townId);
    }
}
