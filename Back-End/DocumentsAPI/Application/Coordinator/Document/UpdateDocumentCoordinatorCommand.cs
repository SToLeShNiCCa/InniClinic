using Application.DTO.ResultDTO;
using MediatR;

namespace Application.Coordinator.Document
{
    public record class UpdateDocumentCoordinatorCommand(string Id, UpdateResultDTO UpdatedResultDTO) : IRequest<string>;
}
