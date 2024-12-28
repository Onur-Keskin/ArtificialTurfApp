using App.Application.Features.Reservations;
using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class ReservationsController(IReservationService reservationService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetReservations()
            => CreateActionResult(await reservationService.GetAllReservationsAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByReservationById(int id)
            => CreateActionResult(await reservationService.GetReservationByIdAsync(id));

        [HttpGet("user")]
        public async Task<IActionResult> GetByReservationByUser(GetReservationsByUserIdRequest request)
            => CreateActionResult(await reservationService.GetReservationsByUserId(request));

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequest request)
            => CreateActionResult(await reservationService.AddReservationAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReservation(int id, UpdateReservationRequest request)
            => CreateActionResult(await reservationService.UpdateFieldAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id, DeleteReservationRequest request)
            => CreateActionResult(await reservationService.DeleteReservationAsync(request));
    }
}
