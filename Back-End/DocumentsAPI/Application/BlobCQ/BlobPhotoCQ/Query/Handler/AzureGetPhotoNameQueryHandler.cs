using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Query.Handler
{
    public class AzureGetPhotoNameQueryHandler(IBlobRepository _repository)
        : IRequestHandler<AzureGetPhotoNameQuery, string>
    {
        public Task<string> Handle(AzureGetPhotoNameQuery request, CancellationToken token)
        {
            var blobClient = _repository.AddPhotoBlobClient(request.FileId);

            return Task.FromResult(blobClient.Uri.ToString());
        }
    }
}
