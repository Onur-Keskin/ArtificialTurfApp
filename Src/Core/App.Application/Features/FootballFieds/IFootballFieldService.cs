using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Dto;
using App.Application.Features.FootballFieds.Update;

namespace App.Application.Features.FootballFieds
{
    public interface IFootballFieldService
    {
        Task<ServiceResult<List<FootballFieldDto>>> GetAllFieldsAsync();
        Task<ServiceResult<FootballFieldDto>> GetFieldByIdAsync(int id);
        Task<ServiceResult<CreateFootballFieldResponse>> AddFieldAsync(CreateFootballFieldRequest request);
        Task<ServiceResult> UpdateFieldAsync(UpdateFootbaalFieldRequest request);
        Task<ServiceResult> DeleteFieldAsync(DeleteFootballFieldRequest request);
    }
}
