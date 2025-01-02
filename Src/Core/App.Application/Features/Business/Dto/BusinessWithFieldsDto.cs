using App.Application.Features.FootballFieds.Dto;
using App.Domain.Entities;

namespace App.Application.Features.Business.Dto;
public record BusinessWithFieldsDto
    (int Id, string Name, string Address, int TownId,List<FootballFieldDto> FootballFields);

