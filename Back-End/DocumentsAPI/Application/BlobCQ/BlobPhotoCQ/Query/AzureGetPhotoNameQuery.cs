using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Query
{
    public record class AzureGetPhotoNameQuery(Guid FileId) : IRequest<string>;
}
