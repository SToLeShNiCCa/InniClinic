using Application.DTO.Receptionist;
using Application.Services.Interfaces;
using Domain.DBServices.Models.PaginationModel;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    /// <summary>
    /// ReceptionistController class - API controller for managing receptionist entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistService _service;

        public ReceptionistController(IReceptionistService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all receptionists from the database.
        /// </summary>
        /// <returns>receptionist's list.</returns>
        [HttpGet]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetAll([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var result = await _service.GetAllAsync(pageInfo, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Gets a receptionist by their unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>Receptionist object.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _service.GetByIdAsync(id, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Posts a new receptionist to the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> CreateAsync(CreateReceptionistDTO dto, CancellationToken token)
        {
            var result = await _service.CreateAsync(dto, token); // TODO

            return result.ToActionResult();
        }

        /// <summary>
        /// Updates an existing receptionist in the database.
        /// </summary>
        /// <param name="dto">Receptionist's DTO.</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Update(int id, UpdateReceptionistDTO dto, CancellationToken token)
        {
            var result = await _service.UpdateAsync(id, dto, token);

            return result.ToActionResult();
        }

        /// <summary>
        /// Deletes a receptionist from the database.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Role.Receptionist)]
        public async Task<ActionResult> Delete(int id,CancellationToken token)
        {
            var result = await _service.DeleteAsync(id, token);

            return result.ToActionResult();
        }
    }
}
