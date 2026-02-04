using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobDocumentCQ.Command.Handler
{
    public class AzureDeleteDocumentCommandHandler(IBlobRepository _repository)
        : IRequestHandler<AzureDeleteDocumentCommand, Unit>
    {
        public async Task<Unit> Handle(AzureDeleteDocumentCommand request, CancellationToken token)
        {
            var client = _repository.AddDocumentBlobClient(request.DocumentId);
            await client.DeleteIfExistsAsync(cancellationToken: token);

            return Unit.Value;
        }
    }
}
