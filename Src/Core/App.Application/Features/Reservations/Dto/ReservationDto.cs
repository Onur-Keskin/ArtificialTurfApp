namespace App.Application.Features.Reservations.Dto;
public record ReservationDto
    (int Id, string Name, int UserId,bool IsCancel, int FieldSituationId);

