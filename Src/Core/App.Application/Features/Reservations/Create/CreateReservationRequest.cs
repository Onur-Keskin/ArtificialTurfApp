namespace App.Application.Features.Reservations.Create;
public record CreateReservationRequest
    (string Name,int FootballFieldId, int UserId,DateTime StartDate,DateTime EndDate,int HourDuration);

