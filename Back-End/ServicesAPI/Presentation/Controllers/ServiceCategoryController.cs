using Application.DTO.ServiceCategoryDTO;
using Application.Services.Interfaces;
using Domain.Models.PageModels;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extension;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryServices _service;

        public ServiceCategoryController(IServiceCategoryServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = Role.All)]
        public async Task<IActionResult> GetAllServiceCategories([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = Role.All)]
        public async Task<IActionResult> GetServiceCategoryById(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<IActionResult> CreateServiceCategory(
            CreateServiceCategoryDTO serviceCategoryDTO, CancellationToken token)
        {
            var result = await _service.CreateAsync(serviceCategoryDTO, token);

            return result.ToActionResult();
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<IActionResult> UpdateServiceCategory(
            int id, UpdateServiceCategoryDTO serviceCategoryDTO, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, serviceCategoryDTO, token);

            return result.ToActionResult();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<IActionResult> DeleteServiceCategory(int id, CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);

            return result.ToActionResult();
        }
    }
}
