using App.Application.Features.FootballFieds;
using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class FootballFieldController(IFootballFieldService footballFieldService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFootballFields() 
            => CreateActionResult(await footballFieldService.GetAllFieldsAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFootballFieldById(int id) 
            => CreateActionResult(await footballFieldService.GetFieldByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateFootballField(CreateFootballFieldRequest request) 
            => CreateActionResult(await footballFieldService.AddFieldAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateFootballField(UpdateFootbaalFieldRequest request) 
            => CreateActionResult(await footballFieldService.UpdateFieldAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteFootballFieldById(DeleteFootballFieldRequest request)
            => CreateActionResult(await footballFieldService.DeleteFieldAsync(request));
    }
}
