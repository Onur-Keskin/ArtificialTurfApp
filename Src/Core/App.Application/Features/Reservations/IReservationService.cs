using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Dto;
using App.Application.Features.Reservations.Update;

namespace App.Application.Features.Reservations
{
    public interface IReservationService
    {
        Task<ServiceResult<List<ReservationDto>>> GetAllReservationsAsync();
        Task<ServiceResult<ReservationDto>> GetReservationByIdAsync(int id);
        Task<ServiceResult<ReservationDto>> GetReservationsByUserId(int userId);
        Task<ServiceResult<CreateReservationResponse>> AddReservationAsync(CreateReservationRequest request);
        Task<ServiceResult> UpdateFieldAsync(UpdateReservationRequest request);
        Task<ServiceResult> DeleteFieldAsync(DeleteReservationRequest request);
    }
}
