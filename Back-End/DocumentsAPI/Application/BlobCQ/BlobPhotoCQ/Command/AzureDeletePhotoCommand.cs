using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Command
{
    public record class AzureDeletePhotoCommand(Guid fileId): IRequest<Unit>;
}
