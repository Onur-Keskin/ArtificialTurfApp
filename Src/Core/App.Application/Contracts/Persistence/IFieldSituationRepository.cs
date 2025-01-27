using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IFieldSituationRepository : IGenericRepository<FieldSituation, int>
    {
        public Task<FieldSituation?> GetFieldSituationByDate(int id, DateTime date);
    }
}
