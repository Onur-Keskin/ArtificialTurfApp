using App.Application.Features.Towns;
using App.Application.Features.Towns.Create;
using App.Application.Features.Towns.Delete;
using App.Application.Features.Towns.Update;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id:int}/business")]
        public async Task<IActionResult> GetTownWithBusinesses(int id)
            => CreateActionResult(await townService.GetTownWithBusinessesAsync(id));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateTown(CreateTownRequest request)
            => CreateActionResult(await townService.AddTownAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateTown(UpdateTownRequest request)
        => CreateActionResult(await townService.UpdateTownAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTown(DeleteTownRequest request)
            => CreateActionResult(await townService.DeleteTownAsync(request));

    }
}
