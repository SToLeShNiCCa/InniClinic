using Application.BlobCQ.BlobPhotoCQ.Command;
using Application.MongoCQ.MongoPhotoCQ.Command;
using Application.MongoCQ.MongoPhotoCQ.Query;
using MediatR;

namespace Application.Coordinator.Photo.Handler
{
    public class DeletePhotoCoordinatorHandler(IMediator _mediator)
        : IRequestHandler<DeletePhotoCoordinatorCommand, Unit>
    {
        public async Task<Unit> Handle(DeletePhotoCoordinatorCommand request, CancellationToken token)
        {
            var url = await GetPhotoUrlFromMongo(request.Id, token);
            await DeletePhotoFromMongo(request.Id, token);
            var photoId = GetGuidFromUrl(url);
            await DeletePhotoFromAzure(photoId, token);

            return Unit.Value;
        }

        private async Task<string> GetPhotoUrlFromMongo(string id, CancellationToken token)
        {
            var query = new MongoGetByIdPhotoQuery(id);
            var photo = await _mediator.Send(query, token);

            return photo.Url;
        }

        private async Task DeletePhotoFromMongo(string id, CancellationToken token)
        {
            var command = new MongoDeletePhotoCommand(id);
            await _mediator.Send(command, token);
        }

        private async Task DeletePhotoFromAzure(Guid fileId, CancellationToken token)
        {
            var deleteCommand = new AzureDeletePhotoCommand(fileId);
            await _mediator.Send(deleteCommand, token);
        }

        private Guid GetGuidFromUrl(string url)
        {
            string result = url.Split('/').Last();

            return Guid.Parse(result);
        }
    }
}
