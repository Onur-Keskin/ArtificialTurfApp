using App.Application.Contracts.Persistence;
using App.Application.Features.Reservations.Create;
using App.Application.Features.Reservations.Delete;
using App.Application.Features.Reservations.Dto;
using App.Application.Features.Reservations.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Reservations
{
    public class ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork, IMapper mapper) : IReservationService
    {
        public async Task<ServiceResult<CreateReservationResponse>> AddReservationAsync(CreateReservationRequest request)
        {
            #region async manuel service business check
            var anyReservationName= await reservationRepository.AnyAsync(x => x.Name == request.Name);

            if (anyReservationName)
            {
                return ServiceResult<CreateReservationResponse>.Fail("Rezervasyon ismi veritabanında bulunmaktadır.", HttpStatusCode.NotFound);
            }
            #endregion

            var reservation = mapper.Map<Reservation>(request);

            await reservationRepository.AddAsync(reservation);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateReservationResponse>.SuccessAsCreated(new CreateReservationResponse(reservation.Id), $"api/reservations/{reservation.Id}");
        }

        public async Task<ServiceResult> DeleteFieldAsync(DeleteReservationRequest request)
        {
            var reservation = await reservationRepository.GetByIdAsync(request.Id);

            if (reservation is null)
            {
                return ServiceResult.Fail("Rezervasyon veritabanında bulunamadı", HttpStatusCode.NotFound);
            }

            reservationRepository.Delete(reservation!);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<ReservationDto>>> GetAllReservationsAsync()
        {
            var reservations = await reservationRepository.GetAllAsync();

            if (reservations is null)
            {
                return ServiceResult<List<ReservationDto?>>.Fail("Rezervasyonlar bulunamadı");
            }

            var reservationsAsDto = mapper.Map<List<ReservationDto>>(reservations);

            return ServiceResult<List<ReservationDto>>.Success(reservationsAsDto);
        }

        public async Task<ServiceResult<ReservationDto>> GetReservationByIdAsync(int id)
        {
            var reservation = await reservationRepository.GetByIdAsync(id);

            if (reservation is null)
            {
                return ServiceResult<ReservationDto?>.Fail("Rezervasyon bulunamadı", HttpStatusCode.NotFound);
            }

            var reservationAsDto = mapper.Map<ReservationDto>(reservation);

            return ServiceResult<ReservationDto>.Success(reservationAsDto)!;
        }

        public async Task<ServiceResult<ReservationDto>> GetReservationsByUserId(int userId)
        {
            var reservation = await reservationRepository.GetByIdAsync(userId);

            if (reservation is null)
            {
                return ServiceResult<ReservationDto?>.Fail("Kullanıcıya ait rezervasyon bulunamadı", HttpStatusCode.NotFound);
            }

            var reservationAsDto = mapper.Map<ReservationDto>(reservation);

            return ServiceResult<ReservationDto>.Success(reservationAsDto)!;
        }

        public async Task<ServiceResult> UpdateFieldAsync(UpdateReservationRequest request)
        {
            var isReservationNameExist = await reservationRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id);

            if (isReservationNameExist)
            {
                return ServiceResult.Fail("Rezervasyon ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);
            }

            var reservation = mapper.Map<Reservation>(request);

            reservationRepository.Update(reservation);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
