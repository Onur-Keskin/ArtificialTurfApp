using App.Application.Contracts.Persistence;
using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Delete;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Dto;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Cities
{
    public class CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICityService
    {
        public async Task<ServiceResult<CreateCityResponse>> AddCityAsync(CreateCityRequest request)
        {
            #region async manuel service business check
            var anyCityName = await cityRepository.AnyAsync(x => x.CityName == request.CityName);

            if (anyCityName)
            {
                return ServiceResult<CreateCityResponse>.Fail("Şehir ismi veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }
            #endregion

            var city = mapper.Map<City>(request);

            await cityRepository.AddAsync(city);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateCityResponse>.SuccessAsCreated(new CreateCityResponse(city.Id), $"api/towns/{city.Id}");
        }

        public async Task<ServiceResult> DeleteCityAsync(DeleteCityRequest request)
        {
            var city = await cityRepository.GetByIdAsync(request.Id);

            if (city is null)
            {
                return ServiceResult.Fail("Şehir veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            cityRepository.Delete(city!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<CityDto>>> GetAllCitiesAsync()
        {
            var cities = await cityRepository.GetAllAsync();

            if (cities is null)
            {
                return ServiceResult<List<CityDto?>>.Fail("Şehirler bulunamadı");
            }

            var cityAsDto = mapper.Map<List<CityDto>>(cities);

            return ServiceResult<List<CityDto>>.Success(cityAsDto);
        }

        public async Task<ServiceResult<CityDto>> GetCityByIdAsync(int id)
        {
            var city = await cityRepository.GetByIdAsync(id);

            if (city is null)
            {
                return ServiceResult<CityDto?>.Fail("İlçe bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityDto>(city);

            return ServiceResult<CityDto>.Success(cityAsDto)!;
        }

        public async Task<ServiceResult<CityWithTownsDto>> GetCityWithTownsAsync(int id)
        {
            var city = await cityRepository.GetCityWithTowns(id);

            var cityWithTownsAsDto = mapper.Map<CityWithTownsDto>(city);

            return ServiceResult<CityWithTownsDto>.Success(cityWithTownsAsDto);
        }

        public async Task<ServiceResult> UpdateCityAsync(UpdateCityRequest request)
        {
            var isCityNameExist = await cityRepository.AnyAsync(x => x.CityName == request.CityName && x.Id != request.Id);

            if (isCityNameExist)
            {
                return ServiceResult.Fail("Şehir ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var city = mapper.Map<City>(request);

            cityRepository.Update(city);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
