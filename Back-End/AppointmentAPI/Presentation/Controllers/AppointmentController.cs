using Application.DTO;
using Application.Service.Interface;
using Domain.Models.PageModels;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Authorize(Roles = Role.Stuff)]
        public async Task <ActionResult> GetAll([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _appointmentService.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _appointmentService.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> CreateAsync(CreateAppointmentDTO dto, CancellationToken token)
        {
            var result = await _appointmentService.CreateAsync(dto, token);

            return result.ToActionResult();
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> UpdateAsync(int id, UpdateAppointmentDTO dto,  CancellationToken token)
        {
            var result = await _appointmentService.UpdateAsync(id, dto, token);

            return result.ToActionResult();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> DeleteAsync(int id, CancellationToken token)
        {
            var result = await _appointmentService.DeleteAsync(id,token);

            return result.ToActionResult();
        }
    }
}
