using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IBusinessRepository : IGenericRepository<Business, int>
    {
        Task<Business> GetBusinessWithFields(int businessId);
    }
}
