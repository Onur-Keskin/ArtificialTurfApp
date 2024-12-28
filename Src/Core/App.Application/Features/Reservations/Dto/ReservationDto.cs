namespace App.Application.Features.Reservations.Dto;
public record ReservationDto
    (string Name,int Id,int FootballFieldId, int UserId,DateTime StartDate,DateTime EndDate,int HourDuration);

