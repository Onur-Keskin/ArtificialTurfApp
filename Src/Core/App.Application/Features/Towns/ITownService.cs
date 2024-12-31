using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Dto;
using App.Application.Features.Reservations.Update;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Dto;
using App.Application.Features.Towns.Update;

namespace App.Application.Features.Towns
{
    public interface ITownService
    {
        Task<ServiceResult<List<TownDto>>> GetAllTownsAsync();
        Task<ServiceResult<TownDto>> GetTownByIdAsync(int id);
        Task<ServiceResult<TownWithBusinessesDto>> GetTownWithBusinessesAsync(int id);
        Task<ServiceResult<CreateTownResponse>> AddTownAsync(CreateTownRequest request);
        Task<ServiceResult> UpdateTownAsync(UpdateTownRequest request);
        Task<ServiceResult> DeleteTownAsync(DeleteTownRequest request);
    }
}
