using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Delete;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;

namespace App.Application.Features.Cities
{
    public interface ICityService
    {
        Task<ServiceResult<List<CityDto>>> GetAllCitiesAsync();
        Task<ServiceResult<CityDto>> GetCityByIdAsync(int id);
        Task<ServiceResult<CityWithTownsDto>> GetCityWithTownsAsync(int id);
        Task<ServiceResult<CreateCityResponse>> AddCityAsync(CreateCityRequest request);
        Task<ServiceResult> UpdateCityAsync(UpdateCityRequest request);
        Task<ServiceResult> DeleteCityAsync(DeleteCityRequest request);
    }
}
