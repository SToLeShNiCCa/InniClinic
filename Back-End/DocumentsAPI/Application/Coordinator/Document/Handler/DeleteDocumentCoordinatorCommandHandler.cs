using Application.BlobCQ.BlobDocumentCQ.Command;
using Application.DTO;
using Application.MongoCQ.MongoDocumentCQ.Query;
using Application.MongoCQ.MongoResultCQ.Command;
using MediatR;

namespace Application.Coordinator.Document.Handler
{
    public class DeleteDocumentCoordinatorCommandHandler(IMediator _mediator) 
        : IRequestHandler<DeleteDocumentCoordinatorCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteDocumentCoordinatorCommand request, CancellationToken token)
        {
            var documentDTO = await GetByIdDocument(request.Id, token);
            var documentId = GetGuidFromUrl(documentDTO.Url);

            await DeleteDataFromMongo(request.Id, token);
            await DeleteDataFromBlobDocument(documentId, token);

            return Unit.Value;
        }

        private async Task<DocumentDTO> GetByIdDocument(string id, CancellationToken token)
        {
            var query = new MongoGetByIdDocumentQuery(id);
            var documentDTO = await _mediator.Send(query, token);

            return documentDTO;
        }

        private async Task DeleteDataFromMongo(string id, CancellationToken token)
        {
            var command = new DeleteMongoResultCommand(id);
            await _mediator.Send(command, token);
        }

        private async Task DeleteDataFromBlobDocument(Guid id, CancellationToken token)
        {
            var deletePhotoCommand = new AzureDeleteDocumentCommand(id);
            await _mediator.Send(deletePhotoCommand, token);
        }

        private Guid GetGuidFromUrl(string url)
        {
            string result = url.Split('/').Last();

            return Guid.Parse(result);
        }
    }
}
