using App.Application.Contracts.Persistence;
using App.Application.Features.Business.Create;
using App.Application.Features.Business.Delete;
using App.Application.Features.Business.Dto;
using App.Application.Features.Business.Update;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Business
{
    public class BusinessService(IBusinessRepository businessRepository, IUnitOfWork unitOfWork, IMapper mapper) : IBusinessService
    {
        public async Task<ServiceResult<CreateBusinessResponse>> AddBusinessAsync(CreateBusinessRequest request)
        {
            var business = mapper.Map<Domain.Entities.Business>(request);

            await businessRepository.AddAsync(business);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateBusinessResponse>.SuccessAsCreated(new CreateBusinessResponse(business.Id), $"api/business/{business.Id}");
        }

        public async Task<ServiceResult> DeleteBusinessAsync(DeleteBusinessRequest request)
        {
            var business = await businessRepository.GetByIdAsync(request.Id);

            if (business is null)
            {
                return ServiceResult.Fail("İşletme veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            businessRepository.Delete(business!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<BusinessDto>>> GetAllBusinessAsync()
        {
            var business = await businessRepository.GetAllAsync();

            if (business is null)
            {
                return ServiceResult<List<BusinessDto?>>.Fail("İşletmeler bulunamadı ... ", HttpStatusCode.NotFound);
            }

            var businessAsDto = mapper.Map<List<BusinessDto>>(business);

            return ServiceResult<List<BusinessDto>>.Success(businessAsDto);
        }

        public async Task<ServiceResult<BusinessDto>> GetBusinessByIdAsync(int id)
        {
            var business = await businessRepository.GetByIdAsync(id);

            if (business is null)
            {
                return ServiceResult<BusinessDto?>.Fail("İşletme bulunamadı", HttpStatusCode.NotFound);
            }

            var businessAsDto = mapper.Map<BusinessDto>(business);

            return ServiceResult<BusinessDto>.Success(businessAsDto)!;
        }

        public async Task<ServiceResult<BusinessWithFieldsDto>> GetBusinessWithFieldsAsync(int id)
        {
            var business = await businessRepository.GetBusinessWithFields(id);

            var businessAsDto = mapper.Map<BusinessWithFieldsDto>(business);

            return ServiceResult<BusinessWithFieldsDto>.Success(businessAsDto);
        }

        public async Task<ServiceResult> UpdateBusinessAsync(UpdateBussinessRequest request)
        {
            var isBusinessNameExist = await businessRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id);

            if (isBusinessNameExist)
            {
                return ServiceResult.Fail("İşletme ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var business = mapper.Map<Domain.Entities.Business>(request);

            businessRepository.Update(business);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
