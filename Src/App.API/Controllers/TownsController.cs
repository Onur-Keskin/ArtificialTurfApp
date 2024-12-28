using App.Application.Features.Towns;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class TownsController(ITownService townService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTowns()
            => CreateActionResult(await townService.GetAllTownsAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTownById(int id)
        => CreateActionResult(await townService.GetTownByIdAsync(id));

        [HttpGet("{id:int}/fields")]
        public async Task<IActionResult> GetTownWithFields(int id)
            => CreateActionResult(await townService.GetTownWithFieldsAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateTown(CreateTownRequest request)
            => CreateActionResult(await townService.AddTownAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateTown(UpdateTownRequest request)
        => CreateActionResult(await townService.UpdateTownAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteTown(DeleteTownRequest request)
            => CreateActionResult(await townService.DeleteTownAsync(request));

    }
}
