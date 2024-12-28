using App.Application.Features.Towns.Dto;

namespace App.Application.Features.Cities.Dto;
public record CityWithTownsDto(int Id,string CityName,int CityPlateNumber,List<TownDto> Towns);
