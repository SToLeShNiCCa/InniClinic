using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Command
{
    public record class AzureUploadPhotoCommand(Stream Stream, string ContentType) : IRequest<Guid>;
}
