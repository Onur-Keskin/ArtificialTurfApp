using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Dto;
using App.Application.Features.Reservations.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Reservations
{
    public class ReservationMappingProfile:Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reservation, ReservationDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartTime))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndTime))
                    .ForMember(dest => dest.HourDuration, opt => opt.MapFrom(src => src.HourDuration));

            CreateMap<CreateReservationRequest, Reservation>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateReservationRequest, Reservation>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<DeleteReservationRequest, Reservation>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
