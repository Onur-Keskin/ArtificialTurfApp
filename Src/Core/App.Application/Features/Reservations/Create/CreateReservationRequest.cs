namespace App.Application.Features.Reservations.Create;
public record CreateReservationRequest
    (string Name,int UserId, bool IsCancel,int FieldSituationId);

