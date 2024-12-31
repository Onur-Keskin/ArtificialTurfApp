namespace App.Application.Features.FieldSituations.Dto;
public record FieldSituationDto
    (int Id,int FootballFieldId,DateTime StartTime,DateTime EndTime,bool IsReserv,int ReservationId);

