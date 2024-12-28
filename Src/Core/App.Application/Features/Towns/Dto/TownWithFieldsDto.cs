using App.Application.Features.FootballFieds.Dto;

namespace App.Application.Features.Towns.Dto;
public record TownWithFieldsDto
    (int Id, string TownName, List<FootballFieldDto> FootballFields,int CityId);

