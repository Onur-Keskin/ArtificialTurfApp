using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IReservationRepository:IGenericRepository<Reservation,int>
    {
        Task<List<Reservation>> GetReservationsByUserId(int userId);
    }
}
