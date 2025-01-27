using App.Application.Features.FootballFieds;
using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Update;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id:int}/fieldSituations")]
        public async Task<IActionResult> GetFieldWithSituations(int id)
            => CreateActionResult(await footballFieldService.GetFieldWithSituationsAsync(id));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFootballField(CreateFootballFieldRequest request) 
            => CreateActionResult(await footballFieldService.AddFieldAsync(request));

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateFootballField(UpdateFootbaalFieldRequest request) 
            => CreateActionResult(await footballFieldService.UpdateFieldAsync(request));

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteFootballFieldById(DeleteFootballFieldRequest request)
            => CreateActionResult(await footballFieldService.DeleteFieldAsync(request));
    }
}
