using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Dto;
using App.Application.Features.FootballFieds.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.FootballFieds
{
    public class FootballFieldMappingProfile:Profile
    {
        public FootballFieldMappingProfile()
        {
            CreateMap<FootballField, FootballFieldDto>().ReverseMap();
            CreateMap<CreateFootballFieldRequest, FootballField>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateFootbaalFieldRequest, FootballField>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<DeleteFootballFieldRequest, FootballField>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
