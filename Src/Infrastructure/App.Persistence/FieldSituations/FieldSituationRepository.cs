using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.FieldSituations
{
    public class FieldSituationRepository(AppDbContext context) : GenericRepository<FieldSituation, int>(context), IFieldSituationRepository
    {
        public Task<FieldSituation?> GetFieldSituationByDate(int id,DateTime date)
        {
            return context.FieldSituations.FirstOrDefaultAsync(x=>x.Id == id && x.StartTime.Date.Equals(date.Date));
        }
    }
}
