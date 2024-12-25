using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.FootballFields
{
    public class FootballFieldRepository(AppDbContext context): GenericRepository<FootballField,int>(context),IFootballFieldRepository
    {
    }
}
