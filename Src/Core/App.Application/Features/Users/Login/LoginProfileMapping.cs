using AutoMapper;

namespace App.Application.Features.Users.Login
{
    public class LoginProfileMapping : Profile
    {
        public LoginProfileMapping()
        {
            CreateMap<LoginRequest, Domain.Entities.User>().ReverseMap();
        }
    }
}
