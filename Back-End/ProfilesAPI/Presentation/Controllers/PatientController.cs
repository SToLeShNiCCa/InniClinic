using Application.DTO.Patients;
using Application.Services.Interfaces;
using Domain.DBServices.Models.PaginationModel;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    /// <summary>
    /// PatientController class - API controller for managing patient entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all patients from the database.
        /// </summary>
        /// <returns>Patient's list.</returns>
        [HttpGet]
        [Authorize(Roles = Role.Staff)]
        public async Task<ActionResult> GetAll([FromQuery] PageInfo pageInfo, CancellationToken token) 
        {
            var result =  await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Get a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Patient object.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Staff)]
        public async Task<ActionResult> GetById(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Post a new patient to the database.
        /// </summary>
        /// <param name="dto">Patient's DTO</param>
        /// <returns>Proof that patient was created(REST).</returns>
        [HttpPost]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Create(CreatePatientDTO dto, CancellationToken token)
        {
            var result = await _service.CreateAsync(dto,token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update an existing patient in the database.
        /// </summary>
        /// <param name="dto">Patient's DTO.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Update(int id, UpdatePatientDTO dto, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, dto, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Delete a patient by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);

            return result.ToActionResult();
        }
    }
}
