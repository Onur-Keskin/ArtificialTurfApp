namespace App.Application.Features.Reservations.Update;
public record UpdateReservationRequest
    (int Id,string Name,int FieldId, int UserId, DateTime StartDate, DateTime EndDate, decimal TotalPrice);


