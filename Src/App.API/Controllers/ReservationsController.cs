using App.Application.Features.Reservations;
using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Update;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetByReservationByUser([FromQuery]GetReservationsByUserIdRequest request)
            => CreateActionResult(await reservationService.GetReservationsByUserId(request));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequest request)
            => CreateActionResult(await reservationService.AddReservationAsync(request));

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationRequest request)
            => CreateActionResult(await reservationService.UpdateReservationAsync(request));

        [Authorize]
        [HttpPut("cancelReservation")]
        public async Task<IActionResult> CanelReservation(CancelReservationRequest request)
            => CreateActionResult(await reservationService.CancelReservationAsync(request));

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(DeleteReservationRequest request)
            => CreateActionResult(await reservationService.DeleteReservationAsync(request));
    }
}
