using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.FieldSituations
{
    public class FieldSituationRepository(AppDbContext context) : GenericRepository<FieldSituation, int>(context), IFieldSituationRepository
    {
    }
}
