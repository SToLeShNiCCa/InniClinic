using MediatR;

namespace Application.BlobCQ.BlobDocumentCQ.Command
{
    public record class AzureDeleteDocumentCommand(Guid DocumentId ):IRequest<Unit>;
}
