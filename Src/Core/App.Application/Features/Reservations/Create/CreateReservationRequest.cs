namespace App.Application.Features.Reservations.Create;
public record CreateReservationRequest
    (string Name,int FieldId,int UserId,DateTime StartDate,DateTime EndDate,decimal TotalPrice);

