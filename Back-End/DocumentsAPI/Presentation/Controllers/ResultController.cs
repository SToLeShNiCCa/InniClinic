using Application.Coordinator.Document;
using Application.DTO.ResultDTO;
using Application.MongoCQ.MongoResultCQ.Query;
using Domain.Roles;
using Infrastructure.PageSettings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> GetAllResults([FromQuery] PageInfo pageInfo, CancellationToken token)
        {
            var query = new MongoGetAllResultsQuery(pageInfo);
            var results = await _mediator.Send(query, token);

            return Ok(results);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.All)]
        public async Task<ActionResult> GetResultById(string id, CancellationToken token)
        {
            var query = new MongoGetByIdResultQuery(id);
            var result = await _mediator.Send(query, token);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> CreateResult([FromBody] CreateResultDTO resultDTO, CancellationToken token)
        {
            var coordinator = new CreateDocumentCoordinatorCommand(resultDTO);
            var result = await _mediator.Send(coordinator, token);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> DeleteResult(string id, CancellationToken token)
        {
            var command = new DeleteDocumentCoordinatorCommand(id);
            var result = await _mediator.Send(command, token);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.Stuff)]
        public async Task<ActionResult> UpdateResult(
            string id, [FromBody] UpdateResultDTO updatedResultDTO, CancellationToken token)
        {
            var command = new UpdateDocumentCoordinatorCommand(id, updatedResultDTO);
            var result = await _mediator.Send(command, token);
            return Ok(result);
        }
    }
}
