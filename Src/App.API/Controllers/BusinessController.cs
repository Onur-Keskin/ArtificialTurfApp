using App.Application.Features.Business;
using App.Application.Features.Business.Create;
using App.Application.Features.Business.Delete;
using App.Application.Features.Business.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class BusinessController(IBusinessService businessService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBusiness()
            => CreateActionResult(await businessService.GetAllBusinessAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBusinessById(int id)
        => CreateActionResult(await businessService.GetBusinessByIdAsync(id));

        [HttpGet("{id:int}/business")]
        public async Task<IActionResult> GetBusinessWithFields(int id)
            => CreateActionResult(await businessService.GetBusinessWithFieldsAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateBusiness(CreateBusinessRequest request)
            => CreateActionResult(await businessService.AddBusinessAsync(request));

        [HttpPut]
        public async Task<IActionResult> UpdateBussiness(UpdateBussinessRequest request)
        => CreateActionResult(await businessService.UpdateBusinessAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteBusiness(DeleteBusinessRequest request)
            => CreateActionResult(await businessService.DeleteBusinessAsync(request));
    }
}
