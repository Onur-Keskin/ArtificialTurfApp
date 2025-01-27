using App.Application.Features.Reservations.Dto;

namespace App.Application.Features.Users.Dto;
public record UserWithReservationsDto
    (int Id, string Name, string Email, string MobilePhoneNumber, string Role,List<ReservationDto> Reservations);

