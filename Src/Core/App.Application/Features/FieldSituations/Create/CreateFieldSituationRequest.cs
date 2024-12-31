namespace App.Application.Features.FieldSituations.Create;
public record CreateFieldSituationRequest
    (int FootballFieldId, DateTime StartTime, DateTime EndTime, bool IsReserv, int ReservationId);

