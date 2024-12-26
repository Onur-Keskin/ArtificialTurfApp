using App.Application.Features.Towns.Dto;

namespace App.Application.Features.Cities.Dto;
public record CityWithTownsDto(int Id,string Name, List<TownDto> Towns);
