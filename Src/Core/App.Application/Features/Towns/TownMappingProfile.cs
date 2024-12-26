using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Dto;
using App.Application.Features.Towns.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Towns
{
    public class TownMappingProfile:Profile
    {
        public TownMappingProfile()
        {
            CreateMap<Town, TownDto>().ReverseMap();
            CreateMap<CreateTownRequest, Town>().ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName.ToLowerInvariant()));
            CreateMap<UpdateTownRequest, Town>().ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName.ToLowerInvariant()));
            CreateMap<DeleteTownRequest, Town>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
