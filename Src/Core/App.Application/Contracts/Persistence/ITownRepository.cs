using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ITownRepository : IGenericRepository<Town,int>
    {
        Task<Town?> GetTownWithBusinesses(int townId);
    }
}
