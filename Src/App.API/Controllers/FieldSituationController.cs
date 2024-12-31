using App.Application.Features.FieldSituations;
using App.Application.Features.FieldSituations.Create;
using App.Application.Features.FieldSituations.Delete;
using App.Application.Features.FieldSituations.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class FieldSituationController(IFieldSituationService fieldSituationService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFieldSituations()
            => CreateActionResult(await fieldSituationService.GetAllFieldSituationAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFieldSituationById(int id)
        => CreateActionResult(await fieldSituationService.GetFieldSituationByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateFieldSituation(CreateFieldSituationRequest request)
        => CreateActionResult(await fieldSituationService.AddFieldSituationAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateFieldSituation(UpdateFieldSituationRequest request)
        => CreateActionResult(await fieldSituationService.UpdateFieldSituationAsync(request));
        
        [HttpPut("Reserv")]
        public async Task<IActionResult> UpdateFieldSituationReserv(UpdateFieldSituationReservRequest request)
        => CreateActionResult(await fieldSituationService.UpdateFieldSituationReserveAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteFieldSituation(DeleteFieldSituationRequest request)
            => CreateActionResult(await fieldSituationService.DeleteFieldSituationAsync(request));
    }
}
