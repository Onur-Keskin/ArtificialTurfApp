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
            CreateMap<FootballField, FootballFieldDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.PricePerHour, opt => opt.MapFrom(src => src.PricePerHour))
                    .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                    .ForMember(dest => dest.TownId, opt => opt.MapFrom(src => src.TownId)).ReverseMap();

            CreateMap<CreateFootballFieldRequest, FootballField>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateFootbaalFieldRequest, FootballField>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<DeleteFootballFieldRequest, FootballField>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
