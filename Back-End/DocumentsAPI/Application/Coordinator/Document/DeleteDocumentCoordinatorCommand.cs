using MediatR;

namespace Application.Coordinator.Document
{
    public record class DeleteDocumentCoordinatorCommand(string Id) : IRequest<Unit>;
}
