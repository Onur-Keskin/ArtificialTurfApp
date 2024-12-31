namespace App.Application.Features.FieldSituations.Update;
public record UpdateFieldSituationRequest
    (int Id, int FootballFieldId, DateTime StartTime, DateTime EndTime, bool IsReserv, int ReservationId);
