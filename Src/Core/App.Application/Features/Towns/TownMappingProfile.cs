using App.Application.Features.Cities.Dto;
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
            CreateMap<Town, TownDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName))
                    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId)).ReverseMap();
            
            CreateMap<CreateTownRequest, Town>().ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName.ToLowerInvariant()));
            CreateMap<UpdateTownRequest, Town>().ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName.ToLowerInvariant()));
            CreateMap<DeleteTownRequest, Town>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Town, TownWithBusinessesDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.TownName, opt => opt.MapFrom(src => src.TownName))
                    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        }
    }
}
