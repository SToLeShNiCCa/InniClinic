using Application.DTO.Requests;
using Application.DTO.Response;
using MediatR;

namespace Application.Coordinator.Photo
{
    public record class CreatePhotoCoordinatorCommand(UploadPhotoRequest Request) :IRequest<PhotoResponse>;
}
