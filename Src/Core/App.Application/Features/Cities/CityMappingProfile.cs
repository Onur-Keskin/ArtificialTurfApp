using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Delete;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;
using App.Application.Features.Users.Dto;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Cities
{
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CreateCityRequest, City>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName.ToLowerInvariant()));
            CreateMap<UpdateCityRequest, City>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName.ToLowerInvariant()));
            CreateMap<DeleteCityRequest, City>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<City, CityWithTownsDto>().ReverseMap();
        }
    }
}
