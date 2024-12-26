using App.Application.Contracts.Persistence;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Dto;
using App.Application.Features.Towns.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Towns
{
    public class TownService(ITownRepository townRepository, IUnitOfWork unitOfWork, IMapper mapper) : ITownService
    {
        public async Task<ServiceResult<CreateTownResponse>> AddTownAsync(CreateTownRequest request)
        {
            #region async manuel service business check
            var anyTownName = await townRepository.AnyAsync(x => x.TownName == request.TownName);

            if (anyTownName)
            {
                return ServiceResult<CreateTownResponse>.Fail("İlçe ismi veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }
            #endregion

            var town = mapper.Map<Town>(request);

            await townRepository.AddAsync(town);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateTownResponse>.SuccessAsCreated(new CreateTownResponse(town.Id), $"api/towns/{town.Id}");
        }

        public async Task<ServiceResult> DeleteTownAsync(DeleteTownRequest request)
        {
            var town = await townRepository.GetByIdAsync(request.Id);

            if (town is null)
            {
                return ServiceResult.Fail("İlçe veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            townRepository.Delete(town!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<TownDto>>> GetAllTownsAsync()
        {
            var towns = await townRepository.GetAllAsync();

            if (towns is null)
            {
                return ServiceResult<List<TownDto?>>.Fail("İlçeler bulunamadı");
            }

            var townsAsDto = mapper.Map<List<TownDto>>(towns);

            return ServiceResult<List<TownDto>>.Success(townsAsDto);
        }

        public async Task<ServiceResult<TownDto>> GetTownByIdAsync(int id)
        {
            var town = await townRepository.GetByIdAsync(id);

            if (town is null)
            {
                return ServiceResult<TownDto?>.Fail("İlçe bulunamadı", HttpStatusCode.NotFound);
            }

            var townAsDto = mapper.Map<TownDto>(town);

            return ServiceResult<TownDto>.Success(townAsDto)!;
        }
        public async Task<ServiceResult<TownWithFieldsDto>> GetTownWithFieldsAsync(int id)
        {
            var town = await townRepository.GetTownWithFields(id);

            var townWithFieldsAsDto = mapper.Map<TownWithFieldsDto>(town);

            return ServiceResult<TownWithFieldsDto>.Success(townWithFieldsAsDto);
        }

        public async Task<ServiceResult> UpdateTownAsync(UpdateTownRequest request)
        {
            var isTownNameExist = await townRepository.AnyAsync(x => x.TownName == request.TownName && x.Id != request.Id);

            if (isTownNameExist)
            {
                return ServiceResult.Fail("İlçe ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var town = mapper.Map<Town>(request);

            townRepository.Update(town);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
