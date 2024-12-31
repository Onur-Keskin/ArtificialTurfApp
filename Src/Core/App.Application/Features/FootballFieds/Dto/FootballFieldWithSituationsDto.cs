using App.Application.Features.FieldSituations.Dto;

namespace App.Application.Features.FootballFieds.Dto;
public record FootballFieldWithSituationsDto
    (int Id,string Name,int HourlyPricePerPerson,int BusinessId,List<FieldSituationDto> FieldSituations);
