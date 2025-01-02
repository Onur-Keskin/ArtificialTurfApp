using App.Application.Features.Business.Create;
using App.Application.Features.Business.Delete;
using App.Application.Features.Business.Dto;
using App.Application.Features.Business.Update;
using AutoMapper;

namespace App.Application.Features.Business
{
    public class BusinessMappingProfile:Profile
    {
        public BusinessMappingProfile()
        {
            //CreateMap<Domain.Entities.Business, BusinessDto>().ReverseMap();

            CreateMap<Domain.Entities.Business, BusinessDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ReverseMap();

            CreateMap<Domain.Entities.Business, BusinessWithFieldsDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateBusinessRequest, Domain.Entities.Business>();
            CreateMap<UpdateBussinessRequest, Domain.Entities.Business>();
            CreateMap<DeleteBusinessRequest, Domain.Entities.Business>();
        }
    }
}

