using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IFootballFieldRepository:IGenericRepository<FootballField,int>
    {
        Task<FootballField?> GetFootballFieldWithSituations(int footballFieldId);
    }
}
