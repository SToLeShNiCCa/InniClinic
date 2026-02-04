using Application.Coordinator.Photo;
using Application.DTO;
using Application.DTO.Requests;
using Application.DTO.Response;
using Application.MongoCQ.MongoPhotoCQ.Query;
using Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult<PhotoDTO>> GetPhoto(string id, CancellationToken token)
        {
            var query = new MongoGetByIdPhotoQuery(id);
            var photo = await _mediator.Send(query, token);

            return Ok(photo);
        }

        [HttpPost("upload")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult<PhotoResponse>> UploadPhoto(
            [FromForm] UploadPhotoRequest request, CancellationToken token)
        {
            var coordinator = new CreatePhotoCoordinatorCommand(request);
            var response = await _mediator.Send(coordinator, token);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> DeletePhoto(string id,CancellationToken token)
        {
            var coordinator = new DeletePhotoCoordinatorCommand(id);
            await _mediator.Send(coordinator, token);

            return NoContent();
        }
    }
}
