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
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationRequest, Reservation>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateReservationRequest, Reservation>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<DeleteReservationRequest, Reservation>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
