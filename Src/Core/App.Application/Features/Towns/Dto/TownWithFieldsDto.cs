using App.Application.Features.FootballFieds.Dto;

namespace App.Application.Features.Towns.Dto;
public record TownWithFieldsDto
    (int Id, string Name, List<FootballFieldDto> FootballFields,int CityId);

