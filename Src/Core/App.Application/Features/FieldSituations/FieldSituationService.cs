using App.Application.Contracts.Persistence;
using App.Application.Features.FieldSituations.Create;
using App.Application.Features.FieldSituations.Delete;
using App.Application.Features.FieldSituations.Dto;
using App.Application.Features.FieldSituations.Update;
using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Dto;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.FieldSituations
{
    public class FieldSituationService(IFieldSituationRepository fieldSituationRepository, IUnitOfWork unitOfWork, IMapper mapper) : IFieldSituationService
    {
        public async Task<ServiceResult<CreateFieldSituationResponse>> AddFieldSituationAsync(CreateFieldSituationRequest request)
        {
            var anyFieldSituationDate= await fieldSituationRepository.AnyAsync(x => x.FootballFieldId == request.FootballFieldId  && (x.StartTime == request.StartTime || x.EndTime == request.EndTime));

            if (anyFieldSituationDate)
            {
                return ServiceResult<CreateFieldSituationResponse>.Fail("Bu sahanın mevcut durumu veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }

            var fieldSituation = mapper.Map<FieldSituation>(request);

            await fieldSituationRepository.AddAsync(fieldSituation);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateFieldSituationResponse>.SuccessAsCreated(new CreateFieldSituationResponse(fieldSituation.Id), $"api/fieldSituations/{fieldSituation.Id}");
        }

        public async Task<ServiceResult> DeleteFieldSituationAsync(DeleteFieldSituationRequest request)
        {
            var fieldSituation = await fieldSituationRepository.GetByIdAsync(request.Id);

            if (fieldSituation is null)
            {
                return ServiceResult.Fail("Saha durumu veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            fieldSituationRepository.Delete(fieldSituation!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<FieldSituationDto>>> GetAllFieldSituationAsync()
        {
            var fieldSituations = await fieldSituationRepository.GetAllAsync();

            if (fieldSituations is null)
            {
                return ServiceResult<List<FieldSituationDto?>>.Fail("Saha durumu bulunamadı");
            }

            var fieldSituationsAsDto = mapper.Map<List<FieldSituationDto>>(fieldSituations);

            return ServiceResult<List<FieldSituationDto>>.Success(fieldSituationsAsDto);
        }

        public async Task<ServiceResult<FieldSituationDto>> GetFieldSituationByIdAsync(int id)
        {
            var fieldSituation = await fieldSituationRepository.GetByIdAsync(id);

            if (fieldSituation is null)
            {
                return ServiceResult<FieldSituationDto?>.Fail("Saha durumu bulunamadı", HttpStatusCode.NotFound);
            }

            var fieldSituationAsDto = mapper.Map<FieldSituationDto>(fieldSituation);

            return ServiceResult<FieldSituationDto>.Success(fieldSituationAsDto)!;
        }

        public async Task<ServiceResult> UpdateFieldSituationAsync(UpdateFieldSituationRequest request)
        {
            var anyFieldSituationDateExist = await fieldSituationRepository.AnyAsync(x => x.FootballFieldId == request.FootballFieldId && (x.StartTime == request.StartTime || x.EndTime == request.EndTime));

            if (anyFieldSituationDateExist)
            {
                return ServiceResult.Fail("Bu sahanın mevcut durumu veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }

            var fieldSituation = mapper.Map<FieldSituation>(request);

            fieldSituation.Id = request.Id;

            fieldSituationRepository.Update(fieldSituation);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateFieldSituationReserveAsync(UpdateFieldSituationReservRequest request)
        {
            var fieldSituationExist = await fieldSituationRepository.GetByIdAsync(request.Id);

            if (fieldSituationExist is not null && fieldSituationExist.IsReserv == true)
            {
                return ServiceResult.Fail("Bu saha zaten rezerve ... ", HttpStatusCode.NotFound);
            }

            var fieldSituation = mapper.Map<FieldSituation>(fieldSituationExist);

            fieldSituation.Id = request.Id;

            fieldSituationRepository.Update(fieldSituation);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
