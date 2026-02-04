using Application.BlobCQ.BlobPhotoCQ.Command;
using Application.BlobCQ.BlobPhotoCQ.Query;
using Application.DTO.Response;
using Application.Exceptions.MongoExceptions;
using Application.MongoCQ.MongoPhotoCQ.Command;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Coordinator.Photo.Handler
{
    public class CreatePhotoCoordinatorCommandHandler(IMediator _mediator)
        : IRequestHandler<CreatePhotoCoordinatorCommand, PhotoResponse>
    {
        public async Task<PhotoResponse> Handle(CreatePhotoCoordinatorCommand request, CancellationToken token)
        {
            await using var stream = request.Request.File.OpenReadStream();

            var azureFileId = await UploadFileToAzure(stream, request.Request.File, token);
            var url = await GetPhotoUrlFromAzure(azureFileId, token);
            var mongoPhotoId = await AddDataToMongo(url, azureFileId, token);

            var response = new PhotoResponse(url, mongoPhotoId);

            return response;
        }

        private async Task<Guid> UploadFileToAzure(Stream stream, IFormFile file, CancellationToken token)
        {
            var command = new AzureUploadPhotoCommand(stream, file.ContentType);
            var azureFileId = await _mediator.Send(command, token);

            return azureFileId;
        }

        private async Task<string> GetPhotoUrlFromAzure(Guid fileId, CancellationToken token)
        {
            var query = new AzureGetPhotoNameQuery(fileId);
            var url = await _mediator.Send(query, token);

            return url;
        }

        private async Task<string> AddDataToMongo(string url, Guid fileId , CancellationToken token)
        {
            try
            {
                var createPhotoCommand = new MongoCreatePhotoCommand(url);
                var mongoPhotoId = await _mediator.Send(createPhotoCommand, token);

                return mongoPhotoId;
            }
            catch (AddMongoDataException)
            {
                var deleteCommand = new AzureDeletePhotoCommand(fileId);
                await _mediator.Send(deleteCommand, token);

                throw;
            }
        }
    }
}
