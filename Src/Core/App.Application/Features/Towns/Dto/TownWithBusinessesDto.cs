using App.Application.Features.Business.Dto;

namespace App.Application.Features.Towns.Dto;
public record TownWithBusinessesDto
    (int Id, string TownName, List<BusinessDto> Businesses,int CityId);

