using App.Application.Contracts.Persistence;
using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Dto;
using App.Application.Features.FootballFieds.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.FootballFieds
{
    public class FootballFieldService(IFootballFieldRepository footballFieldRepository, IUnitOfWork unitOfWork, IMapper mapper) : IFootballFieldService
    {
        public async Task<ServiceResult<CreateFootballFieldResponse>> AddFieldAsync(CreateFootballFieldRequest request)
        {
            #region async manuel service business check
            var anyFootballFiledName = await footballFieldRepository.AnyAsync(x => x.Name == request.Name);

            if (anyFootballFiledName)
            {
                return ServiceResult<CreateFootballFieldResponse>.Fail("Saha ismi veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }
            #endregion

            var footballField = mapper.Map<FootballField>(request);

            await footballFieldRepository.AddAsync(footballField);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateFootballFieldResponse>.SuccessAsCreated(new CreateFootballFieldResponse(footballField.Id), $"api/footballFields/{footballField.Id}");
        }

        public async Task<ServiceResult> DeleteFieldAsync(DeleteFootballFieldRequest request)
        {
            var footballField = await footballFieldRepository.GetByIdAsync(request.Id);

            if (footballField is null)
            {
                return ServiceResult.Fail("Saha veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            footballFieldRepository.Delete(footballField!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<FootballFieldDto>>> GetAllFieldsAsync()
        {
            var footballFields = await footballFieldRepository.GetAllAsync();

            if (footballFields is null)
            {
                return ServiceResult<List<FootballFieldDto?>>.Fail("Saha bulunamadı");
            }

            var footballFieldsAsDto = mapper.Map<List<FootballFieldDto>>(footballFields);

            return ServiceResult<List<FootballFieldDto>>.Success(footballFieldsAsDto);
        }

        public async Task<ServiceResult<FootballFieldDto>> GetFieldByIdAsync(int id)
        {
            var footballField = await footballFieldRepository.GetByIdAsync(id);

            if (footballField is null)
            {
                return ServiceResult<FootballFieldDto?>.Fail("Football field not found", HttpStatusCode.NotFound);
            }

            var footballFieldAsDto = mapper.Map<FootballFieldDto>(footballField);

            return ServiceResult<FootballFieldDto>.Success(footballFieldAsDto)!;
        }

        public async Task<ServiceResult<FootballFieldWithSituationsDto>> GetFieldWithSituationsAsync(int id)
        {
            var footballField = await footballFieldRepository.GetFootballFieldWithSituations(id);

            var footballFieldWithSituationsAsDto = mapper.Map<FootballFieldWithSituationsDto>(footballField);

            return ServiceResult<FootballFieldWithSituationsDto>.Success(footballFieldWithSituationsAsDto);
        }

        public async Task<ServiceResult> UpdateFieldAsync(UpdateFootbaalFieldRequest request)
        {
            var isFieldNameExist = await footballFieldRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id);

            if (isFieldNameExist)
            {
                return ServiceResult.Fail("Saha ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var footballField = mapper.Map<FootballField>(request);

            footballField.Id = request.Id;

            footballFieldRepository.Update(footballField);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
