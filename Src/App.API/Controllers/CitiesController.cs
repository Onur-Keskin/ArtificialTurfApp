using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Delete;
using App.Application.Features.Cities.Update;
using App.Application.Features.Cities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace App.API.Controllers
{
    public class CitiesController(ICityService cityService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCities()
            => CreateActionResult(await cityService.GetAllCitiesAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCityById(int id)
        => CreateActionResult(await cityService.GetCityByIdAsync(id));

        [HttpGet("{id:int}/towns")]
        public async Task<IActionResult> GetCityWithTowns(int id)
            => CreateActionResult(await cityService.GetCityWithTownsAsync(id));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityRequest request)
            => CreateActionResult(await cityService.AddCityAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCity(UpdateCityRequest request)
        => CreateActionResult(await cityService.UpdateCityAsync(request));

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCity(DeleteCityRequest request)
            => CreateActionResult(await cityService.DeleteCityAsync(request));

    }

}
