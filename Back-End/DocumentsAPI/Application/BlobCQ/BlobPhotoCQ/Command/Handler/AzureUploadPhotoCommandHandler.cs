using Azure.Storage.Blobs.Models;
using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Command.Handler
{
    public class AzureUploadPhotoCommandHandler(IBlobRepository _repository)
        : IRequestHandler<AzureUploadPhotoCommand, Guid>
    {
        public async Task<Guid> Handle(AzureUploadPhotoCommand request, CancellationToken token)
        {
            var fileId = Guid.NewGuid();
            var blobClient = _repository.AddPhotoBlobClient(fileId);

            await blobClient.UploadAsync(
                request.Stream,
                new BlobHttpHeaders {ContentType = request.ContentType },
                cancellationToken: token
                );

            return fileId;
        }
    }
}
