namespace App.Application.Features.Reservations.Dto;
public record ReservationDto
    (string Name,int Id,int FieldId,int UserId,DateTime StartDate,DateTime EndDate,decimal TotalPrice);

