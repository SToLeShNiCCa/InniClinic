using Application.DTO.Doctors;
using Application.Services.Interfaces;
using Domain.DBServices.Models.PaginationModel;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    /// <summary>
    /// DoctorController class - API controller for managing doctor entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        /// <summary>
        /// Controller's dependencies.
        /// </summary>
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all doctors from the database.
        /// </summary>
        /// <returns>Doctor's list</returns>
        [HttpGet]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetAll([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Gets a doctor by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns>Doctor's object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Posts a new doctor to the database.
        /// </summary>
        /// <param name="dto">Doctor's DTO</param>
        /// <returns>Proof that doctor was created(REST)</returns>
        [HttpPost]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> CreateAsync(CreateDoctorDTO dto, CancellationToken token)
        {
            var result = await _service.CreateAsync(dto, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Updates an existing doctor's information.
        /// </summary>
        /// <param name="dto">Doctor's DTO</param>
        /// <param name="id">Unique identifier</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> UpdateAsync(int id, UpdateDoctorDTO dto, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, dto, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Deletes a doctor by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);
            
            return result.ToActionResult();
        }
    }
}
