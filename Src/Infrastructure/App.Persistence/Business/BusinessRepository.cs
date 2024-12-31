using App.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Business
{
    public class BusinessRepository(AppDbContext context) : GenericRepository<Domain.Entities.Business, int>(context), IBusinessRepository
    {
        public Task<Domain.Entities.Business> GetBusinessWithFields(int businessId)
        {
            return context.Businesses.Include(x => x.FootballFields).FirstOrDefaultAsync(x => x.Id == businessId);
        }
    }
}
