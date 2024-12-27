using App.Application.Features.FootballFieds;
using App.Application.Features.FootballFieds.Create;
using App.Application.Features.FootballFieds.Delete;
using App.Application.Features.FootballFieds.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballFieldController(IFootballFieldService footballFieldService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => CreateActionResult(await footballFieldService.GetAllFieldsAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
            => CreateActionResult(await footballFieldService.GetFieldByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateFootballFieldRequest request) 
            => CreateActionResult(await footballFieldService.AddFieldAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateFootbaalFieldRequest request) 
            => CreateActionResult(await footballFieldService.UpdateFieldAsync(request));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, DeleteFootballFieldRequest request)
            => CreateActionResult(await footballFieldService.DeleteFieldAsync(request));
    }
}
