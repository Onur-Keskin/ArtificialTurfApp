using App.Application.Features.FieldSituations.Create;
using App.Application.Features.FieldSituations.Delete;
using App.Application.Features.FieldSituations.Dto;
using App.Application.Features.FieldSituations.Update;

namespace App.Application.Features.FieldSituations
{
    public interface IFieldSituationService
    {
        Task<ServiceResult<List<FieldSituationDto>>> GetAllFieldSituationAsync();
        Task<ServiceResult<FieldSituationDto>> GetFieldSituationByIdAsync(int id);
        Task<ServiceResult<CreateFieldSituationResponse>> AddFieldSituationAsync(CreateFieldSituationRequest request);
        Task<ServiceResult> UpdateFieldSituationAsync(UpdateFieldSituationRequest request);
        Task<ServiceResult> UpdateFieldSituationReserveAsync(UpdateFieldSituationReservRequest request);
        Task<ServiceResult> DeleteFieldSituationAsync(DeleteFieldSituationRequest request);
    }
}
