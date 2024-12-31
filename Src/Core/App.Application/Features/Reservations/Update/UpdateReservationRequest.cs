namespace App.Application.Features.Reservations.Update;
public record UpdateReservationRequest
    (int Id,string Name, int UserId,bool IsCanecl, int FieldSituationId);


