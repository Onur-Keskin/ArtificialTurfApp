using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.FootballFields
{
    public class FootballFieldRepository(AppDbContext context) : GenericRepository<FootballField, int>(context), IFootballFieldRepository
    {
        public Task<FootballField?> GetFootballFieldWithSituations(int footballFieldId)
        {
            return context.FootballFields.Include(x => x.FieldSituations).FirstOrDefaultAsync(x => x.Id == footballFieldId);
        }
    }
}
