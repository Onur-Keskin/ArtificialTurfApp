namespace App.Application.Features.Business.Update;
public record UpdateBussinessRequest(int Id,string Name, string Address, int TownId, int CityId);
