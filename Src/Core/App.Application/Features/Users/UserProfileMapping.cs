using App.Application.Features.Users.Create;
using App.Application.Features.Users.Delete;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Users
{
    public class UserProfileMapping:Profile
    {
        public UserProfileMapping()
        {
            //CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, UserDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                    .ReverseMap();

            CreateMap<CreateUserRequest, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateUserRequest, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<DeleteUserRequest, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, UserWithReservationsDto>().ReverseMap();
        }
    }
}
