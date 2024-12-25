using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Reservations
{
    public class ReservationRepository(AppDbContext context) : GenericRepository<Reservation, int>(context), IReservationRepository
    {
        public async Task<List<Reservation>> GetReservationsByUserId(int userId)
        {
            return await context.Reservations.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
