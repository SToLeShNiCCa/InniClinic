using Application.DTO;
using Application.Services.Interface;
using Domain.Models.PageModels;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService service)
        {
            _officeService = service;
        }

        [HttpGet]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetAllAsync([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _officeService.GetAllAsync(pageInfo, token);
            return result.ToActionResult();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetById(string id, CancellationToken token)
        {
            var result = await _officeService.GetByIdAsync(id, token);
            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> CreateAsync(CreateOfficeDTO dto, CancellationToken token)
        {
            var result = await _officeService.CreateAsync(dto, token);
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> UpdateAsync(string id, UpdateOfficeDTO dto, CancellationToken token)
        {
            var result = await _officeService.Update(id, dto, token);
            return result.ToActionResult();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> RemoveAsync(string id, CancellationToken token)
        {
            var result = await _officeService.RemoveAsync(id, token);
            return result.ToActionResult();
        }
    }
}
