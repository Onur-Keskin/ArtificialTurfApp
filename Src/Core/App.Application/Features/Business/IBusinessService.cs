using App.Application.Features.Business.Create;
using App.Application.Features.Business.Delete;
using App.Application.Features.Business.Dto;
using App.Application.Features.Business.Update;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Dto;
using App.Application.Features.Towns.Update;

namespace App.Application.Features.Business
{
    public interface IBusinessService
    {
        Task<ServiceResult<List<BusinessDto>>> GetAllBusinessAsync();
        Task<ServiceResult<BusinessDto>> GetBusinessByIdAsync(int id);
        Task<ServiceResult<BusinessWithFieldsDto>> GetBusinessWithFieldsAsync(int id);
        Task<ServiceResult<CreateBusinessResponse>> AddBusinessAsync(CreateBusinessRequest request);
        Task<ServiceResult> UpdateBusinessAsync(UpdateBussinessRequest request);
        Task<ServiceResult> DeleteBusinessAsync(DeleteBusinessRequest request);
    }
}
