namespace App.Application.Features.FootballFieds.Create;
public record CreateFootballFieldRequest
    (string Name,string Location,decimal PricePerHour,bool IsAvailable,int CityId,int TownId);

