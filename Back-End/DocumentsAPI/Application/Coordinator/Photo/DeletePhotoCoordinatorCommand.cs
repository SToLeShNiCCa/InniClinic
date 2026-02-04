using MediatR;

namespace Application.Coordinator.Photo
{
    public record class DeletePhotoCoordinatorCommand(string Id) : IRequest<Unit>;
}
