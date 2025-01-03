using AutoMapper;

namespace App.Application.Features.Users.Register
{
    public class RegisterProfileMapping : Profile
    {
        public RegisterProfileMapping()
        {
            CreateMap<RegisterRequest, Domain.Entities.User>();
        }
    }
}
