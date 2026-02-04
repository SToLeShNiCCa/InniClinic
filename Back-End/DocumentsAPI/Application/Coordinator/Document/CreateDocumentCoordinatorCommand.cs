using Application.DTO.ResultDTO;
using MediatR;

namespace Application.Coordinator.Document
{
    public record class CreateDocumentCoordinatorCommand(CreateResultDTO ResultDTO) : IRequest<string>;
}
