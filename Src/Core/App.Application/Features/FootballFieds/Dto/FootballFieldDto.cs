namespace App.Application.Features.FootballFieds.Dto;
public record FootballFieldDto
    (int Id,string Name,decimal PricePerHour,bool IsAvailable,int TownId,int CityId);

