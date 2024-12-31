using App.Application.Features.FieldSituations.Create;
using App.Application.Features.FieldSituations.Delete;
using App.Application.Features.FieldSituations.Dto;
using App.Application.Features.FieldSituations.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.FieldSituations
{
    public class FieldSituationMappingProfile:Profile
    {
        public FieldSituationMappingProfile()
        {
            CreateMap<FieldSituation, FieldSituationDto>().ReverseMap();
            //CreateMap<FieldSituation, FieldSituationDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //        .ForMember(dest => dest.FootballFieldId, opt => opt.MapFrom(src => src.FootballFieldId))
            //        .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            //        .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
            //        .ForMember(dest => dest.IsReserv, opt => opt.MapFrom(src => src.IsReserv))
            //        .ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.ReservationId)).ReverseMap();

            CreateMap<CreateFieldSituationRequest, FieldSituation>();
            CreateMap<UpdateFieldSituationRequest, FieldSituation>();
            CreateMap<DeleteFieldSituationRequest, FieldSituation>();
        }
    }
}
