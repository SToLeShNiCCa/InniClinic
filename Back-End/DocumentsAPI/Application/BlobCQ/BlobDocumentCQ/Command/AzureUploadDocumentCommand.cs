using MediatR;

namespace Application.BlobCQ.BlobDocumentCQ.Command
{
    public record class AzureUploadDocumentCommand(byte[] Bytes, string ContentType) : IRequest<string>;
}
